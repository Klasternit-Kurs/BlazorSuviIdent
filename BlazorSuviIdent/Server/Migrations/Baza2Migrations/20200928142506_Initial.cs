using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSuviIdent.Server.Migrations.Baza2Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blas",
                columns: table => new
                {
                    Asd = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blas", x => x.Asd);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blas");
        }
    }
}
