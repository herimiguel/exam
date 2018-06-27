using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace exam.Migrations
{
    public partial class thirdone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinator",
                table: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "YourName",
                table: "Activities",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YourName",
                table: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "Coordinator",
                table: "Activities",
                nullable: true);
        }
    }
}
