using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExempleWCFServeur.EFModel;

public partial class _4dbProgrammingefdb1Context : DbContext
{
    public _4dbProgrammingefdb1Context()
    {
    }

    public _4dbProgrammingefdb1Context(DbContextOptions<_4dbProgrammingefdb1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Projet> Projets { get; set; }

    public virtual DbSet<VOfficeAddress> VOfficeAddresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=172.16.20.230;Initial Catalog=4DB_PROGRAMMINGEFDB1;Persist Security Info=True;User ID=4db;Password=Qwerty123!;Encrypt=False", x => x.UseNetTopologySuite());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Addresses");

            entity.ToTable("Address");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressType).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CountryRegion).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PostalCode).HasMaxLength(50);
            entity.Property(e => e.StateProvince).HasMaxLength(50);
            entity.Property(e => e.Street1).HasMaxLength(50);
            entity.Property(e => e.Street2).HasMaxLength(50);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK_Person");

            entity.ToTable("Contact");

            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.AddDate).HasColumnType("datetime");
            entity.Property(e => e.Covid).HasColumnName("COVID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.ImageContact).HasColumnType("image");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Photo).HasColumnType("image");
            entity.Property(e => e.PhotoPath).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasMany(d => d.Addresses).WithMany(p => p.Contacts)
                .UsingEntity<Dictionary<string, object>>(
                    "ContactAdress",
                    r => r.HasOne<Address>().WithMany()
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_ContactAdress_Address"),
                    l => l.HasOne<Contact>().WithMany()
                        .HasForeignKey("ContactId")
                        .HasConstraintName("FK_ContactAdress_Contact"),
                    j =>
                    {
                        j.HasKey("ContactId", "AddressId");
                        j.ToTable("ContactAdress");
                        j.IndexerProperty<int>("ContactId").HasColumnName("ContactID");
                        j.IndexerProperty<int>("AddressId").HasColumnName("AddressID");
                    });
        });

        modelBuilder.Entity<Projet>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasMany(d => d.IdContacts).WithMany(p => p.IdProjets)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjetContact",
                    r => r.HasOne<Contact>().WithMany()
                        .HasForeignKey("IdContact")
                        .HasConstraintName("FK_Projet_Contact_Contact"),
                    l => l.HasOne<Projet>().WithMany()
                        .HasForeignKey("IdProjet")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Projet_Contact_Projets"),
                    j =>
                    {
                        j.HasKey("IdProjet", "IdContact");
                        j.ToTable("Projet_Contact");
                    });
        });

        modelBuilder.Entity<VOfficeAddress>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vOfficeAddresses");

            entity.Property(e => e.AddressId).HasColumnName("addressID");
            entity.Property(e => e.AddressType).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.CountryRegion).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PostalCode).HasMaxLength(50);
            entity.Property(e => e.StateProvince).HasMaxLength(50);
            entity.Property(e => e.Street1).HasMaxLength(50);
            entity.Property(e => e.Street2).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
