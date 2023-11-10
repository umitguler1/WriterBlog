using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterBlog.DataAccess.Migrations
{
    public partial class add_read_coulum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "Message2s",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Read",
                table: "Message2s");

            migrationBuilder.DropColumn(
                name: "Read",
                table: "Contacts");
        }
    }
}
