using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSuviIdent.Server.Migrations.Baza2Migrations
{
    public partial class SeedOsobu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Osobas",
                columns: new[] { "ID", "Ime", "Prezime" },
                values: new object[] { "671e01b0-3d68-4530-8aec-9b0db052b297", "Pera", "Peric" });

            migrationBuilder.InsertData(
                table: "Osobas",
                columns: new[] { "ID", "Ime", "Prezime" },
                values: new object[] { "0921695e-fa57-4ae5-af5a-4e4d4f0e19ed", "Neko", "Nekic" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Osobas",
                keyColumn: "ID",
                keyValue: "0921695e-fa57-4ae5-af5a-4e4d4f0e19ed");

            migrationBuilder.DeleteData(
                table: "Osobas",
                keyColumn: "ID",
                keyValue: "671e01b0-3d68-4530-8aec-9b0db052b297");
        }
    }
}
