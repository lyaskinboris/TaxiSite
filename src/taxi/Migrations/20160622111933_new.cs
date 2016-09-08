using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace taxi.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataTime",
                table: "Orders",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataTime",
                table: "Orders",
                nullable: false);
        }
    }
}
