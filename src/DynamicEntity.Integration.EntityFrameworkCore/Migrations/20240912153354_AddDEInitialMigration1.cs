using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicEntity.Integration.Migrations
{
    /// <inheritdoc />
    public partial class AddDEInitialMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "dynamicEntiteys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "dynamicEntiteys",
                type: "datetime2",
                nullable: true);
        }
    }
}
