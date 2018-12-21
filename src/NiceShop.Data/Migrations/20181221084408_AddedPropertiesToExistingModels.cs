using Microsoft.EntityFrameworkCore.Migrations;

namespace NiceShop.Data.Migrations
{
    public partial class AddedPropertiesToExistingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Shops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Shops",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Shops");
        }
    }
}
