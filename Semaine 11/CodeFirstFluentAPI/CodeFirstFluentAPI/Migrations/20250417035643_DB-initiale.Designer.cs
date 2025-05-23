﻿// <auto-generated />
using System;
using CodeFirstFluentAPI.Modele;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFirstFluentAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250417035643_DB-initiale")]
    partial class DBinitiale
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("CodeFirstFluentAPI.Modele.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<int>("Année")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1970)
                        .HasColumnName("AnneeDeSortie")
                        .HasColumnOrder(2);

                    b.Property<int>("GroupeId")
                        .HasColumnType("int")
                        .HasColumnName("GroupeId")
                        .HasColumnOrder(3);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nom")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("GroupeId");

                    b.ToTable("Albums", "dbo");
                });

            modelBuilder.Entity("CodeFirstFluentAPI.Modele.Groupe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("DateCreation")
                        .HasColumnOrder(2);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("Générique")
                        .HasColumnName("Genre")
                        .HasColumnOrder(3);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nom")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("CodeFirstFluentAPI.Modele.Musicien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("DateNaissance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("DateNaissance")
                        .HasColumnOrder(3);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nom")
                        .HasColumnOrder(1);

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Prenom")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("Musiciens", "dbo");
                });

            modelBuilder.Entity("GroupeMusicien", b =>
                {
                    b.Property<int>("GroupesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MusiciensId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupesId", "MusiciensId");

                    b.HasIndex("MusiciensId");

                    b.ToTable("MusicienGroupe", (string)null);
                });

            modelBuilder.Entity("CodeFirstFluentAPI.Modele.Album", b =>
                {
                    b.HasOne("CodeFirstFluentAPI.Modele.Groupe", "Groupe")
                        .WithMany("Albums")
                        .HasForeignKey("GroupeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groupe");
                });

            modelBuilder.Entity("GroupeMusicien", b =>
                {
                    b.HasOne("CodeFirstFluentAPI.Modele.Groupe", null)
                        .WithMany()
                        .HasForeignKey("GroupesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeFirstFluentAPI.Modele.Musicien", null)
                        .WithMany()
                        .HasForeignKey("MusiciensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeFirstFluentAPI.Modele.Groupe", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
