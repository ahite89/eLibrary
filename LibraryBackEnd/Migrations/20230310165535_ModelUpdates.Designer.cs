﻿// <auto-generated />
using System;
using LibraryBackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryBackEnd.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230310165535_ModelUpdates")]
    partial class ModelUpdates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryBackEnd.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CheckedOut")
                        .HasColumnType("bit");

                    b.Property<Guid?>("CheckedOutBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a7f69a1d-a1c9-4f22-a0c2-1de38ad15ac0"),
                            AddedBy = new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"),
                            Author = "F. Scott Fitzgerald",
                            CheckedOut = true,
                            CheckedOutBy = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                            DateAdded = new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7599),
                            Description = "Set in the Jazz Age on Long Island, near New York City, the novel depicts first-person narrator Nick Carraway's interactions with mysterious millionaire Jay Gatsby and Gatsby's obsession to reunite with his former lover, Daisy Buchanan.",
                            Title = "The Great Gatsby",
                            Year = "1925"
                        },
                        new
                        {
                            Id = new Guid("2bcb21a0-b176-42c2-a879-25d5d4c4f033"),
                            AddedBy = new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"),
                            Author = "George Orwell",
                            CheckedOut = false,
                            DateAdded = new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7674),
                            Description = "A group of farm animals rebel against their human farmer, hoping to create a society where the animals can be equal, free, and happy.",
                            Title = "Animal Farm",
                            Year = "1945"
                        },
                        new
                        {
                            Id = new Guid("c9c46b56-5362-4a84-8c1c-8e0410d5c68f"),
                            AddedBy = new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"),
                            Author = "J.K. Rowling",
                            CheckedOut = true,
                            CheckedOutBy = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                            DateAdded = new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7687),
                            Description = "A young wizard discovers his magical heritage on his eleventh birthday, when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry.",
                            Title = "Harry Potter and the Sorcerer's Stone",
                            Year = "1997"
                        },
                        new
                        {
                            Id = new Guid("ef60ed5d-4d2b-49e9-ada8-5ed1ca9a13bf"),
                            AddedBy = new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"),
                            Author = "Michael Crichton",
                            CheckedOut = false,
                            DateAdded = new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7698),
                            Description = "A cautionary tale about genetic engineering, it presents the collapse of an amusement park showcasing genetically re-created dinosaurs to illustrate the mathematical concept of chaos theory and its real-world implications.",
                            Title = "Jurassic Park",
                            Year = "1990"
                        },
                        new
                        {
                            Id = new Guid("5ec376d0-4408-49c2-b804-3e79623630e5"),
                            AddedBy = new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"),
                            Author = "John Steinbeck",
                            CheckedOut = true,
                            CheckedOutBy = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                            DateAdded = new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7709),
                            Description = "The Joads, a poor family of tenant farmers from Oklahoma, set out for California seeking jobs, land, dignity, and a future.",
                            Title = "The Grapes of Wrath",
                            Year = "1939"
                        },
                        new
                        {
                            Id = new Guid("09da1af3-7ad7-4fc7-becb-ac484a4ee64f"),
                            AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                            Author = "Toni Morrison",
                            CheckedOut = false,
                            DateAdded = new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7726),
                            Description = "Set in the period after the American Civil War, the novel tells the story of a dysfunctional family of formerly enslaved people whose Cincinnati home is haunted by a malevolent spirit.",
                            Title = "Beloved",
                            Year = "1987"
                        },
                        new
                        {
                            Id = new Guid("10ad3a5b-8d5e-4adb-a8b3-483fe4705397"),
                            AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                            Author = "Jonathan Safran Foer",
                            CheckedOut = false,
                            DateAdded = new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7735),
                            Description = "Tells the fictionalized history of the eradicated town of Trochenbrod, a real exclusively Jewish shtetl in Poland before the Holocaust where the author's grandfather was born.",
                            Title = "Everything Is Illuminated",
                            Year = "2002"
                        },
                        new
                        {
                            Id = new Guid("adf710a2-1572-4e9d-b707-189ee2948d75"),
                            AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                            Author = "Kurt Vonnegut",
                            CheckedOut = true,
                            CheckedOutBy = new Guid("88ac6b98-a10d-4222-82e7-304095745639"),
                            DateAdded = new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7748),
                            Description = "Tells the story of the events that lead up to the meeting of science fiction author, Kilgore Trout, and affluent city figure, Dwayne Hoover, as well as the meeting itself, and the immediate aftermath.",
                            Title = "Breakfast of Champions",
                            Year = "1973"
                        },
                        new
                        {
                            Id = new Guid("1d129b52-cafd-4100-ad19-7db304cf2ec2"),
                            AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                            Author = "Richard Adams",
                            CheckedOut = true,
                            CheckedOutBy = new Guid("88ac6b98-a10d-4222-82e7-304095745639"),
                            DateAdded = new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7759),
                            Description = "A small group of rabbits escape the destruction of their warren and seek a place to establish a new home (the hill of Watership Down), encountering perils and temptations along the way.",
                            Title = "Watership Down",
                            Year = "1972"
                        },
                        new
                        {
                            Id = new Guid("0a301a9a-4cc3-4096-9f59-efcd9c5500bd"),
                            AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                            Author = "Amy Tan",
                            CheckedOut = false,
                            DateAdded = new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7854),
                            Description = "Four Chinese immigrant families in San Francisco start a club known as The Joy Luck Club, playing the Chinese game of mahjong for money while feasting on a variety of foods.",
                            Title = "The Joy Luck Club",
                            Year = "1989"
                        },
                        new
                        {
                            Id = new Guid("935e4678-3929-4184-a72e-77a2c3ec4c48"),
                            AddedBy = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                            Author = "Ray Bradbury",
                            CheckedOut = false,
                            DateAdded = new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7865),
                            Description = "Two 13-year-old best friends, Jim Nightshade and William Halloway, have a nightmarish experience when a traveling carnival arrives in their Midwestern town.",
                            Title = "Something Wicked This Way Comes",
                            Year = "1962"
                        });
                });

            modelBuilder.Entity("LibraryBackEnd.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                            Password = "bookworm123",
                            UserRole = 0,
                            Username = "user01"
                        },
                        new
                        {
                            Id = new Guid("88ac6b98-a10d-4222-82e7-304095745639"),
                            Password = "readingchamp55",
                            UserRole = 0,
                            Username = "user02"
                        },
                        new
                        {
                            Id = new Guid("5bc832ad-e995-49dd-a5ba-80c72bfe0090"),
                            Password = "isbn",
                            UserRole = 1,
                            Username = "lib01"
                        },
                        new
                        {
                            Id = new Guid("69d24a5c-2f0b-4e20-aee3-97401b15a918"),
                            Password = "dewey",
                            UserRole = 1,
                            Username = "lib02"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
