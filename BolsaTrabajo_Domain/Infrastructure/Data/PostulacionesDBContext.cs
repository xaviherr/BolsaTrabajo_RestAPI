using System;
using BolsaTrabajo_Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BolsaTrabajo_Domain.Infrastructure.Data
{
    public partial class PostulacionesDBContext : DbContext
    {
        public PostulacionesDBContext()
        {
        }

        public PostulacionesDBContext(DbContextOptions<PostulacionesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Capacitacion> Capacitacion { get; set; }
        public virtual DbSet<ExperienciaLaboral> ExperienciaLaboral { get; set; }
        public virtual DbSet<HojaDeVida> HojaDeVida { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<Oferta> Oferta { get; set; }
        public virtual DbSet<Organizacion> Organizacion { get; set; }
        public virtual DbSet<Postulacion> Postulacion { get; set; }
        public virtual DbSet<Postulante> Postulante { get; set; }
        public virtual DbSet<Reclutador> Reclutador { get; set; }
        public virtual DbSet<ReferenciaLaboral> ReferenciaLaboral { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=34.135.180.129;Database=PostulacionesDB;User ID=dpa_esan;Password=esan2021;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Capacitacion>(entity =>
            {
                entity.HasKey(e => e.IdCapacitacion);

                entity.ToTable("CAPACITACION");

                entity.Property(e => e.IdCapacitacion)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_CAPACITACION");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_FIN");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_INICIO");
            });

            modelBuilder.Entity<ExperienciaLaboral>(entity =>
            {
                entity.HasKey(e => e.IdExperiencia);

                entity.ToTable("EXPERIENCIA_LABORAL");

                entity.Property(e => e.IdExperiencia)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_EXPERIENCIA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_FIN");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_INICIO");

                entity.Property(e => e.Organizacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ORGANIZACION");

                entity.Property(e => e.Puesto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PUESTO");
            });

            modelBuilder.Entity<HojaDeVida>(entity =>
            {
                entity.HasKey(e => e.IdHojavida);

                entity.ToTable("HOJA_DE_VIDA");

                entity.Property(e => e.IdHojavida)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_HOJAVIDA");

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.IdCapacitacion).HasColumnName("ID_CAPACITACION");

                entity.Property(e => e.IdExperiencia).HasColumnName("ID_EXPERIENCIA");

                entity.Property(e => e.IdReferencia).HasColumnName("ID_REFERENCIA");

                entity.HasOne(d => d.DniNavigation)
                    .WithMany(p => p.HojaDeVida)
                    .HasForeignKey(d => d.Dni)
                    .HasConstraintName("FK_HOJA_DE__REFERENCE_POSTULAN");

                entity.HasOne(d => d.IdCapacitacionNavigation)
                    .WithMany(p => p.HojaDeVida)
                    .HasForeignKey(d => d.IdCapacitacion)
                    .HasConstraintName("FK_HOJA_DE__REFERENCE_CAPACITA");

                entity.HasOne(d => d.IdExperienciaNavigation)
                    .WithMany(p => p.HojaDeVida)
                    .HasForeignKey(d => d.IdExperiencia)
                    .HasConstraintName("FK_HOJA_DE__REFERENCE_EXPERIEN");

                entity.HasOne(d => d.IdReferenciaNavigation)
                    .WithMany(p => p.HojaDeVida)
                    .HasForeignKey(d => d.IdReferencia)
                    .HasConstraintName("FK_HOJA_DE__REFERENCE_REFERENC");
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad);

                entity.ToTable("LOCALIDAD");

                entity.Property(e => e.IdLocalidad)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_LOCALIDAD");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasKey(e => e.IdOferta);

                entity.ToTable("OFERTA");

                entity.Property(e => e.IdOferta)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_OFERTA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.FechaPublicacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_PUBLICACION");

                entity.Property(e => e.IdLocalidad).HasColumnName("ID_LOCALIDAD");

                entity.Property(e => e.Salario)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("SALARIO");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.DniNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.Dni)
                    .HasConstraintName("FK_OFERTA_REFERENCE_RECLUTAD");

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdLocalidad)
                    .HasConstraintName("FK_OFERTA_REFERENCE_LOCALIDA");
            });

            modelBuilder.Entity<Organizacion>(entity =>
            {
                entity.HasKey(e => e.Ruc);

                entity.ToTable("ORGANIZACION");

                entity.Property(e => e.Ruc)
                    .ValueGeneratedNever()
                    .HasColumnName("RUC");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RAZON_SOCIAL");
            });

            modelBuilder.Entity<Postulacion>(entity =>
            {
                entity.HasKey(e => e.IdPostulacion);

                entity.ToTable("POSTULACION");

                entity.Property(e => e.IdPostulacion)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_POSTULACION");

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdOferta).HasColumnName("ID_OFERTA");

                entity.HasOne(d => d.DniNavigation)
                    .WithMany(p => p.Postulacion)
                    .HasForeignKey(d => d.Dni)
                    .HasConstraintName("FK_POSTULAC_REFERENCE_POSTULAN");

                entity.HasOne(d => d.IdOfertaNavigation)
                    .WithMany(p => p.Postulacion)
                    .HasForeignKey(d => d.IdOferta)
                    .HasConstraintName("FK_POSTULAC_REFERENCE_OFERTA");
            });

            modelBuilder.Entity<Postulante>(entity =>
            {
                entity.HasKey(e => e.Dni);

                entity.ToTable("POSTULANTE");

                entity.Property(e => e.Dni)
                    .ValueGeneratedNever()
                    .HasColumnName("DNI");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.FechaNac)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_NAC");

                entity.Property(e => e.IdLocalidad).HasColumnName("ID_LOCALIDAD");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Postulante)
                    .HasForeignKey(d => d.IdLocalidad)
                    .HasConstraintName("FK_POSTULAN_REFERENCE_LOCALIDA");
            });

            modelBuilder.Entity<Reclutador>(entity =>
            {
                entity.HasKey(e => e.Dni);

                entity.ToTable("RECLUTADOR");

                entity.Property(e => e.Dni)
                    .ValueGeneratedNever()
                    .HasColumnName("DNI");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Ruc).HasColumnName("RUC");

                entity.HasOne(d => d.RucNavigation)
                    .WithMany(p => p.Reclutador)
                    .HasForeignKey(d => d.Ruc)
                    .HasConstraintName("FK_RECLUTAD_REFERENCE_ORGANIZA");
            });

            modelBuilder.Entity<ReferenciaLaboral>(entity =>
            {
                entity.HasKey(e => e.IdReferencia);

                entity.ToTable("REFERENCIA_LABORAL");

                entity.Property(e => e.IdReferencia)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_REFERENCIA");

                entity.Property(e => e.Celular)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CELULAR");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Organizacion)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("ORGANIZACION");

                entity.Property(e => e.Puesto)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("PUESTO");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_USUARIO");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
