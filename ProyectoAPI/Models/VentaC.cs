using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoAPI.Models;

public partial class VentaC : DbContext
{
    public VentaC()
    {
    }

    public VentaC(DbContextOptions<VentaC> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCategorium> TbCategoria { get; set; }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbDetalleventum> TbDetalleventa { get; set; }

    public virtual DbSet<TbProducto> TbProductos { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<TbVentum> TbVenta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=sql5106.site4now.net;User ID=db_a9b96c_aldoalegria27_admin; Password=Antony27; Initial Catalog=db_a9b96c_aldoalegria27 ;Integrated Security=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<TbCategorium>(entity =>
        {
            entity.HasKey(e => e.CodCategoria).HasName("PK__TB_CATEG__5A4D9907D077F012");

            entity.ToTable("TB_CATEGORIA");

            entity.Property(e => e.CodCategoria)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_CATEGORIA");
            entity.Property(e => e.NomCat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_CAT");
        });

        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.CodCliente).HasName("PK__TB_CLIEN__8112345F55F774B2");

            entity.ToTable("TB_CLIENTE");

            entity.Property(e => e.CodCliente)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_CLIENTE");
            entity.Property(e => e.ApeCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APE_CLI");
            entity.Property(e => e.DirCli)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIR_CLI");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DNI");
            entity.Property(e => e.NomCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_CLI");
        });

        modelBuilder.Entity<TbDetalleventum>(entity =>
        {
            entity.HasKey(e => new { e.CodVenta, e.CodProducto }).HasName("PK__TB_DETAL__77752C1E1AE4300E");

            entity.ToTable("TB_DETALLEVENTA");

            entity.Property(e => e.CodVenta)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_VENTA");
            entity.Property(e => e.CodProducto)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_PRODUCTO");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CodProductoNavigation).WithMany(p => p.TbDetalleventa)
                .HasForeignKey(d => d.CodProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__COD_P__4222D4EF");

            entity.HasOne(d => d.CodVentaNavigation).WithMany(p => p.TbDetalleventa)
                .HasForeignKey(d => d.CodVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__COD_V__412EB0B6");
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.CodProducto).HasName("PK__TB_PRODU__8DF7FD2DD174BB8B");

            entity.ToTable("TB_PRODUCTO");

            entity.Property(e => e.CodProducto)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_PRODUCTO");
            entity.Property(e => e.CodCategoria)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_CATEGORIA");
            entity.Property(e => e.EstaProducto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ESTA_PRODUCTO");
            entity.Property(e => e.Imagenes)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IMAGENES");
            entity.Property(e => e.NomProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOM_PRODUCTO");
            entity.Property(e => e.PreProducto)
                .HasColumnType("money")
                .HasColumnName("PRE_PRODUCTO");
            entity.Property(e => e.StkProducto).HasColumnName("STK_PRODUCTO");

            entity.HasOne(d => d.CodCategoriaNavigation).WithMany(p => p.TbProductos)
                .HasForeignKey(d => d.CodCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_PRODUC__COD_C__4316F928");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TB_USUAR__3214EC0756F15AB3");

            entity.ToTable("TB_USUARIO");

            entity.Property(e => e.UsuClave)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.UsuNombre)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbVentum>(entity =>
        {
            entity.HasKey(e => e.CodVenta).HasName("PK__TB_VENTA__BFAA53CCED191EAA");

            entity.ToTable("TB_VENTA");

            entity.Property(e => e.CodVenta)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_VENTA");
            entity.Property(e => e.CodCliente)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_CLIENTE");
            entity.Property(e => e.EstadoVenta)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ESTADO_VENTA");
            entity.Property(e => e.FecVenta)
                .HasColumnType("date")
                .HasColumnName("FEC_VENTA");
            entity.Property(e => e.TotalVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TOTAL_VENTA");

            entity.HasOne(d => d.CodClienteNavigation).WithMany(p => p.TbVenta)
                .HasForeignKey(d => d.CodCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_VENTA__COD_CL__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
