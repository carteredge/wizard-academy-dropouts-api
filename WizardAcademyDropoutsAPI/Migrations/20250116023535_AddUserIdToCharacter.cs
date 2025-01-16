using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizardAcademyDropouts.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Characters");
        }
    }
}
