using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace test.Data.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_region_name_region_id_military_district",
                table: "region",
                columns: new[] { "name_region", "id_military_district" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_city_name_city_id_area",
                table: "city",
                columns: new[] { "name_city", "id_area" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_area_name_area_id_region",
                table: "area",
                columns: new[] { "name_area", "id_region" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_region_name_region_id_military_district",
                table: "region");

            migrationBuilder.DropIndex(
                name: "IX_city_name_city_id_area",
                table: "city");

            migrationBuilder.DropIndex(
                name: "IX_area_name_area_id_region",
                table: "area");
        }
    }
}
