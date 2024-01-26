// Importa los espacios de nombres necesarios
using Mantenedor.Data;
using Microsoft.AspNetCore.Mvc;
using models; 

namespace Mantenedor.Controllers
{

    [Route("api/mantenedor")] // Ruta base para las acciones del controlador
    [ApiController] // Indica que este controlador es de tipo API
    public class MantenedorController : ControllerBase
    {
        private readonly IMantenedorRepo _repository;

        public MantenedorController(IMantenedorRepo repository)
        {
            _repository = repository; 
        }
        
        //private readonly MockMantenedorRepo _repository = new MockMantenedorRepo();

        // Acción para obtener todas las Bodegas
        [HttpGet]
        public ActionResult<IEnumerable<Bodega>> GetAllBodegas()
        {
            var bodegaItems = _repository.GetAllBodegas();
            return Ok(bodegaItems);
        }

        // Acción para obtener una Bodega por su Id
        [HttpGet("{id}")]
        public ActionResult<Bodega> GetBodegaById(int id)
        {
            var bodegaItems = _repository.GetBodegaById(id);
            return Ok(bodegaItems);
        }

        // Acción para obtener todas los Centros de Salud
        [HttpGet]
        public ActionResult<IEnumerable<CentroDeSalud>> GetAllCentroDeSalud()
        {
            var centroDeSaludItems = _repository.GetAllCentroSalud();
            return Ok(centroDeSaludItems);
        }

        // Acción para obtener un Centro de Salud por su Id
        [HttpGet("{id}")]
        public ActionResult<CentroDeSalud> GetCentroDeSaludById(int id)
        {
            var centroDeSaludItems = _repository.GetCentroDeSaludById(id);
            return Ok(centroDeSaludItems);
        }

        // Acción para obtener todas los Artículos
        [HttpGet]
        public ActionResult<IEnumerable<Articulos>> GetAllArticulos()
        {
            var articulosItems = _repository.GetAllArticulos();
            return Ok(articulosItems);
        }

        // Acción para obtener un Artículo por su Id
        [HttpGet("{id}")]
        public ActionResult<Articulos> GetArticulosById(int id)
        {
            var articulosItems = _repository.GetArticulosById(id);
            return Ok(articulosItems);
        }

        // Acción para obtener todas los Motivos
        [HttpGet]
        public ActionResult<IEnumerable<Motivos>> GetAllMotivos()
        {
            var motivosItems = _repository.GetAllMotivos();
            return Ok(motivosItems);
        }

        // Acción para obtener un Motivo por su Id
        [HttpGet("{id}")]
        public ActionResult<Motivos> GetMotivosById(int id)
        {
            var motivosItems = _repository.GetMotivosById(id);
            return Ok(motivosItems);
        }

        // Acción para obtener todas los Usuarios
        [HttpGet]
        public ActionResult<IEnumerable<Usuarios>> GetAllUsuarios()
        {
            var usuariosItems = _repository.GetAllUsuarios();
            return Ok(usuariosItems);
        }

        // Acción para obtener un Usuario por su Id
        [HttpGet("{id}")]
        public ActionResult<Usuarios> GetUsuariosById(int id)
        {
            var usuariosItems = _repository.GetUsuariosById(id);
            return Ok(usuariosItems);
        }

        // Acción para obtener todas los Inventarios
        [HttpGet]
        public ActionResult<IEnumerable<Inventario>> GetAllInventarios()
        {
            var inventarioItems = _repository.GetAllInventario();
            return Ok(inventarioItems);
        }

        // Acción para obtener un Inventario por su Id
        [HttpGet("{id}")]
        public ActionResult<Inventario> GetInventariosById(int id)
        {
            var inventarioItems = _repository.GetInventarioById(id);
            return Ok(inventarioItems);
        }

        // Acción para obtener todas los Movimientos de Inventario
        [HttpGet]
        public ActionResult<IEnumerable<MovimientosInventario>> GetAllMovimientosInventario()
        {
            var movimientosInventarioItems = _repository.GetAllMovimientosInventario();
            return Ok(movimientosInventarioItems);
        }

        // Acción para obtener un Movimiento de Inventario por su Id
        [HttpGet("{id}")]
        public ActionResult<MovimientosInventario> GetMovimientosInventarioById(int id)
        {
            var movimientosInventarioItems = _repository.GetMovimientosInventarioById(id);
            return Ok(movimientosInventarioItems);
        }
    }
}