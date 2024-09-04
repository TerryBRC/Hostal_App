using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIHostalAPPMapeado.Models;

public partial class HostalDbContext : DbContext
{
    public HostalDbContext()
    {
    }

    public HostalDbContext(DbContextOptions<HostalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<GruposPermiso> GruposPermisos { get; set; }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.Identificacion, "identificacion_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.FechaRegistro)
                .HasMaxLength(6)
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(100)
                .HasColumnName("identificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("grupos");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<GruposPermiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("grupos_permisos");

            entity.HasIndex(e => e.GrupoId, "grupos_permisos_grupo_id_fk_grupos_id");

            entity.HasIndex(e => e.PermisoId, "grupos_permisos_permiso_id_fk_auth_perm");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GrupoId).HasColumnName("grupo_id");
            entity.Property(e => e.PermisoId).HasColumnName("permiso_id");

            entity.HasOne(d => d.Grupo).WithMany(p => p.GruposPermisos)
                .HasForeignKey(d => d.GrupoId)
                .HasConstraintName("grupos_permisos_grupo_id_fk_grupos_id");

            entity.HasOne(d => d.Permiso).WithMany(p => p.GruposPermisos)
                .HasForeignKey(d => d.PermisoId)
                .HasConstraintName("grupos_permisos_permiso_id_fk_auth_perm");
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("habitacion");

            entity.HasIndex(e => e.TipoHabitacionId, "habitacion_tipo_habitacion_id_fk_tipo_habitacion_id");

            entity.HasIndex(e => e.Numero, "numero_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CapacidadMaxima).HasColumnName("capacidad_maxima");
            entity.Property(e => e.Disponible).HasColumnName("disponible");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");
            entity.Property(e => e.PrecioPorNoche)
                .HasPrecision(10)
                .HasColumnName("precio_por_noche");
            entity.Property(e => e.TipoHabitacionId).HasColumnName("tipo_habitacion_id");

            entity.HasOne(d => d.TipoHabitacion).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.TipoHabitacionId)
                .HasConstraintName("habitacion_tipo_habitacion_id_fk_tipo_habitacion_id");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("permisos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(75)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reserva");

            entity.HasIndex(e => e.ClienteId, "reserva_cliente_id_fk_cliente_id");

            entity.HasIndex(e => e.HabitacionId, "reserva_habitacion_id_fk_habitacion_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'Activo'")
                .HasColumnType("enum('Activo','Cancelado','Pendiente','Finalizado','No Presentado','En Proceso')")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasMaxLength(6)
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaEntrada)
                .HasColumnType("date")
                .HasColumnName("fecha_entrada");
            entity.Property(e => e.FechaModificacion)
                .HasMaxLength(6)
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("date")
                .HasColumnName("fecha_salida");
            entity.Property(e => e.HabitacionId).HasColumnName("habitacion_id");
            entity.Property(e => e.NumeroHuespedes).HasColumnName("numero_huespedes");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("reserva_cliente_id_fk_cliente_id");

            entity.HasOne(d => d.Habitacion).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.HabitacionId)
                .HasConstraintName("reserva_habitacion_id_fk_habitacion_id");
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipo_habitacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.GrupoId, "fk_grupo_grupo_id_idx");

            entity.HasIndex(e => e.Usuario1, "usuario").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(150)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.GrupoId).HasColumnName("grupo_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .HasColumnName("password");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(150)
                .HasColumnName("usuario");

            entity.HasOne(d => d.Grupo).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.GrupoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_grupo_grupo_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
