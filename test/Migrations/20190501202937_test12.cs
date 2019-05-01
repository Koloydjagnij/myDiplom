using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace test.Migrations
{
    public partial class test12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "change_history",
                columns: table => new
                {
                    id_change_history = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    changeBy = table.Column<string>(nullable: true),
                    date_time = table.Column<DateTime>(nullable: false),
                    EnrolleeIdEnrollee = table.Column<int>(nullable: true),
                    field_name = table.Column<string>(nullable: true),
                    new_value = table.Column<string>(nullable: true),
                    old_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_change_history", x => x.id_change_history);
                    table.ForeignKey(
                        name: "FK_change_history_enrollee_EnrolleeIdEnrollee",
                        column: x => x.EnrolleeIdEnrollee,
                        principalTable: "enrollee",
                        principalColumn: "id_enrollee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_change_history_EnrolleeIdEnrollee",
                table: "change_history",
                column: "EnrolleeIdEnrollee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "change_history");
        }
    }
}
