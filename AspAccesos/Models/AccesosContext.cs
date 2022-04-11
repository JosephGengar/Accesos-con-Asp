using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspAccesos.Models
{
    public partial class AccesosContext : DbContext
    {
        public AccesosContext()
        {
        }

        public AccesosContext(DbContextOptions<AccesosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TEstado> TEstado { get; set; }
        public virtual DbSet<TUsuarios> TUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Accesos;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEstado>(entity =>
            {
                entity.ToTable("tEstado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TUsuarios>(entity =>
            {
                entity.ToTable("tUsuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Entidad)
                    .IsRequired()
                    .HasColumnName("entidad")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.TUsuarios)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tUsuarios_tEstado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
