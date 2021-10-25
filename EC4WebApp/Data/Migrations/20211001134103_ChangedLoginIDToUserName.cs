using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EC4WebApp.Data.Migrations
{
    public partial class ChangedLoginIDToUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ad31b67-5112-41b7-9cc3-1ee7fad94228");

            migrationBuilder.RenameColumn(
                name: "LoginId",
                table: "AspNetUsers",
                newName: "DisplayName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "AspNetUsers",
                newName: "LoginId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Description", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "LoginId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PhotoPath", "SecurityStamp", "StudentId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7ad31b67-5112-41b7-9cc3-1ee7fad94228", 0, "f9b1c505-90d9-4eb4-939d-b8466c5416af", new DateTime(1999, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "EC 4th batch student", "zawnay160399@gmail.com", true, false, null, "zawnaylin@1999", "ZAWNAY160399@GMAIL.COM", "ZAW NAY LIN", "AQAAAAEAACcQAAAAEMb9fxVLPzFO8+lnGdPsGUVGfKn+PpvehZuHKqdVa9n25nFvOwzlSuoPwQIfv2+3hA==", "09795841501", true, null, "f38a8051-945b-4979-a702-35db91aead66", "15/26821", false, "Zaw Nay Lin" });
        }
    }
}
