using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterBlog.DataAccess.Migrations
{
    public partial class mid_description_admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Admins");
        }
    }
}
