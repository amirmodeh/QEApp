using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QEApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newmobilestring1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OtpExpiresAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtpExpiresAt",
                table: "AspNetUsers");
        }
    }
}
