﻿// <auto-generated />
using System;
using EF_CodeFirst.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCodeFirst.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230131141942_Test")]
    partial class Test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_CodeFirst.EF.Personne_Hugo", b =>
                {
                    b.Property<int>("Personne_HugoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Personne_HugoId"));

                    b.Property<string>("Cellulaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Courriel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Personne_HugoId");

                    b.ToTable("Personne_Hugos");
                });

            modelBuilder.Entity("EF_CodeFirst.EF.Projet_Hugo", b =>
                {
                    b.Property<int>("Projet_HugoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Projet_HugoId"));

                    b.Property<float>("BudgetRestant")
                        .HasColumnType("real");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descrition")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Projet_HugoId");

                    b.ToTable("Projet_Hugos");
                });

            modelBuilder.Entity("Personne_HugoProjet_Hugo", b =>
                {
                    b.Property<int>("PersonnesPersonne_HugoId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetsProjet_HugoId")
                        .HasColumnType("int");

                    b.HasKey("PersonnesPersonne_HugoId", "ProjetsProjet_HugoId");

                    b.HasIndex("ProjetsProjet_HugoId");

                    b.ToTable("Personne_HugoProjet_Hugo");
                });

            modelBuilder.Entity("Personne_HugoProjet_Hugo", b =>
                {
                    b.HasOne("EF_CodeFirst.EF.Personne_Hugo", null)
                        .WithMany()
                        .HasForeignKey("PersonnesPersonne_HugoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_CodeFirst.EF.Projet_Hugo", null)
                        .WithMany()
                        .HasForeignKey("ProjetsProjet_HugoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
