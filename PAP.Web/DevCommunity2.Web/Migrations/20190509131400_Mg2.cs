using Microsoft.EntityFrameworkCore.Migrations;

namespace DevCommunity2.Web.Migrations
{
    public partial class Mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Event");
        }
    }
}
