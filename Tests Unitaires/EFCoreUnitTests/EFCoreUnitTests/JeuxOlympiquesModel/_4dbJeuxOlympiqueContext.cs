using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreUnitTests.Model;

public partial class _4dbJeuxOlympiqueContext : DbContext
{
    public _4dbJeuxOlympiqueContext()
    {
    }

    public _4dbJeuxOlympiqueContext(DbContextOptions<_4dbJeuxOlympiqueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Commanditaire> Commanditaires { get; set; }

    public virtual DbSet<Coureur> Coureurs { get; set; }

    public virtual DbSet<Entraineur> Entraineurs { get; set; }

    public virtual DbSet<Record> Records { get; set; }
    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=172.16.20.230;Initial Catalog=4DB-JeuxOlympique;User ID=Etudiant;Password=Qwerty123!;Encrypt=False;Trust Server Certificate=True", x => x.UseNetTopologySuite());
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Commanditaire>(entity =>
        {
            entity.ToTable("Commanditaire");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CommanditeParCoureur).HasColumnType("money");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Coureur>(entity =>
        {
            entity.ToTable("Coureur");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pays)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.IdCommenditaires).WithMany(p => p.IdCoureurs)
                .UsingEntity<Dictionary<string, object>>(
                    "CoureurCommenditaire",
                    r => r.HasOne<Commanditaire>().WithMany()
                        .HasForeignKey("IdCommenditaire")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CoureurCommenditaire_Commanditaire"),
                    l => l.HasOne<Coureur>().WithMany()
                        .HasForeignKey("IdCoureur")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CoureurCommenditaire_Coureur"),
                    j =>
                    {
                        j.HasKey("IdCoureur", "IdCommenditaire");
                        j.ToTable("CoureurCommenditaire");
                    });

            entity.HasMany(d => d.IdEntraineurs).WithMany(p => p.IdCoureurs)
                .UsingEntity<Dictionary<string, object>>(
                    "CoureurEntraineur",
                    r => r.HasOne<Entraineur>().WithMany()
                        .HasForeignKey("IdEntraineur")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CoureurEntraineur_Entraineur"),
                    l => l.HasOne<Coureur>().WithMany()
                        .HasForeignKey("IdCoureur")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CoureurEntraineur_Coureur"),
                    j =>
                    {
                        j.HasKey("IdCoureur", "IdEntraineur");
                        j.ToTable("CoureurEntraineur");
                    });
        });

        modelBuilder.Entity<Entraineur>(entity =>
        {
            entity.ToTable("Entraineur");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.ToTable("Record");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Record1)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("Record");

            entity.HasOne(d => d.IdCoureurNavigation).WithMany(p => p.Records)
                .HasForeignKey(d => d.IdCoureur)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Record_Coureur");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
