// Namespace que contiene las clases de modelo
using System.ComponentModel.DataAnnotations;

namespace models
{
    // Clase que representa una Bodega
    public class Bodega
    {
        // Identificador único de la Bodega
        public int CodigoBodega { get; set; }

        // Descripción de la Bodega
        public string Descripcion { get; set; }

        // Relación con el Centro de Salud al que pertenece esta Bodega
        public CentroDeSalud CentroDeSaluds { get; set; }

        // Colección de artículos en esta Bodega
        public ICollection<Inventario> Articulos { get; set; } = new List<Inventario>();
    }

    // Clase que representa un Centro de Salud
    public class CentroDeSalud
    {
        // Identificador único del Centro de Salud
        public int CodigoCentroSalud { get; set; }

        // Nombre del Centro de Salud
        public string Nombre { get; set; }

        // Ciudad del Centro de Salud
        public string Ciudad { get; set; }

        // Región del Centro de Salud
        public string Region { get; set; }

        // Sucursal del Centro de Salud
        public string Sucursal { get; set; }

        // Colección de Bodegas asociadas a este Centro de Salud
        public ICollection<Bodega> bodegas { get; set; } = new List<Bodega>();
        public ICollection<ArancelCentro> arancelCentros { get; set; } = new List<ArancelCentro>();
        public ICollection<SolicitudDePedido> solicitudes { get; set; } = new List<SolicitudDePedido>();

    }

    // Clase que representa un Artículo
    public class ArancelCentro
    {
        public int Id { get; set; }

        // Clasificación del Artículo
        public string? Descripcion { get; set; }

        public CentroDeSalud centroDeSalud { get; set; }  

        public bool EstaActivo { get; set; } = false;

        public int IdGrupo { get; set; } 

        public int IdSubGrupo { get; set; } 

        public string NombreFantasia { get; set; }

        public int IdTipoArancel { get; set; }
             
        // Colección de inventarios donde se encuentra este Artículo
        public ICollection<Inventario> Bodegas { get; set; } = new List<Inventario>(); 
        public ICollection<SolicitudDePedido> solicitudDePedidos { get; set; } = new List<SolicitudDePedido>();
    }

    // Clase que representa un Inventario (relación entre Artículo y Bodega)
    public class Inventario
    {
        // Identificador del Artículo en el Inventario
        public int? IdArancel { get; set; }
        public ArancelCentro? arancelCentro { get; set; }

        // Identificador de la Bodega en el Inventario
        public int? CodigoBodega { get; set; }
        public Bodega? bodega { get; set; }

        //Actual del Artículo en la Bodega
        public int StockActual { get; set; }
    }

    // Clase que representa un Motivo
    public class Motivos
    {
        // Identificador único del Motivo
        public int IdMotivo { get; set; }

        // Descripción del Motivo
        public string Motivo { get; set; }

        // Colección de movimientos de inventario asociados a este Motivo
        public ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();
    }

    // Clase que representa un Usuario
    public class Usuarios
    {
        // Identificador único del Usuario
        public int IdUsuario { get; set; }

        // Rol del Usuario
        public string rol { get; set; }

        // Nombre del Usuario
        public string NombreUsuario { get; set; }

        // Colección de movimientos de inventario realizados por este Usuario
        public ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();
        public ICollection<SolicitudDePedido> solicitudDePedidos { get; set; } = new List<SolicitudDePedido>(); 
    }

    // Clase que representa un Movimiento de Inventario
    public class MovimientosInventario
    {
        // Identificador único del Movimiento de Inventario
        public int IdMovimiento { get; set; }

        // Cantidad del movimiento
        public int Cantidad { get; set; }

        // Fecha del movimiento
        public DateTime FechaDeMovimiento { get; set; }

        // Bodega de origen del movimiento
        public Bodega BodegaDeOrigen { get; set; }

        // Motivo del movimiento (puede ser nulo)
        public Motivos? Motivo { get; set; }

        // Bodega de destino del movimiento (puede ser nulo)
        public Bodega? BodegaDestino { get; set; }

        // Artículo involucrado en el movimiento
        public ArancelCentro Arancel { get; set; }

        // Usuario que realizó el movimiento
        public Usuarios Usuario { get; set; }

        public int StockInicialBodegaOrigen { get; set; }

        public int StockFinalBodegaOrigen { get; set; }

        public int StockInicialBodegaDestino { get; set; }

        public int StockFinalBodegaDestino { get; set; }
    }

    public class SolicitudDePedido
    {
        public int IdPedido { get; set; } 

        public DateTime FechaDePedido { get; set; }  

        public Usuarios Usuario { get; set; }

        public int Cantidad { get; set; }

        public ArancelCentro arancelCentro { get; set; }

        public CentroDeSalud centro { get; set; }
    }
}
