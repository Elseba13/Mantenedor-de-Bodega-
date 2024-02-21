﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    [DbContext(typeof(MantenedorContext))]
    [Migration("20240221131915_migracion35")]
    partial class migracion35
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("NombreArticulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdArticulo");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("models.Bodega", b =>
                {
                    b.Property<int>("CodigoBodega")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoBodega"));

                    b.Property<int>("CentroDeSaludsCodigoCentroSalud")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoBodega");

                    b.HasIndex("CentroDeSaludsCodigoCentroSalud");

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
                    b.Property<int>("IdArticulos")
                        .HasColumnType("int");

                    b.Property<int>("CodigoBodega")
                        .HasColumnType("int");

                    b.Property<int>("StockActual")
                        .HasColumnType("int");

                    b.Property<int>("StockInicial")
                        .HasColumnType("int");

                    b.HasKey("IdArticulos", "CodigoBodega");

                    b.HasIndex("CodigoBodega");

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

                    b.HasKey("IdMotivo");

                    b.ToTable("Motivos");
                });

            modelBuilder.Entity("models.MovimientosInventario", b =>
                {
                    b.Property<int>("IdMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMovimiento"));

                    b.Property<int>("ArticuloIdArticulo")
                        .HasColumnType("int");

                    b.Property<int>("BodegaDeOrigenCodigoBodega")
                        .HasColumnType("int");

                    b.Property<int?>("BodegaDestinoCodigoBodega")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaDeMovimiento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MotivoIdMotivo")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdMovimiento");

                    b.HasIndex("ArticuloIdArticulo");

                    b.HasIndex("BodegaDeOrigenCodigoBodega");

                    b.HasIndex("BodegaDestinoCodigoBodega");

                    b.HasIndex("MotivoIdMotivo");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("MovimientosInventarios");
                });

            modelBuilder.Entity("models.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("models.Bodega", b =>
                {
                    b.HasOne("models.CentroDeSalud", "CentroDeSaluds")
                        .WithMany("bodegas")
                        .HasForeignKey("CentroDeSaludsCodigoCentroSalud")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CentroDeSaluds");
                });

            modelBuilder.Entity("models.Inventario", b =>
                {
                    b.HasOne("models.Bodega", "bodega")
                        .WithMany("Articulos")
                        .HasForeignKey("CodigoBodega")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("models.Articulos", "articulos")
                        .WithMany("Bodegas")
                        .HasForeignKey("IdArticulos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("articulos");

                    b.Navigation("bodega");
                });

            modelBuilder.Entity("models.MovimientosInventario", b =>
                {
                    b.HasOne("models.Articulos", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloIdArticulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("models.Bodega", "BodegaDeOrigen")
                        .WithMany()
                        .HasForeignKey("BodegaDeOrigenCodigoBodega")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("models.Bodega", "BodegaDestino")
                        .WithMany()
                        .HasForeignKey("BodegaDestinoCodigoBodega");

                    b.HasOne("models.Motivos", "Motivo")
                        .WithMany("MovimientosInventarios")
                        .HasForeignKey("MotivoIdMotivo");

                    b.HasOne("models.Usuarios", "Usuario")
                        .WithMany("MovimientosInventarios")
                        .HasForeignKey("UsuarioIdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("BodegaDeOrigen");

                    b.Navigation("BodegaDestino");

                    b.Navigation("Motivo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("models.Articulos", b =>
                {
                    b.Navigation("Bodegas");
                });

            modelBuilder.Entity("models.Bodega", b =>
                {
                    b.Navigation("Articulos");
                });

            modelBuilder.Entity("models.CentroDeSalud", b =>
                {
                    b.Navigation("bodegas");
                });

            modelBuilder.Entity("models.Motivos", b =>
                {
                    b.Navigation("MovimientosInventarios");
                });

            modelBuilder.Entity("models.Usuarios", b =>
                {
                    b.Navigation("MovimientosInventarios");
                });
#pragma warning restore 612, 618
        }
    }
}