using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace test.Migrations
{
    public partial class test13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "grade_point_AVG",
                table: "enrollee",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "id_current_spec",
                table: "enrollee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_first_spec",
                table: "enrollee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_group",
                table: "enrollee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_reserve_spec",
                table: "enrollee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_second_spec",
                table: "enrollee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_third_spec",
                table: "enrollee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    id_group = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CountEnrolleeInGroup = table.Column<int>(nullable: false),
                    group_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.id_group);
                });

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_current_spec",
                table: "enrollee",
                column: "id_current_spec");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_first_spec",
                table: "enrollee",
                column: "id_first_spec");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_group",
                table: "enrollee",
                column: "id_group");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_reserve_spec",
                table: "enrollee",
                column: "id_reserve_spec");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_second_spec",
                table: "enrollee",
                column: "id_second_spec");

            migrationBuilder.CreateIndex(
                name: "IX_enrollee_id_third_spec",
                table: "enrollee",
                column: "id_third_spec");

            migrationBuilder.AddForeignKey(
                name: "FK_enrollee_speciality_id_current_spec",
                table: "enrollee",
                column: "id_current_spec",
                principalTable: "speciality",
                principalColumn: "id_speciality",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollee_speciality_id_first_spec",
                table: "enrollee",
                column: "id_first_spec",
                principalTable: "speciality",
                principalColumn: "id_speciality",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "enrolleesGroup",
                table: "enrollee",
                column: "id_group",
                principalTable: "Groups",
                principalColumn: "id_group",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollee_speciality_id_reserve_spec",
                table: "enrollee",
                column: "id_reserve_spec",
                principalTable: "speciality",
                principalColumn: "id_speciality",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollee_speciality_id_second_spec",
                table: "enrollee",
                column: "id_second_spec",
                principalTable: "speciality",
                principalColumn: "id_speciality",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_enrollee_speciality_id_third_spec",
                table: "enrollee",
                column: "id_third_spec",
                principalTable: "speciality",
                principalColumn: "id_speciality",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enrollee_speciality_id_current_spec",
                table: "enrollee");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollee_speciality_id_first_spec",
                table: "enrollee");

            migrationBuilder.DropForeignKey(
                name: "enrolleesGroup",
                table: "enrollee");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollee_speciality_id_reserve_spec",
                table: "enrollee");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollee_speciality_id_second_spec",
                table: "enrollee");

            migrationBuilder.DropForeignKey(
                name: "FK_enrollee_speciality_id_third_spec",
                table: "enrollee");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_id_current_spec",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_id_first_spec",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_id_group",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_id_reserve_spec",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_id_second_spec",
                table: "enrollee");

            migrationBuilder.DropIndex(
                name: "IX_enrollee_id_third_spec",
                table: "enrollee");

            migrationBuilder.DropColumn(
                name: "grade_point_AVG",
                table: "enrollee");

            migrationBuilder.DropColumn(
                name: "id_current_spec",
                table: "enrollee");

            migrationBuilder.DropColumn(
                name: "id_first_spec",
                table: "enrollee");

            migrationBuilder.DropColumn(
                name: "id_group",
                table: "enrollee");

            migrationBuilder.DropColumn(
                name: "id_reserve_spec",
                table: "enrollee");

            migrationBuilder.DropColumn(
                name: "id_second_spec",
                table: "enrollee");

            migrationBuilder.DropColumn(
                name: "id_third_spec",
                table: "enrollee");
        }
    }
}
