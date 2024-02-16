using models;

namespace Mantenedor.Dtos
{

    // Clase que representa una Bodega
    public class MantenedorDtoBodega
    {
        
        public int CodigoBodega { get; set; } // Identificador único de la Bodega
        public string Descripcion { get; set; } // Descripción de la Bodega
         
        public CentroDeSalud CentroDeSaluds { get; set; } 
    }

    // Clase que representa un Centro de Salud
    public class MantenedorDtoCentroDeSalud
    {
    
        public int CodigoCentroSalud { get; set; } // Identificador único del Centro de Salud
        public string Nombre { get; set; } // Nombre del Centro de Salud
        public string Ciudad { get; set; } // Ciudad del Centro de Salud
        public string Region { get; set; } // Región del Centro de Salud
        public string Sucursal { get; set; } // Sucursal del Centro de Salud 

        
    }

    // Clase que representa un Artículo
    public class MantenedorDtoArticulos
    {
        
        public int IdArticulo { get; set; } // Identificador único del Artículo
        public string NombreArticulo { get; set; } // Nombre del Artículo
        public string ClasificacioArticulo { get; set; } // Clasificación del Artículo
        public int StockInicial { get; set; }
        public int StockActual { get; set; }

        public Bodega Bodega { get; set; }
    }

    // Clase que representa un Motivo
    public class MantenedorDtoMotivos
    {
        
        public int IdMotivo { get; set; } // Identificador único del Motivo
        public string Motivo { get; set; } // Descripción del Motivo
    }

    // Clase que representa un Usuario
    public class MantenedorDtoUsuarios
    {
        
        public int IdUsuario { get; set; } // Identificador único del Usuario
        public string rol { get; set; } // Rol del Usuario
        public string NombreUsuario { get; set; } // Nombre del Usuario
    }

    // Clase que representa un Inventario

    // Clase que representa un Movimiento de Inventario
    public class MantenedorDtoMovimientosInventario
    {
        
        public int IdMovimiento { get; set; } // Identificador único del Movimiento de Inventario
        public int Cantidad { get; set; } // Cantidad del movimiento
        public DateTime? FechaDeMovimiento { get; set; } // Fecha del movimiento 
        public Bodega BodegaDeOrigen { get; set; }
        public Motivos Motivo { get; set; }
        public Bodega? BodegaDestino { get; set; }
        public Articulos Articulo { get; set; }
        public Usuarios Usuario { get; set; }
    }


}