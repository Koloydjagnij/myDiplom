using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace test.Data.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pochta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ActDate = table.Column<string>(maxLength: 256, nullable: true),
                    Area = table.Column<string>(maxLength: 256, nullable: true),
                    Autonom = table.Column<string>(maxLength: 256, nullable: true),
                    City = table.Column<string>(maxLength: 256, nullable: true),
                    City1 = table.Column<string>(maxLength: 256, nullable: true),
                    Index = table.Column<string>(maxLength: 256, nullable: true),
                    IndexOld = table.Column<string>(maxLength: 256, nullable: true),
                    OPSName = table.Column<string>(maxLength: 256, nullable: true),
                    OPSSubm = table.Column<string>(maxLength: 256, nullable: true),
                    OPSType = table.Column<string>(maxLength: 256, nullable: true),
                    Region = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pochta", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pochta");
        }
    }
}
