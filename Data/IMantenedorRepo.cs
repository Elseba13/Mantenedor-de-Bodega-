// Importa el espacio de nombres "models" que contiene las clases de modelo necesarias
using models;

// Define una interfaz llamada IMantenedorRepo en el espacio de nombres "Mantenedor.Data"
namespace Mantenedor.Data 
{
    // La interfaz IMantenedorRepo define los métodos que deben ser implementados por cualquier clase que la use
    public interface IMantenedorRepo
    {
        // Método para guardar los cambios en la base de datos
        bool saveChanges(); 

        // Métodos para obtener todas las Bodegas y una Bodega por su Id
        IEnumerable<Bodega> GetAllBodegas();
        Bodega GetBodegaById(int id);
        void CreateBodega(Bodega cmd); 
        void UpdateBodega(Bodega cmd);
        void DeleteBodega(Bodega cmd); 

        // Métodos para obtener todos los Centros de Salud y un Centro de Salud por su Id
        IEnumerable<CentroDeSalud> GetAllCentroSalud(); 
        CentroDeSalud GetCentroDeSaludById(int id); 
        void CreateCentroDeSalud(CentroDeSalud cmd);
        void UpdateCentroDeSalud(CentroDeSalud cmd);
        void DeleteCentroDeSalud(CentroDeSalud cmd); 

        // Métodos para obtener todos los Artículos y un Artículo por su Id
        IEnumerable<Articulos> GetAllArticulos(); 
        Articulos GetArticulosById(int id);
        void CreateArticulos(Articulos cmd); 
        void UpdateArticulos(Articulos cmd); 
        void DeleteArticulos(Articulos cmd);

        IEnumerable<Inventario> GetAllInventarios(); 
        void CreateInventario(Inventario cmd);
        void UpdateInventario(Inventario cmd);
        void DeleteInventario(Inventario cmd);

        // Métodos para obtener todos los Motivos y un Motivo por su Id
        IEnumerable<Motivos> GetAllMotivos(); 
        Motivos GetMotivosById(int id);
        void CreateMotivos(Motivos cmd); 
        void UpdateMotivos(Motivos cmd);
        void DeleteMotivos(Motivos cmd); 

        // Métodos para obtener todos los Usuarios y un Usuario por su Id
        IEnumerable<Usuarios> GetAllUsuarios();
        Usuarios GetUsuariosById(int id); 
        void CreateUsuarios(Usuarios cmd); 
        void UpdateUsuarios(Usuarios cmd); 
        void DeleteUsuarios(Usuarios cmd); 

        // Métodos para obtener todos los Movimientos de Inventario y un Movimiento de Inventario por su Id
        IEnumerable<MovimientosInventario> GetAllMovimientosInventario(); 
        MovimientosInventario GetMovimientosInventarioById(int id);
        void CreateMovimientosInventario(MovimientosInventario cmd);
        void UpadateMovimientosInventario(MovimientosInventario cmd); 
        void DeleteMovimientoInventario(MovimientosInventario cmd); 
    }
} 
