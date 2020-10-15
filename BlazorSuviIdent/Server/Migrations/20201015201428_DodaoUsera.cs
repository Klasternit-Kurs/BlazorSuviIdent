using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSuviIdent.Server.Migrations
{
    public partial class DodaoUsera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9b8b088-f188-4299-bb46-e2ba697192d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7ecec53-46c4-4976-a0a2-4193bb6c540c");

            migrationBuilder.AddColumn<string>(
                name: "BlaBla",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nesto",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1aa4836-ccbc-4462-b0e6-e16c05730aed", "233cf639-c5a1-4ad8-a616-3110ec5b2014", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efdd3b8d-ee24-4100-89f4-0a43e4148f30", "804582b3-328b-40ce-a6e1-f87bcc4ff7a6", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efdd3b8d-ee24-4100-89f4-0a43e4148f30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1aa4836-ccbc-4462-b0e6-e16c05730aed");

            migrationBuilder.DropColumn(
                name: "BlaBla",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nesto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9b8b088-f188-4299-bb46-e2ba697192d2", "6e5766e0-2608-4764-9da8-b84dc2157916", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7ecec53-46c4-4976-a0a2-4193bb6c540c", "17cfd4af-933d-400d-966b-1a264361b047", "User", "USER" });
        }
    }
}
