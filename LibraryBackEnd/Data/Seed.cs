using LibraryBackEnd.Models;
using Microsoft.AspNetCore.Identity;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryBackEnd.Data
{
    public class Seed
    {
        public static async Task SeedData(AppDbContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser {DisplayName = "John Johnson", UserName = "jjohnson01", Email = "jj@gmail.com"},
                    new AppUser {DisplayName = "Peter Peterson", UserName = "ppeterson01", Email = "pp@gmail.com"},
                    new AppUser {DisplayName = "Allison Smith", UserName = "asmith01", Email = "as@yahoo.com"},
                    new AppUser {DisplayName = "Vanessa Jones", UserName = "vjones01", Email = "vj@hotmail.com"}
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "ISBN4life");
                }
            }

            //if (!context.Photos.Any())
            //{
            //    var bookCovers = new List<Photo>
            //    {
            //        new Photo { Id = "The_Great_Gatsby_fce787", Url = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/The_Great_Gatsby_fce787.jpg" },
            //        new Photo { Id = "Animal_Farm_jcem3h", Url = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275817/Animal_Farm_jcem3h.jpg" },
            //        new Photo { Id = "Harry_Potter_and_the_Philosopher_s_Stone_g00shi", Url = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Harry_Potter_and_the_Philosopher_s_Stone_g00shi.jpg" },
            //        new Photo { Id = "Jurassic_park_w9f11f", Url = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Jurassic_park_w9f11f.jpg" },
            //        new Photo { Id = "The_Grapes_of_Wrath_yxfd6r", Url = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/The_Grapes_of_Wrath_yxfd6r.jpg" },
            //        new Photo { Id = "Beloved_ww2gzk", Url = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Beloved_ww2gzk.jpg" },
            //        new Photo { Id = "Everything_Is_Illuminated_dree98", Url = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275817/Everything_Is_Illuminated_dree98.jpg" },
            //        new Photo { Id = "Breakfast_Of_Champions_hzdbdw", Url = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Breakfast_Of_Champions_hzdbdw.jpg" },
            //        new Photo { Id = "Watership_Down_j8tbod", Url = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Watership_Down_j8tbod.jpg" },
            //        new Photo { Id = "The_Joy_Luck_Club_aermat", Url = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/The_Joy_Luck_Club_aermat.jpg" },
            //        new Photo { Id = "Something_wicked_this_way_comes_jgfqsu", Url = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Something_wicked_this_way_comes_jgfqsu.jpg" }
            //    };

            //    await context.Photos.AddRangeAsync(bookCovers);
            //    await context.SaveChangesAsync();
            //}

            if (!context.Books.Any())
            {
                var books = new List<Book>
                {
                    new Book
                    {
                        Id = new Guid("a7f69a1d-a1c9-4f22-a0c2-1de38ad15ac0"),
                        Title = "The Great Gatsby",
                        Author = "F. Scott Fitzgerald",
                        Description = "Set in the Jazz Age on Long Island, near New York City, the novel depicts first-person narrator Nick Carraway's interactions with mysterious millionaire Jay Gatsby and Gatsby's obsession to reunite with his former lover, Daisy Buchanan.",
                        Year = "1925",
                        CheckedOut = false,
                        CheckedOutBy = null,
                        DateAdded = DateTime.Now,
                        AddedBy = new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"),
                        BookCoverUrl = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/The_Great_Gatsby_fce787.jpg"
                    },
                    new Book
                    {
                        Id = new Guid("2bcb21a0-b176-42c2-a879-25d5d4c4f033"),
                        Title = "Animal Farm",
                        Author = "George Orwell",
                        Description = "A group of farm animals rebel against their human farmer, hoping to create a society where the animals can be equal, free, and happy.",
                        Year = "1945",
                        CheckedOut = false,
                        CheckedOutBy = null,
                        DateAdded = DateTime.Now,
                        AddedBy = new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"),
                        BookCoverUrl = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275817/Animal_Farm_jcem3h.jpg"
                    },
                    new Book
                    {
                        Id = new Guid("c9c46b56-5362-4a84-8c1c-8e0410d5c68f"),
                        Title = "Harry Potter and the Sorcerer's Stone",
                        Author = "J.K. Rowling",
                        Description = "A young wizard discovers his magical heritage on his eleventh birthday, when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry.",
                        Year = "1997",
                        CheckedOut = false,
                        CheckedOutBy = null,
                        DateAdded = DateTime.Now,
                        AddedBy = new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"),
                        BookCoverUrl = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Harry_Potter_and_the_Philosopher_s_Stone_g00shi.jpg"
                    },
                    new Book
                    {
                        Id = new Guid("ef60ed5d-4d2b-49e9-ada8-5ed1ca9a13bf"),
                        Title = "Jurassic Park",
                        Author = "Michael Crichton",
                        Description = "A cautionary tale about genetic engineering, it presents the collapse of an amusement park showcasing genetically re-created dinosaurs to illustrate the mathematical concept of chaos theory and its real-world implications.",
                        Year = "1990",
                        CheckedOut = false,
                        CheckedOutBy = null,
                        DateAdded = DateTime.Now,
                        AddedBy = new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"),
                        BookCoverUrl = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Jurassic_park_w9f11f.jpg"
                    },
                    new Book
                    {
                        Id = new Guid("5ec376d0-4408-49c2-b804-3e79623630e5"),
                        Title = "The Grapes of Wrath",
                        Author = "John Steinbeck",
                        Description = "The Joads, a poor family of tenant farmers from Oklahoma, set out for California seeking jobs, land, dignity, and a future.",
                        Year = "1939",
                        CheckedOut = false,
                        CheckedOutBy = null,
                        DateAdded = DateTime.Now,
                        AddedBy = new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"),
                        BookCoverUrl = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/The_Grapes_of_Wrath_yxfd6r.jpg"
                    },
                    new Book 
                    {
                        Id = new Guid("09da1af3-7ad7-4fc7-becb-ac484a4ee64f"),
                        Title = "Beloved",
                        Author = "Toni Morrison",
                        Description = "Set in the period after the American Civil War, the novel tells the story of a dysfunctional family of formerly enslaved people whose Cincinnati home is haunted by a malevolent spirit.",
                        Year = "1987",
                        CheckedOut = false,
                        CheckedOutBy = null,
                        DateAdded = DateTime.Now,
                        AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                        BookCoverUrl = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Beloved_ww2gzk.jpg"
                    },
                    new Book
                    {
                        Id = new Guid("10ad3a5b-8d5e-4adb-a8b3-483fe4705397"),
                        Title = "Everything Is Illuminated",
                        Author = "Jonathan Safran Foer",
                        Description = "Tells the fictionalized history of the eradicated town of Trochenbrod, a real exclusively Jewish shtetl in Poland before the Holocaust where the author's grandfather was born.",
                        Year = "2002",
                        CheckedOut = false,
                        CheckedOutBy = null,
                        DateAdded = DateTime.Now,
                        AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                        BookCoverUrl = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275817/Everything_Is_Illuminated_dree98.jpg"
                    },
                    new Book
                    {
                        Id = new Guid("adf710a2-1572-4e9d-b707-189ee2948d75"),
                        Title = "Breakfast of Champions",
                        Author = "Kurt Vonnegut",
                        Description = "Tells the story of the events that lead up to the meeting of science fiction author, Kilgore Trout, and affluent city figure, Dwayne Hoover, as well as the meeting itself, and the immediate aftermath.",
                        Year = "1973",
                        CheckedOut = false,
                        CheckedOutBy = null,
                        DateAdded = DateTime.Now,
                        AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                        BookCoverUrl = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Breakfast_Of_Champions_hzdbdw.jpg"
                    },
                    new Book
                    {
                        Id = new Guid("1d129b52-cafd-4100-ad19-7db304cf2ec2"),
                        Title = "Watership Down",
                        Author = "Richard Adams",
                        Description = "A small group of rabbits escape the destruction of their warren and seek a place to establish a new home (the hill of Watership Down), encountering perils and temptations along the way.",
                        Year = "1972",
                        CheckedOut = false,
                        CheckedOutBy = null,
                        DateAdded = DateTime.Now,
                        AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                        BookCoverUrl = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Watership_Down_j8tbod.jpg"
                    },
                    new Book
                    {
                        Id = new Guid("0a301a9a-4cc3-4096-9f59-efcd9c5500bd"),
                        Title = "The Joy Luck Club",
                        Author = "Amy Tan",
                        Description = "Four Chinese immigrant families in San Francisco start a club known as The Joy Luck Club, playing the Chinese game of mahjong for money while feasting on a variety of foods.",
                        Year = "1989",
                        CheckedOut = false,
                        CheckedOutBy = null,
                        DateAdded = DateTime.Now,
                        AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                        BookCoverUrl = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/The_Joy_Luck_Club_aermat.jpg"
                    },
                    new Book
                    {
                        Id = new Guid("935e4678-3929-4184-a72e-77a2c3ec4c48"),
                        Title = "Something Wicked This Way Comes",
                        Author = "Ray Bradbury",
                        Description = "Two 13-year-old best friends, Jim Nightshade and William Halloway, have a nightmarish experience when a traveling carnival arrives in their Midwestern town.",
                        Year = "1962",
                        CheckedOut = false,
                        CheckedOutBy = null,
                        DateAdded = DateTime.Now,
                        AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                        BookCoverUrl = "https://res.cloudinary.com/deegwzaxk/image/upload/v1679275818/Something_wicked_this_way_comes_jgfqsu.jpg"
                    }
                };

                await context.Books.AddRangeAsync(books);
                await context.SaveChangesAsync();
            }            
        }
    }
}
