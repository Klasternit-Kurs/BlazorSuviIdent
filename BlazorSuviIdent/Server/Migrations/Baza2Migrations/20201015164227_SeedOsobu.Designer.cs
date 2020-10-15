﻿// <auto-generated />
using BlazorSuviIdent.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorSuviIdent.Server.Migrations.Baza2Migrations
{
    [DbContext(typeof(Baza2))]
    [Migration("20201015164227_SeedOsobu")]
    partial class SeedOsobu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorSuviIdent.Shared.Osoba", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Osobas");

                    b.HasData(
                        new
                        {
                            ID = "671e01b0-3d68-4530-8aec-9b0db052b297",
                            Ime = "Pera",
                            Prezime = "Peric"
                        },
                        new
                        {
                            ID = "0921695e-fa57-4ae5-af5a-4e4d4f0e19ed",
                            Ime = "Neko",
                            Prezime = "Nekic"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
