using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookCoverId",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCoverId",
                table: "Books",
                column: "BookCoverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Photos_BookCoverId",
                table: "Books",
                column: "BookCoverId",
                principalTable: "Photos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Photos_BookCoverId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookCoverId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookCoverId",
                table: "Books");
        }
    }
}
