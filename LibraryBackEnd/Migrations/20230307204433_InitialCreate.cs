using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckedOut = table.Column<bool>(type: "bit", nullable: false),
                    CheckedOutBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AddedBy", "Author", "CheckedOut", "CheckedOutBy", "DateAdded", "Description", "Title", "Year" },
                values: new object[,]
                {
                    { new Guid("09da1af3-7ad7-4fc7-becb-ac484a4ee64f"), new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"), "Toni Morrison", false, null, new DateTime(2023, 3, 7, 15, 44, 32, 911, DateTimeKind.Local).AddTicks(2092), "Set in the period after the American Civil War, the novel tells the story of a dysfunctional family of formerly enslaved people whose Cincinnati home is haunted by a malevolent spirit.", "Beloved", "1987" },
                    { new Guid("0a301a9a-4cc3-4096-9f59-efcd9c5500bd"), new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"), "Amy Tan", false, null, new DateTime(2023, 3, 7, 15, 44, 32, 911, DateTimeKind.Local).AddTicks(2122), "Four Chinese immigrant families in San Francisco start a club known as The Joy Luck Club, playing the Chinese game of mahjong for money while feasting on a variety of foods.", "The Joy Luck Club", "1989" },
                    { new Guid("10ad3a5b-8d5e-4adb-a8b3-483fe4705397"), new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"), "Jonathan Safran Foer", false, null, new DateTime(2023, 3, 7, 15, 44, 32, 911, DateTimeKind.Local).AddTicks(2099), "Tells the fictionalized history of the eradicated town of Trochenbrod, a real exclusively Jewish shtetl in Poland before the Holocaust where the author's grandfather was born.", "Everything Is Illuminated", "2002" },
                    { new Guid("1d129b52-cafd-4100-ad19-7db304cf2ec2"), new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"), "Richard Adams", true, new Guid("88ac6b98-a10d-4222-82e7-304095745639"), new DateTime(2023, 3, 7, 15, 44, 32, 911, DateTimeKind.Local).AddTicks(2114), "A small group of rabbits escape the destruction of their warren and seek a place to establish a new home (the hill of Watership Down), encountering perils and temptations along the way.", "Watership Down", "1972" },
                    { new Guid("2bcb21a0-b176-42c2-a879-25d5d4c4f033"), new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"), "George Orwell", false, null, new DateTime(2023, 3, 7, 15, 44, 32, 911, DateTimeKind.Local).AddTicks(2059), "A group of farm animals rebel against their human farmer, hoping to create a society where the animals can be equal, free, and happy.", "Animal Farm", "1945" },
                    { new Guid("5ec376d0-4408-49c2-b804-3e79623630e5"), new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"), "John Steinbeck", true, new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), new DateTime(2023, 3, 7, 15, 44, 32, 911, DateTimeKind.Local).AddTicks(2082), "The Joads, a poor family of tenant farmers from Oklahoma, set out for California seeking jobs, land, dignity, and a future.", "The Grapes of Wrath", "1939" },
                    { new Guid("935e4678-3929-4184-a72e-77a2c3ec4c48"), new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"), "Ray Bradbury", false, null, new DateTime(2023, 3, 7, 15, 44, 32, 911, DateTimeKind.Local).AddTicks(2129), "Two 13-year-old best friends, Jim Nightshade and William Halloway, have a nightmarish experience when a traveling carnival arrives in their Midwestern town.", "Something Wicked This Way Comes", "1962" },
                    { new Guid("a7f69a1d-a1c9-4f22-a0c2-1de38ad15ac0"), new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"), "F. Scott Fitzgerald", true, new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), new DateTime(2023, 3, 7, 15, 44, 32, 911, DateTimeKind.Local).AddTicks(2001), "Set in the Jazz Age on Long Island, near New York City, the novel depicts first-person narrator Nick Carraway's interactions with mysterious millionaire Jay Gatsby and Gatsby's obsession to reunite with his former lover, Daisy Buchanan.", "The Great Gatsby", "1925" },
                    { new Guid("adf710a2-1572-4e9d-b707-189ee2948d75"), new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"), "Kurt Vonnegut", true, new Guid("88ac6b98-a10d-4222-82e7-304095745639"), new DateTime(2023, 3, 7, 15, 44, 32, 911, DateTimeKind.Local).AddTicks(2107), "Tells the story of the events that lead up to the meeting of science fiction author, Kilgore Trout, and affluent city figure, Dwayne Hoover, as well as the meeting itself, and the immediate aftermath.", "Breakfast of Champions", "1973" },
                    { new Guid("c9c46b56-5362-4a84-8c1c-8e0410d5c68f"), new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"), "J.K. Rowling", true, new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), new DateTime(2023, 3, 7, 15, 44, 32, 911, DateTimeKind.Local).AddTicks(2068), "A young wizard discovers his magical heritage on his eleventh birthday, when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry.", "Harry Potter and the Sorcerer's Stone", "1997" },
                    { new Guid("ef60ed5d-4d2b-49e9-ada8-5ed1ca9a13bf"), new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"), "Michael Crichton", false, null, new DateTime(2023, 3, 7, 15, 44, 32, 911, DateTimeKind.Local).AddTicks(2075), "A cautionary tale about genetic engineering, it presents the collapse of an amusement park showcasing genetically re-created dinosaurs to illustrate the mathematical concept of chaos theory and its real-world implications.", "Jurassic Park", "1990" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserRole", "Username" },
                values: new object[,]
                {
                    { new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"), "isbn", 1, "lib01" },
                    { new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"), "dewey", 1, "lib02" },
                    { new Guid("88ac6b98-a10d-4222-82e7-304095745639"), "readingchamp55", 0, "user02" },
                    { new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), "bookworm123", 0, "user01" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
