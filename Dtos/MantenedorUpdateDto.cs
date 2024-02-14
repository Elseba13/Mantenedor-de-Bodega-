using models;

namespace Mantenedor.Dtos
{
    
    // Clase que representa una Bodega
    public class MantenedorUpdateDtoBodega
    {
        
        public int CodigoBodega { get; set; } // Identificador único de la Bodega
        public string Descripcion { get; set; } // Descripción de la Bodega
      
        public CentroDeSalud CentroDeSaluds { get; set; } 
    }

    // Clase que representa un Centro de Salud
    public class MantenedorUpdateDtoCentroDeSalud
    {
    
        public int CodigoCentroSalud { get; set; } // Identificador único del Centro de Salud
        public string Nombre { get; set; } // Nombre del Centro de Salud
        public string Ciudad { get; set; } // Ciudad del Centro de Salud
        public string Region { get; set; } // Región del Centro de Salud
        public string Sucursal { get; set; } // Sucursal del Centro de Salud

        

    }

    // Clase que representa un Artículo
    public class MantenedorUpdateDtoArticulos
    {
        
        public int IdArticulo { get; set; } // Identificador único del Artículo
        public string NombreArticulo { get; set; } // Nombre del Artículo
        public string ClasificacioArticulo { get; set; } // Clasificación del Artículo

        public ICollection<MantenedorUpdateDtoInventario> Inventarios { get; set; } 
    }

    // Clase que representa un Motivo
    public class MantenedorUpdateDtoMotivos
    {
        
        public int IdMotivo { get; set; } // Identificador único del Motivo
        public string Motivo { get; set; } // Descripción del Motivo
    }

    // Clase que representa un Usuario
    public class MantenedorUpdateDtoUsuarios
    {
        
        public int IdUsuario { get; set; } // Identificador único del Usuario
        public string rol { get; set; } // Rol del Usuario
        public string NombreUsuario { get; set; } // Nombre del Usuario
    }

    // Clase que representa un Inventario
    public class MantenedorUpdateDtoInventario
    {
        
        public int IdInventario { get; set; } //Identificador unico de Inventario 
        public int StockActual { get; set; } // Stock actual en el Inventari
        public int StockInicial { get; set; }

        public MantenedorUpdateDtoBodega Bodegas { get; set; } 

        
        

    }

    // Clase que representa un Movimiento de Inventario
    public class MantenedorUpdateDtoMovimientosInventario
    {
        
        public int IdMovimiento { get; set; } // Identificador único del Movimiento de Inventario
        public int Cantidad { get; set; } // Cantidad del movimiento
        public DateTime? FechaDeMovimiento { get; set; } // Fecha del movimiento

        public ICollection<MantenedorUpdateDtoMotivos> Motivos { get; set; }
        public ICollection<MantenedorUpdateDtoUsuarios> Usuarios { get; set; }
        public ICollection<MantenedorUpdateDtoBodega> Bodegas { get; set; }
        public ICollection<MantenedorUpdateDtoArticulos> Articulos { get; set; }
    }


}