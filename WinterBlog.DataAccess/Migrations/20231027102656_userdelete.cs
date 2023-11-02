using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinterBlog.DataAccess.Migrations
{
    public partial class userdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Writers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Writers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Writers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Writers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Writers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Writers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Writers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
