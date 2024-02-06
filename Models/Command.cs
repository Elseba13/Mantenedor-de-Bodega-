// Namespace que contiene las clases de modelo
using System.ComponentModel.DataAnnotations;

namespace models
{
    // Clase que representa una Bodega
    public class Bodega
    {

        public int CodigoBodega { get; set; } // Identificador único de la Bodega
        public string Descripcion { get; set; } // Descripción de la Bodega
        public string CodigoCentroSalud { get; set; } // Código del Centro de Salud al que pertenece la Bodega
        public string Sucursal { get; set; } // Sucursal de la Bodega
    }

    // Clase que representa un Centro de Salud
    public class CentroDeSalud
    {

        public int CodigoCentroSalud { get; set; } // Identificador único del Centro de Salud
        public string Nombre { get; set; } // Nombre del Centro de Salud
        public string Ciudad { get; set; } // Ciudad del Centro de Salud
        public string Region { get; set; } // Región del Centro de Salud
        public string Sucursal { get; set; } // Sucursal del Centro de Salud
    }

    // Clase que representa un Artículo
    public class Articulos
    {

        public int IdArticulo { get; set; } // Identificador único del Artículo
        public string NombreArticulo { get; set; } // Nombre del Artículo
        public string ClasificacioArticulo { get; set; } // Clasificación del Artículo
    }

    // Clase que representa un Motivo
    public class Motivos
    {

        public int IdMotivo { get; set; } // Identificador único del Motivo
        public string Motivo { get; set; } // Descripción del Motivo
    }

    // Clase que representa un Usuario
    public class Usuarios
    {

        public int IdUsuario { get; set; } // Identificador único del Usuario
        public string rol { get; set; } // Rol del Usuario
        public string NombreUsuario { get; set; } // Nombre del Usuario
    }

    // Clase que representa un Inventario
    public class Inventario
    {

        public int IdInventario { get; set; } // Identificador único del Inventario
        public int IdArticulo { get; set; } // Identificador del Artículo en el Inventario
        public int CodigoBodega { get; set; } // Código de la Bodega a la que pertenece el Inventario
        public int StockActual { get; set; } // Stock actual en el Inventario
        public int StockInicial { get; set; } // Stock inicial en el Inventario
    }

    // Clase que representa un Movimiento de Inventario
    public class MovimientosInventario
    {

        public int IdMovimiento { get; set; } // Identificador único del Movimiento de Inventario
        public int Cantidad { get; set; } // Cantidad del movimiento
        public string FechaDeMovimiento { get; set; } // Fecha del movimiento
        public int IdMotivo { get; set; } // Identificador del Motivo del movimiento
        public int IdUsuario { get; set; } // Identificador del Usuario responsable del movimiento
        public int CodigoBodega { get; set; } // Código de la Bodega relacionada con el movimiento
        public int IdArticulo { get; set; } // Identificador del Artículo relacionado con el movimiento
    }
}