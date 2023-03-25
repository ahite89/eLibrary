using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddMorePhotoDataToBookEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookCoverFilePath",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookCoverUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookCoverFilePath",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookCoverUrl",
                table: "Books");
        }
    }
}
