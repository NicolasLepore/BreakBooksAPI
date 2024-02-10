using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreakBooks.Migrations
{
    /// <inheritdoc />
    public partial class PropUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Books",
                newName: "Genre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Books",
                newName: "Gender");
        }
    }
}
