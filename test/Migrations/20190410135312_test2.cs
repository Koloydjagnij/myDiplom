using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace test.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTo",
                table: "enrollee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTo",
                table: "enrollee");
        }
    }
}
