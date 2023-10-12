using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Realtor.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyPropertyInPropertyEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuiltIn",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ResidentialComplexName",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SubmissionDate",
                table: "Properties");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "BuiltIn",
                table: "Properties",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "ResidentialComplexName",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "SubmissionDate",
                table: "Properties",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
