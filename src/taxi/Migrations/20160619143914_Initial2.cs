using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace taxi.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AddressWhere",
                table: "Orders",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "AddressFrom",
                table: "Orders",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comments",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "NumberCar",
                table: "Cars",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ModelCar",
                table: "Cars",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ColourCar",
                table: "Cars",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AddressWhere",
                table: "Orders",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressFrom",
                table: "Orders",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comments",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumberCar",
                table: "Cars",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModelCar",
                table: "Cars",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ColourCar",
                table: "Cars",
                nullable: true);
        }
    }
}
