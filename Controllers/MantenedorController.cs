// Importa los espacios de nombres necesarios
using AutoMapper;
using Mantenedor.Data;
using Mantenedor.Dtos;
using Microsoft.AspNetCore.Mvc;
using models; 

namespace Mantenedor.Controllers
{

    [Route("api/mantenedor")] // Ruta base para las acciones del controlador
    [ApiController] // Indica que este controlador es de tipo API
    public class MantenedorController : ControllerBase
    {
        private readonly IMantenedorRepo _repository;
        private readonly IMapper _mapper;

        public MantenedorController(IMantenedorRepo repository ,IMapper mapper)
        {
            _repository = repository; 
            _mapper = mapper;
        }
        
        // Acción para obtener todas las Bodegas
        [HttpGet]
        public ActionResult<IEnumerable<Bodega>> GetAllBodegas()
        {
            var bodegaItems = _repository.GetAllBodegas();
            return Ok(bodegaItems);
        }

        // Acción para obtener una Bodega por su Id
        [HttpGet("{id}")]
        public ActionResult<MantenedorDtoBodega> GetBodegaById(int id)
        {
            var bodegaItems = _repository.GetBodegaById(id);
            if(bodegaItems != null)
            {
                return Ok(_mapper.Map<MantenedorDtoBodega>(bodegaItems));
            }
            return NotFound();
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
        public ActionResult<MantenedorDtoCentroDeSalud> GetCentroDeSaludById(int id)
        {
            var centroDeSaludItems = _repository.GetCentroDeSaludById(id);
            if(centroDeSaludItems != null){
                return Ok(_mapper.Map<MantenedorDtoCentroDeSalud>(centroDeSaludItems)); 
            }
            return NotFound();
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
        public ActionResult<MantenedorDtoArticulos> GetArticulosById(int id)
        {
            var articulosItems = _repository.GetArticulosById(id);
            if(articulosItems != null){
                return Ok(_mapper.Map<MantenedorDtoArticulos>(articulosItems));
            }
            return NotFound();
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
        public ActionResult<MantenedorDtoMotivos> GetMotivosById(int id)
        {
            var motivosItems = _repository.GetMotivosById(id);
            if(motivosItems != null){
                return Ok(_mapper.Map<MantenedorDtoMotivos>(motivosItems));
            }
            return NotFound();
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
        public ActionResult<MantenedorDtoUsuarios> GetUsuariosById(int id)
        {
            var usuariosItems = _repository.GetUsuariosById(id);
            if(usuariosItems != null){
                return Ok(_mapper.Map<MantenedorDtoUsuarios>(usuariosItems));
            }
            return NotFound();
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
        public ActionResult<MantenedorDtoInventario> GetInventariosById(int id)
        {
            var inventarioItems = _repository.GetInventarioById(id);
            if(inventarioItems != null){
                return Ok(_mapper.Map<MantenedorDtoInventario>(inventarioItems));
            }
            return NotFound();
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
        public ActionResult<MantenedorDtoMovimientosInventario> GetMovimientosInventarioById(int id)
        {
            var movimientosInventarioItems = _repository.GetMovimientosInventarioById(id);
            if(movimientosInventarioItems != null){
                return Ok(_mapper.Map<MantenedorDtoMovimientosInventario>(movimientosInventarioItems));
            }
            return NotFound(); 
        }
    }
}