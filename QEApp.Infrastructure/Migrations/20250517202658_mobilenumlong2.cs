﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QEApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mobilenumlong2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OtpExpiresAt",
                table: "AspNetUsers",
                newName: "OtpGeneratedAt");

            migrationBuilder.AlterColumn<long>(
                name: "MobileNumber",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OtpGeneratedAt",
                table: "AspNetUsers",
                newName: "OtpExpiresAt");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
