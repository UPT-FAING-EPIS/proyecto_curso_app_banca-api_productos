using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NETCORE6.Models;

public partial class BancoProductosContext : DbContext
{
    public BancoProductosContext()
    {
    }

    public BancoProductosContext(DbContextOptions<BancoProductosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClientesProducto> ClientesProductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83F12427F13");

            entity.HasIndex(e => e.Email, "UQ__Clientes__AB6E6164F809DF21").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<ClientesProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83F02946E15");

            entity.ToTable("Clientes_Productos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_vencimiento");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.LimiteCredito)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("limite_credito");
            entity.Property(e => e.Prima)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("prima");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("saldo");
            entity.Property(e => e.TasaInteres)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("tasa_interes");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClientesProductos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Clientes___id_cl__29572725");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ClientesProductos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Clientes___id_pr__2A4B4B5E");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3213E83F1BECC438");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transacc__3213E83F080043DD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaTransaccion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_transaccion");
            entity.Property(e => e.IdClienteProductoDestino).HasColumnName("id_cliente_producto_destino");
            entity.Property(e => e.IdClienteProductoOrigen).HasColumnName("id_cliente_producto_origen");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.TipoTransaccion)
                .HasMaxLength(50)
                .HasColumnName("tipo_transaccion");

            entity.HasOne(d => d.IdClienteProductoDestinoNavigation).WithMany(p => p.TransaccioneIdClienteProductoDestinoNavigations)
                .HasForeignKey(d => d.IdClienteProductoDestino)
                .HasConstraintName("FK__Transacci__id_cl__2E1BDC42");

            entity.HasOne(d => d.IdClienteProductoOrigenNavigation).WithMany(p => p.TransaccioneIdClienteProductoOrigenNavigations)
                .HasForeignKey(d => d.IdClienteProductoOrigen)
                .HasConstraintName("FK__Transacci__id_cl__2D27B809");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
