﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    [DbContext(typeof(MantenedorContext))]
    partial class MantenedorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("models.Articulos", b =>
                {
                    b.Property<int>("IdArticulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArticulo"));

                    b.Property<string>("ClasificacioArticulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovimientosInventarioIdMovimiento")
                        .HasColumnType("int");

                    b.Property<string>("NombreArticulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdArticulo");

                    b.HasIndex("MovimientosInventarioIdMovimiento");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("models.Bodega", b =>
                {
                    b.Property<int>("CodigoBodega")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoBodega"));

                    b.Property<int>("CentroDeSalud")
                        .HasColumnType("int");

                    b.Property<int>("CentroDeSaludsCodigoCentroSalud")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InventarioIdInventario")
                        .HasColumnType("int");

                    b.Property<int?>("MovimientosInventarioIdMovimiento")
                        .HasColumnType("int");

                    b.HasKey("CodigoBodega");

                    b.HasIndex("CentroDeSaludsCodigoCentroSalud");

                    b.HasIndex("InventarioIdInventario");

                    b.HasIndex("MovimientosInventarioIdMovimiento");

                    b.ToTable("Bodegas");
                });

            modelBuilder.Entity("models.CentroDeSalud", b =>
                {
                    b.Property<int>("CodigoCentroSalud")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoCentroSalud"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sucursal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoCentroSalud");

                    b.ToTable("CentroDeSaluds");
                });

            modelBuilder.Entity("models.Inventario", b =>
                {
                    b.Property<int>("IdInventario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInventario"));

                    b.Property<int?>("ArticulosIdArticulo")
                        .HasColumnType("int");

                    b.Property<int>("StockActual")
                        .HasColumnType("int");

                    b.Property<int>("StockInicial")
                        .HasColumnType("int");

                    b.HasKey("IdInventario");

                    b.HasIndex("ArticulosIdArticulo");

                    b.ToTable("Inventarios");
                });

            modelBuilder.Entity("models.Motivos", b =>
                {
                    b.Property<int>("IdMotivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMotivo"));

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovimientosInventarioIdMovimiento")
                        .HasColumnType("int");

                    b.HasKey("IdMotivo");

                    b.HasIndex("MovimientosInventarioIdMovimiento");

                    b.ToTable("Motivos");
                });

            modelBuilder.Entity("models.MovimientosInventario", b =>
                {
                    b.Property<int>("IdMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMovimiento"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaDeMovimiento")
                        .HasColumnType("datetime2");

                    b.HasKey("IdMovimiento");

                    b.ToTable("MovimientosInventarios");
                });

            modelBuilder.Entity("models.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<int?>("MovimientosInventarioIdMovimiento")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("MovimientosInventarioIdMovimiento");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("models.Articulos", b =>
                {
                    b.HasOne("models.MovimientosInventario", null)
                        .WithMany("Articulos")
                        .HasForeignKey("MovimientosInventarioIdMovimiento");
                });

            modelBuilder.Entity("models.Bodega", b =>
                {
                    b.HasOne("models.CentroDeSalud", "CentroDeSaluds")
                        .WithMany()
                        .HasForeignKey("CentroDeSaludsCodigoCentroSalud")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("models.Inventario", null)
                        .WithMany("Bodegas")
                        .HasForeignKey("InventarioIdInventario");

                    b.HasOne("models.MovimientosInventario", null)
                        .WithMany("Bodegas")
                        .HasForeignKey("MovimientosInventarioIdMovimiento");

                    b.Navigation("CentroDeSaluds");
                });

            modelBuilder.Entity("models.Inventario", b =>
                {
                    b.HasOne("models.Articulos", null)
                        .WithMany("Inventarios")
                        .HasForeignKey("ArticulosIdArticulo");
                });

            modelBuilder.Entity("models.Motivos", b =>
                {
                    b.HasOne("models.MovimientosInventario", null)
                        .WithMany("Motivos")
                        .HasForeignKey("MovimientosInventarioIdMovimiento");
                });

            modelBuilder.Entity("models.Usuarios", b =>
                {
                    b.HasOne("models.MovimientosInventario", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("MovimientosInventarioIdMovimiento");
                });

            modelBuilder.Entity("models.Articulos", b =>
                {
                    b.Navigation("Inventarios");
                });

            modelBuilder.Entity("models.Inventario", b =>
                {
                    b.Navigation("Bodegas");
                });

            modelBuilder.Entity("models.MovimientosInventario", b =>
                {
                    b.Navigation("Articulos");

                    b.Navigation("Bodegas");

                    b.Navigation("Motivos");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
