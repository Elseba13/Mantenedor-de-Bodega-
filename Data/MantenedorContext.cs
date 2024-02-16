// Importa el espacio de nombres "Microsoft.EntityFrameworkCore" que contiene las clases necesarias para trabajar con Entity Framework Core
using Microsoft.EntityFrameworkCore;

// Importa el espacio de nombres "models" que contiene las clases de modelo necesarias
using models;

// Define una clase llamada "MantenedorContext" que hereda de DbContext
public class MantenedorContext : DbContext
{
    public MantenedorContext(DbContextOptions<MantenedorContext> options) : base(options)
    {
    }

    // DbSet para la entidad Bodega, que representa la tabla de bodegas en la base de datos
    public DbSet<Bodega> Bodegas { get; set; }

    // DbSet para la entidad CentroDeSalud, que representa la tabla de centros de salud en la base de datos
    public DbSet<CentroDeSalud> CentroDeSaluds { get; set; }

    // DbSet para la entidad Articulos, que representa la tabla de artículos en la base de datos
    public DbSet<Articulos> Articulos { get; set; }

    // DbSet para la entidad Motivos, que representa la tabla de motivos en la base de datos
    public DbSet<Motivos> Motivos { get; set; }

    // DbSet para la entidad Usuarios, que representa la tabla de usuarios en la base de datos
    public DbSet<Usuarios> Usuarios { get; set; }

    // DbSet para la entidad MovimientosInventario, que representa la tabla de movimientos de inventario en la base de datos
    public DbSet<MovimientosInventario> MovimientosInventarios { get; set; }


    // Override del método OnModelCreating para configurar las claves primarias compuestas
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura la clave primaria para la entidad Bodega
        modelBuilder.Entity<Bodega>()
            .HasKey(b => b.CodigoBodega);

        // Configura la clave primaria para la entidad CentroDeSalud
        modelBuilder.Entity<CentroDeSalud>()
            .HasKey(c => c.CodigoCentroSalud);

        // Configura la clave primaria para la entidad Articulos
        modelBuilder.Entity<Articulos>()
            .HasKey(a => a.IdArticulo);

        // Configura la clave primaria para la entidad Motivos
        modelBuilder.Entity<Motivos>()
            .HasKey(m => m.IdMotivo);

        // Configura la clave primaria para la entidad Usuarios
        modelBuilder.Entity<Usuarios>()
            .HasKey(u => u.IdUsuario);

        // Configura la clave primaria para la entidad MovimientosInventario
        modelBuilder.Entity<MovimientosInventario>()
            .HasKey(m => m.IdMovimiento);
    }
}