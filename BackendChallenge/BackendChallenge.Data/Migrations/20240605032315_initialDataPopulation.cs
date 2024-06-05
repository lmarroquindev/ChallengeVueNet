using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendChallenge.Data.Migrations
{
    public partial class initialDataPopulation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PermissionType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Enfermedad" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PermissionType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Diligencias" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PermissionType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "Otros" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
