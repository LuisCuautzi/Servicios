using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gen06_WCF.Models
{
    public partial class AerolineasContext : DbContext
    {
        public AerolineasContext()
        {
        }

        public AerolineasContext(DbContextOptions<AerolineasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aerolineas> Aerolineas { get; set; }
        public virtual DbSet<Aeropuertos> Aeropuertos { get; set; }
        public virtual DbSet<Aviones> Aviones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-1L1MF13\\SQLEXPRESS;DataBase=Aerolineas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aerolineas>(entity =>
            {
                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.Iata).HasColumnName("IATA");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Aeropuertos>(entity =>
            {
                entity.Property(e => e.Iata)
                    .IsRequired()
                    .HasColumnName("IATA");

                entity.Property(e => e.Icao)
                    .IsRequired()
                    .HasColumnName("ICAO");

                entity.Property(e => e.Latitud).IsRequired();

                entity.Property(e => e.Longuitud).IsRequired();

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Pais).IsRequired();

                entity.Property(e => e.Terminal).IsRequired();

                entity.Property(e => e.ZonaHoraria).IsRequired();
            });

            modelBuilder.Entity<Aviones>(entity =>
            {
                entity.HasIndex(e => e.AerolineaId);

                entity.Property(e => e.AerolineaId).HasColumnName("AerolineaID");

                entity.Property(e => e.CodigoModelo).IsRequired();

                entity.Property(e => e.Modelo).IsRequired();

                entity.Property(e => e.NumRegistro)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Tipo).IsRequired();

                entity.HasOne(d => d.Aerolinea)
                    .WithMany(p => p.Aviones)
                    .HasForeignKey(d => d.AerolineaId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
