using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace taxi.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Orders",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CompanyTaxis",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "AddressOffice",
                table: "CompanyTaxis",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Comments",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Orders",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CompanyTaxis",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressOffice",
                table: "CompanyTaxis",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Comments",
                nullable: false);
        }
    }
}
