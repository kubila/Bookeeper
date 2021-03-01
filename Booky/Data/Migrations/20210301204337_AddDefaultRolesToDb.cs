using Microsoft.EntityFrameworkCore.Migrations;

namespace Booky.Data.Migrations
{
    public partial class AddDefaultRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d4adb8e-74db-4835-84fa-c54b755adfeb", "9f5feaf7-e27a-453f-a013-4a41db3bfeb8", "VoidUser", "VOIDUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf96ce05-2cd8-4302-9c31-81d38a86abb0", "520ac82f-f4a4-4466-8868-3785617449f4", "StaffUser", "STAFFUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff6ac610-d32d-4a37-9e1f-d6a0fef74b87", "a11e28bd-f943-4f54-8b95-576d51d47819", "AdminUser", "ADMINUSER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d4adb8e-74db-4835-84fa-c54b755adfeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf96ce05-2cd8-4302-9c31-81d38a86abb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff6ac610-d32d-4a37-9e1f-d6a0fef74b87");
        }
    }
}
