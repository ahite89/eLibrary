using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddBookCoverProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookCoverSrc",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("09da1af3-7ad7-4fc7-becb-ac484a4ee64f"),
                columns: new[] { "BookCoverSrc", "DateAdded" },
                values: new object[] { "Content/Images/Beloved.jpg", new DateTime(2023, 3, 13, 13, 22, 49, 793, DateTimeKind.Local).AddTicks(989) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0a301a9a-4cc3-4096-9f59-efcd9c5500bd"),
                columns: new[] { "BookCoverSrc", "DateAdded" },
                values: new object[] { "Content/Images/The_Joy_Luck_Club.jpg", new DateTime(2023, 3, 13, 13, 22, 49, 793, DateTimeKind.Local).AddTicks(1021) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("10ad3a5b-8d5e-4adb-a8b3-483fe4705397"),
                columns: new[] { "BookCoverSrc", "DateAdded" },
                values: new object[] { "Content/Images/Everything_Is_Illuminated.jpg", new DateTime(2023, 3, 13, 13, 22, 49, 793, DateTimeKind.Local).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1d129b52-cafd-4100-ad19-7db304cf2ec2"),
                columns: new[] { "BookCoverSrc", "DateAdded" },
                values: new object[] { "Content/Images/Watership_Down.jpg", new DateTime(2023, 3, 13, 13, 22, 49, 793, DateTimeKind.Local).AddTicks(1013) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2bcb21a0-b176-42c2-a879-25d5d4c4f033"),
                columns: new[] { "BookCoverSrc", "DateAdded" },
                values: new object[] { "Content/Images/Animal_Farm.jpg", new DateTime(2023, 3, 13, 13, 22, 49, 793, DateTimeKind.Local).AddTicks(953) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5ec376d0-4408-49c2-b804-3e79623630e5"),
                columns: new[] { "BookCoverSrc", "DateAdded" },
                values: new object[] { "Content/Images/The_Graphes_of_Wrath.jpg", new DateTime(2023, 3, 13, 13, 22, 49, 793, DateTimeKind.Local).AddTicks(979) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("935e4678-3929-4184-a72e-77a2c3ec4c48"),
                columns: new[] { "BookCoverSrc", "DateAdded" },
                values: new object[] { "Content/Images/Something_wicked_this_way_comes.jpg", new DateTime(2023, 3, 13, 13, 22, 49, 793, DateTimeKind.Local).AddTicks(1028) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a7f69a1d-a1c9-4f22-a0c2-1de38ad15ac0"),
                columns: new[] { "BookCoverSrc", "DateAdded" },
                values: new object[] { "Content/Images/The_Great_Gatsby.jpg", new DateTime(2023, 3, 13, 13, 22, 49, 793, DateTimeKind.Local).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("adf710a2-1572-4e9d-b707-189ee2948d75"),
                columns: new[] { "BookCoverSrc", "DateAdded" },
                values: new object[] { "Content/Images/Breakfast_Of_Champions.jpg", new DateTime(2023, 3, 13, 13, 22, 49, 793, DateTimeKind.Local).AddTicks(1006) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c9c46b56-5362-4a84-8c1c-8e0410d5c68f"),
                columns: new[] { "BookCoverSrc", "DateAdded" },
                values: new object[] { "Content/Images/Harry_Potter_and_the_Philosopher's_Stone.jpg", new DateTime(2023, 3, 13, 13, 22, 49, 793, DateTimeKind.Local).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ef60ed5d-4d2b-49e9-ada8-5ed1ca9a13bf"),
                columns: new[] { "BookCoverSrc", "DateAdded" },
                values: new object[] { "Content/Images/Jurassic_park.jpg", new DateTime(2023, 3, 13, 13, 22, 49, 793, DateTimeKind.Local).AddTicks(970) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookCoverSrc",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("09da1af3-7ad7-4fc7-becb-ac484a4ee64f"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0a301a9a-4cc3-4096-9f59-efcd9c5500bd"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("10ad3a5b-8d5e-4adb-a8b3-483fe4705397"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1d129b52-cafd-4100-ad19-7db304cf2ec2"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2bcb21a0-b176-42c2-a879-25d5d4c4f033"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5ec376d0-4408-49c2-b804-3e79623630e5"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("935e4678-3929-4184-a72e-77a2c3ec4c48"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a7f69a1d-a1c9-4f22-a0c2-1de38ad15ac0"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("adf710a2-1572-4e9d-b707-189ee2948d75"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c9c46b56-5362-4a84-8c1c-8e0410d5c68f"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ef60ed5d-4d2b-49e9-ada8-5ed1ca9a13bf"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 10, 11, 55, 34, 948, DateTimeKind.Local).AddTicks(7698));
        }
    }
}
