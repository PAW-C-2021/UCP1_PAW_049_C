using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UCPPraktikam1.Models
{
    public partial class UCPPenjualanSapiContext : DbContext
    {
        public UCPPenjualanSapiContext()
        {
        }

        public UCPPenjualanSapiContext(DbContextOptions<UCPPenjualanSapiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pembayaran> Pembayaran { get; set; }
        public virtual DbSet<Pembeli> Pembeli { get; set; }
        public virtual DbSet<Sapi> Sapi { get; set; }
        public virtual DbSet<Transaksi> Transaksi { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pembayaran>(entity =>
            {
                entity.HasKey(e => e.Idpembayaran);

                entity.Property(e => e.Idpembayaran).ValueGeneratedNever();

                entity.HasOne(d => d.IdtranksaksiNavigation)
                    .WithMany(p => p.Pembayaran)
                    .HasForeignKey(d => d.Idtranksaksi)
                    .HasConstraintName("FK_Pembayaran_Transaksi");
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.Idpembeli);

                entity.Property(e => e.Idpembeli).ValueGeneratedNever();

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sapi>(entity =>
            {
                entity.HasKey(e => e.IdSapi);

                entity.Property(e => e.IdSapi).ValueGeneratedNever();

                entity.Property(e => e.NamaSapi)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.Idtransaksi);

                entity.Property(e => e.Idtransaksi).ValueGeneratedNever();

                entity.Property(e => e.Tgltransaksi).HasColumnType("datetime");

                entity.HasOne(d => d.IdpembeliNavigation)
                    .WithMany(p => p.Transaksi)
                    .HasForeignKey(d => d.Idpembeli)
                    .HasConstraintName("FK_Transaksi_Pembeli");

                entity.HasOne(d => d.IdsapiNavigation)
                    .WithMany(p => p.Transaksi)
                    .HasForeignKey(d => d.Idsapi)
                    .HasConstraintName("FK_Transaksi_Sapi");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
