using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Data.Migrations
{
    public partial class AddUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "unit",
                columns: unit => new
                {
                    Id = unit.Column<int>(maxLength: 5, nullable: false),
                    UnitName = unit.Column<string>(nullable: true),
                    UnitId = unit.Column<string>(nullable: true),
                    UnitDescription = unit.Column<string>(nullable: true),
                    UnitBeginDate = unit.Column<string>(nullable: true),
                    UnitEndDate = unit.Column<string>(nullable: true)
                },
                constraints: unit => 
                {
                    unit.PrimaryKey(
                        "PK_UnitId", PK => PK.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_UnitId", "unit");
            migrationBuilder.DropTable("unit");
        }
    }
}
