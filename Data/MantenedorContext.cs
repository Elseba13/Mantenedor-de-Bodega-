// Importa el espacio de nombres "Microsoft.EntityFrameworkCore" que contiene las clases necesarias para trabajar con Entity Framework Core
using Microsoft.EntityFrameworkCore;

// Importa el espacio de nombres "models" que contiene las clases de modelo necesarias
using models;

// Define una clase llamada "MantenedorContext" que hereda de DbContext
public class MantenedorContext : DbContext
{
    public MantenedorContext(DbContextOptions<MantenedorContext> opt): base(opt)
    {
        
    }

    public DbSet<Bodega> Bodegas { get; set; } 
    public DbSet<CentroDeSalud> CentroDeSaluds { get; set; } 
    public DbSet<Articulos> Articulos { get; set; } 
    public DbSet<Motivos> Motivos { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Inventario> Inventarios { get; set; }
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

        // Configura la clave primaria compuesta para la entidad Inventario
        modelBuilder.Entity<Inventario>()
            .HasKey(i => new { i.CodigoBodega, i.IdArticulo });

        // Configura la clave primaria para la entidad MovimientosInventario
        modelBuilder.Entity<MovimientosInventario>()
            .HasKey(m => m.IdMovimiento);
    }

    // Override del método OnConfiguring para configurar las opciones de DbContext
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configura el proveedor de base de datos y la cadena de conexión
        optionsBuilder.UseSqlServer("TuCadenaDeConexion");
    }
}
