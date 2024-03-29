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

    public DbSet<ArancelCentro> ArancelCentros { get; set; }    
 
    public DbSet<Inventario> Inventarios { get; set; }

    // DbSet para la entidad Motivos, que representa la tabla de motivos en la base de datos
    public DbSet<Motivos> Motivos { get; set; }

    // DbSet para la entidad Usuarios, que representa la tabla de usuarios en la base de datos
    public DbSet<Usuarios> Usuarios { get; set; }

    // DbSet para la entidad MovimientosInventario, que representa la tabla de movimientos de inventario en la base de datos
    public DbSet<MovimientosInventario> MovimientosInventarios { get; set; } 

    public DbSet<SolicitudDePedido> SolicitudDePedidos { get; set; }    


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
        modelBuilder.Entity<ArancelCentro>()
            .HasKey(c => c.Id); 

        //Configura la clave primaria compuesta de la entidad Inventario
        modelBuilder.Entity<Inventario>()
            .HasKey(i => new { i.IdArancel, i.CodigoBodega });

        //Configura la clave foranea de articulos en la entidad de Inventario
        modelBuilder.Entity<Inventario>()
            .HasOne(i => i.arancelCentro)
            .WithMany(a => a.Bodegas)
            .HasForeignKey(i => i.IdArancel)
            .OnDelete(DeleteBehavior.SetNull); 

        //Configura la clave foranea de bodegas en la entidad de Inventario
        modelBuilder.Entity<Inventario>()
            .HasOne(i => i.bodega)
            .WithMany(a => a.Articulos)
            .HasForeignKey(i => i.CodigoBodega)
            .OnDelete(DeleteBehavior.SetNull);

        // Configura la clave primaria para la entidad Motivos
        modelBuilder.Entity<Motivos>()
            .HasKey(m => m.IdMotivo);

        // Configura la clave primaria para la entidad Usuarios
        modelBuilder.Entity<Usuarios>()
            .HasKey(u => u.IdUsuario);

        // Configura la clave primaria para la entidad MovimientosInventario
        modelBuilder.Entity<MovimientosInventario>()
            .HasKey(m => m.IdMovimiento);

        modelBuilder.Entity<SolicitudDePedido>()
            .HasKey(s => s.IdPedido); 
    }
}