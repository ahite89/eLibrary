using LibraryBackEnd.Models;
using LibraryBackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LibraryBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, TokenService tokenService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDataObj>> Login(Login loginData)
        {
            var user = await _userManager.FindByEmailAsync(loginData.Email);

            if (user == null) return Unauthorized();

            var isUser = await _userManager.IsInRoleAsync(user, "User");
            var isLibrarian = await _userManager.IsInRoleAsync(user, "Librarian");

            if (isUser || isLibrarian) 
            {
                // Set role for UI
                var roles = await _userManager.GetRolesAsync(user);
                user.Role = roles[0];

                var passwordExists = await _userManager.CheckPasswordAsync(user, loginData.Password);

                if (passwordExists)
                {
                    return CreateUserObject(user);
                }
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDataObj>> Register(Register registerData)
        {            
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerData.Username))
            {
                return BadRequest("Username is already taken");
            }

            if (await _userManager.Users.AnyAsync(x => x.Email == registerData.Email))
            {
                return BadRequest("Email is already taken");
            }

            var user = new AppUser
            {
                DisplayName = registerData.DisplayName,
                Email = registerData.Email,
                UserName = registerData.Username,
                Role = registerData.Role
            };

            if (!await _roleManager.RoleExistsAsync(user.Role))
            {
                var role = new IdentityRole { Name = user.Role };
                var roleResult = await _roleManager.CreateAsync(role);

                if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);
            }

            var createResult = await _userManager.CreateAsync(user, registerData.Password);

            if (createResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registerData.Role);
                return CreateUserObject(user);
            }

            return BadRequest(createResult.Errors);
        }

        [AllowAnonymous]
        [HttpPost("current")]
        public async Task<ActionResult<UserDataObj>> GetCurrentUser(UserDataObj userData)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userData.Username);
                return CreateUserObject(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public async void Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //}

        private UserDataObj CreateUserObject(AppUser user)
        {
            return new UserDataObj
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName,
                Role = user.Role
            };
        }
    }
}
