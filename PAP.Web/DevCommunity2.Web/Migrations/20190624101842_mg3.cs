using Microsoft.EntityFrameworkCore.Migrations;

namespace DevCommunity2.Web.Migrations
{
    public partial class mg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataPublish",
                table: "PublishEvent",
                newName: "PublishDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "PublishEvent",
                newName: "DataPublish");
        }
    }
}
