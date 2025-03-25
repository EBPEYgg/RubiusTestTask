using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RubiusTestTask.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintForRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Track_Rating",
                table: "Tracks",
                sql: "\"Rating\" IN (-1, 0, 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Track_Rating",
                table: "Tracks");
        }
    }
}
