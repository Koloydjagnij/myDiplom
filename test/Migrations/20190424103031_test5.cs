using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace test.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeFile",
                table: "DocumentFile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeFile",
                table: "DocumentFile");
        }
    }
}
