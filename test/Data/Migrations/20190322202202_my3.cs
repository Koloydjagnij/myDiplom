using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace test.Data.Migrations
{
    public partial class my3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id_town",
                table: "educational_institution",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id_town",
                table: "educational_institution",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
