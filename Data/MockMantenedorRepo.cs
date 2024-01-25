// Importa el espacio de nombres "models" que contiene las clases de modelo necesarias
using models;

// Define una clase llamada "MockMantenedorRepo" en el espacio de nombres "Mantenedor.Data"
namespace Mantenedor.Data
{
    // Implementa la interfaz "IMantenedorRepo" y proporciona una implementación ficticia
    public class MockMantenedorRepo : IMantenedorRepo
    {
        // Métodos para obtener todas las entidades (simulando acceso a datos, pero lanzando una excepción NotImplementedException)
        public IEnumerable<Articulos> GetAppArticulos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bodega> GetAppBodegas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CentroDeSalud> GetAppCentroSalud()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventario> GetAppInventario()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Motivos> GetAppMotivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovimientosInventario> GetAppMovimientosInventario()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuarios> GetAppUsuarios()
        {
            throw new NotImplementedException();
        }

        // Métodos para obtener una entidad por su Id (simulando acceso a datos, pero lanzando una excepción NotImplementedException)
        public Articulos GetArticulosById(int id)
        {
            throw new NotImplementedException();
        }

        public Bodega GetBodegaById(int id)
        {
            throw new NotImplementedException();
        }

        public CentroDeSalud GetCentroDeSaludById(int id)
        {
            throw new NotImplementedException();
        }

        public Inventario GetInventarioById(int id)
        {
            throw new NotImplementedException();
        }

        public Motivos GetMotivosById(int id)
        {
            throw new NotImplementedException();
        }

        public MovimientosInventario GetMovimientosInventarioById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuarios GetUsuariosById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
