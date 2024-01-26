using Microsoft.EntityFrameworkCore;
using models;

namespace Mantenedor.Data 
{
    public class SqlMantenedorRepo : IMantenedorRepo
    {
        private readonly MantenedorContext _context;

        public SqlMantenedorRepo(MantenedorContext context)
        {
            _context = context;
        }

        
        public IEnumerable<Articulos> GetAllArticulos()
        {
            return _context.Articulos.ToList();
        }

        public IEnumerable<Bodega> GetAllBodegas()
        {
            return _context.Bodegas.ToList();
        }

        public IEnumerable<CentroDeSalud> GetAllCentroSalud()
        {
            return _context.CentroDeSaluds.ToList();
        }

        public IEnumerable<Inventario> GetAllInventario()
        {
            return _context.Inventarios.ToList();
        }

        public IEnumerable<Motivos> GetAllMotivos()
        {
            return _context.Motivos.ToList();
        }

        public IEnumerable<MovimientosInventario> GetAllMovimientosInventario()
        {
            return _context.MovimientosInventarios.ToList();
        }

        public IEnumerable<Usuarios> GetAllUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Articulos GetArticulosById(int id)
        {
            return _context.Articulos.FirstOrDefault(a => a.IdArticulo == id ); 
        }

        public Bodega GetBodegaById(int id)
        {
            return _context.Bodegas.FirstOrDefault(b => b.CodigoBodega == id); 
        }

        public CentroDeSalud GetCentroDeSaludById(int id)
        {
            return _context.CentroDeSaluds.FirstOrDefault(c => c.CodigoCentroSalud == id );
        }

        public Inventario GetInventarioById(int id)
        {
            return _context.Inventarios.FirstOrDefault(i => i.IdInventario == id);
        }

        public Motivos GetMotivosById(int id)
        {
            return _context.Motivos.FirstOrDefault(m => m.IdMotivo == id); 
        }

        public MovimientosInventario GetMovimientosInventarioById(int id)
        {
            return _context.MovimientosInventarios.FirstOrDefault(m => m.IdMovimiento == id); 
        }

        public Usuarios GetUsuariosById(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id); 
        }
    }
}