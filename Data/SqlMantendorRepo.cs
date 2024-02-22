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

        // Métodos de creación de entidades en la base de datos

        public void CreateArticulos(Articulos cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Articulos.Add(cmd);
        }

        public void CreateInventario(Inventario cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException (nameof(cmd));
            }

            _context.Inventarios.Add(cmd);
        }

        public void CreateBodega(Bodega cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Bodegas.Add(cmd);
        }

        public void CreateCentroDeSalud(CentroDeSalud cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.CentroDeSaluds.Add(cmd);
        }


        public void CreateMotivos(Motivos cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Motivos.Add(cmd);
        }

        public void CreateMovimientosInventario(MovimientosInventario cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.MovimientosInventarios.Add(cmd);
        }

        public void CreateUsuarios(Usuarios cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Usuarios.Add(cmd);
        }

        public void CreateSolicitudDePedido(SolicitudDePedido cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException (nameof(cmd));
            }

            _context.SolicitudDePedidos.Add(cmd);
        }

        public void DeleteArticulos(Articulos cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Articulos.Remove(cmd);
        }

        public void DeleteInventario(Inventario cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException (nameof(cmd));
            }

            _context.Inventarios.Remove(cmd);
        }

        public void DeleteBodega(Bodega cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Bodegas.Remove(cmd);
        }

        public void DeleteCentroDeSalud(CentroDeSalud cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.CentroDeSaluds.Remove(cmd);
        }

        public void DeleteMotivos(Motivos cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Motivos.Remove(cmd);
        }

        public void DeleteMovimientoInventario(MovimientosInventario cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.MovimientosInventarios.Remove(cmd);

        }

        public void DeleteUsuarios(Usuarios cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Usuarios.Remove(cmd); 
        }

        public void DeleteSolicitudDePedido(SolicitudDePedido cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.SolicitudDePedidos.Remove(cmd);
        }

        // Métodos de obtención de todas las entidades

        public IEnumerable<Articulos> GetAllArticulos()
        {
            return _context.Articulos.ToList();
        }

        public IEnumerable<Inventario> GetAllInventarios()
        {
            return _context.Inventarios.ToList();
        }

        public IEnumerable<Bodega> GetAllBodegas()
        {
            return _context.Bodegas.Include(b => b.CentroDeSaluds).ToList();
        }

        public IEnumerable<CentroDeSalud> GetAllCentroSalud()
        {
            return _context.CentroDeSaluds.ToList();
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

        public IEnumerable<SolicitudDePedido> GetAllSolicitudDePedidos()
        {
            return _context.SolicitudDePedidos.ToList(); 
        }

        // Métodos de obtención de una entidad por su Id

        public Articulos GetArticulosById(int id)
        {
            return _context.Articulos.FirstOrDefault(a => a.IdArticulo == id);
        }

        public Bodega GetBodegaById(int id)
        {
            return _context.Bodegas.FirstOrDefault(b => b.CodigoBodega == id);
        }

        public CentroDeSalud GetCentroDeSaludById(int id)
        {
            return _context.CentroDeSaluds.FirstOrDefault(c => c.CodigoCentroSalud == id);
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

        public SolicitudDePedido GetSolicituDePedidoById(int id)
        {
            return _context.SolicitudDePedidos.FirstOrDefault(s => s.IdPedido == id); 
        }

        // Método para guardar cambios en la base de datos

        public bool saveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        // Métodos de actualización de entidades 

        public void UpadateMovimientosInventario(MovimientosInventario cmd)
        {

        }

        public void UpdateInventario(Inventario cmd)
        {

        }

        public void UpdateArticulos(Articulos cmd)
        {

        }

        public void UpdateBodega(Bodega cmd)
        {

        }

        public void UpdateCentroDeSalud(CentroDeSalud cmd)
        {

        }

        public void UpdateCentroDeSalud(Articulos cmd)
        {

        }

        public void UpdateMotivos(Motivos cmd)
        {

        }

        public void UpdateUsuarios(Usuarios cmd)
        {

        }

        public void UpdateSolicitudDePedido(SolicitudDePedido cmd)
        {

        }
    }
}