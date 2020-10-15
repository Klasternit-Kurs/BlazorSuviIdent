using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSuviIdent.Server.Migrations.Baza2Migrations
{
    public partial class DodaoOsobu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blas");

            migrationBuilder.CreateTable(
                name: "Osobas",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobas", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Osobas");

            migrationBuilder.CreateTable(
                name: "Blas",
                columns: table => new
                {
                    Asd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blas", x => x.Asd);
                });
        }
    }
}
