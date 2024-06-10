using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trendit_ProjectAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSqftscapital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sqft",
                table: "Villas",
                newName: "Sqft");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sqft",
                table: "Villas",
                newName: "sqft");
        }
    }
}
