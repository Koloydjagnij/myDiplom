using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace test.Migrations
{
    public partial class test7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "r_17",
                table: "enrollee");

            migrationBuilder.DropForeignKey(
                name: "r_79",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_id_military_office",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_id_military_unit",
                table: "enrollee");

            migrationBuilder.AlterColumn<string>(
                name: "id_military_unit",
                table: "enrollee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "id_military_office",
                table: "enrollee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MilitaryOfficeIdMilitaryOffice",
                table: "enrollee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MilitaryUnitIdMilitaryUnit",
                table: "enrollee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_MilitaryOfficeIdMilitaryOffice",
                table: "enrollee",
                column: "MilitaryOfficeIdMilitaryOffice");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_MilitaryUnitIdMilitaryUnit",
                table: "enrollee",
                column: "MilitaryUnitIdMilitaryUnit");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollee_military_office_MilitaryOfficeIdMilitaryOffice",
                table: "enrollee",
                column: "MilitaryOfficeIdMilitaryOffice",
                principalTable: "military_office",
                principalColumn: "id_military_office",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollee_military_unit_MilitaryUnitIdMilitaryUnit",
                table: "enrollee",
                column: "MilitaryUnitIdMilitaryUnit",
                principalTable: "military_unit",
                principalColumn: "id_military_unit",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrollee_military_office_MilitaryOfficeIdMilitaryOffice",
                table: "enrollee");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollee_military_unit_MilitaryUnitIdMilitaryUnit",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_MilitaryOfficeIdMilitaryOffice",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_MilitaryUnitIdMilitaryUnit",
                table: "enrollee");

            migrationBuilder.DropColumn(
                name: "MilitaryOfficeIdMilitaryOffice",
                table: "enrollee");

            migrationBuilder.DropColumn(
                name: "MilitaryUnitIdMilitaryUnit",
                table: "enrollee");

            migrationBuilder.AlterColumn<int>(
                name: "id_military_unit",
                table: "enrollee",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_military_office",
                table: "enrollee",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_military_office",
                table: "enrollee",
                column: "id_military_office");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_military_unit",
                table: "enrollee",
                column: "id_military_unit");

            migrationBuilder.AddForeignKey(
                name: "r_17",
                table: "enrollee",
                column: "id_military_office",
                principalTable: "military_office",
                principalColumn: "id_military_office",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "r_79",
                table: "enrollee",
                column: "id_military_unit",
                principalTable: "military_unit",
                principalColumn: "id_military_unit",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
