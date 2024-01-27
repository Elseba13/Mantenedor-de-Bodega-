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
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoBodega>>(bodegaItems));
        }

        // Acción para obtener una Bodega por su Id
        [HttpGet("{id}",Name = "GetBodegaById")] 
        public ActionResult<MantenedorDtoBodega> GetBodegaById(int id)
        {
            var bodegaItems = _repository.GetBodegaById(id);
            if(bodegaItems != null)
            {
                return Ok(_mapper.Map<MantenedorDtoBodega>(bodegaItems));
            }
            return NotFound();
        }
        
        [HttpPost]
        public ActionResult<MantenedorDtoBodega> CreateBodega(MantenedorCreateDtoBodega mantenedorCreateDtoBodega)
        {
            var bodegaModel = _mapper.Map<Bodega>(mantenedorCreateDtoBodega);
            _repository.CreateBodega(bodegaModel); 
            _repository.saveChanges(); 

            var mantenedorBodegaDto = _mapper.Map<MantenedorDtoBodega>(bodegaModel); 


            return CreatedAtRoute(nameof(GetBodegaById),new{id = mantenedorBodegaDto.CodigoBodega},mantenedorBodegaDto);
        }

        // Acción para obtener todas los Centros de Salud
        [HttpGet]
        public ActionResult<IEnumerable<CentroDeSalud>> GetAllCentroDeSalud()
        {
            var centroDeSaludItems = _repository.GetAllCentroSalud();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoCentroDeSalud>>(centroDeSaludItems));
        }

        // Acción para obtener un Centro de Salud por su Id
        [HttpGet("{id}",Name = "GetCentroDeSaludById")]
        public ActionResult<MantenedorDtoCentroDeSalud> GetCentroDeSaludById(int id)
        {
            var centroDeSaludItems = _repository.GetCentroDeSaludById(id);
            if(centroDeSaludItems != null){
                return Ok(_mapper.Map<MantenedorDtoCentroDeSalud>(centroDeSaludItems)); 
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MantenedorDtoCentroDeSalud> CreateCentroDeSalud(MantenedorCreateDtoCentroDeSalud mantenedorCreateDtoCentroDeSalud){
            var centroDeSaludModel = _mapper.Map<CentroDeSalud>(mantenedorCreateDtoCentroDeSalud); 
            _repository.CreateCentroDeSalud(centroDeSaludModel); 
            _repository.saveChanges(); 

            var mantenedorCentroDeSaludDto = _mapper.Map<MantenedorDtoCentroDeSalud>(centroDeSaludModel); 

            return CreatedAtRoute(nameof(GetCentroDeSaludById),new{id = mantenedorCentroDeSaludDto.CodigoCentroSalud},mantenedorCentroDeSaludDto);
        }

        // Acción para obtener todas los Artículos
        [HttpGet]
        public ActionResult<IEnumerable<Articulos>> GetAllArticulos()
        {
            var articulosItems = _repository.GetAllArticulos();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoArticulos>>(articulosItems));
        }

        // Acción para obtener un Artículo por su Id
        [HttpGet("{id}",Name ="GetArticulosById")]
        public ActionResult<MantenedorDtoArticulos> GetArticulosById(int id)
        {
            var articulosItems = _repository.GetArticulosById(id);
            if(articulosItems != null){
                return Ok(_mapper.Map<MantenedorDtoArticulos>(articulosItems));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MantenedorDtoArticulos> CreateArticulos(MantenedorCreateDtoArticulos mantenedorCreateDtoArticulos){
            var articulosModel = _mapper.Map<Articulos>(mantenedorCreateDtoArticulos); 
            _repository.CreateArticulos(articulosModel); 
            _repository.saveChanges(); 

            var mantenedorDtoArticulos = _mapper.Map<MantenedorDtoArticulos>(articulosModel);

            return CreatedAtRoute(nameof(GetArticulosById),new{id = mantenedorDtoArticulos.IdArticulo},mantenedorDtoArticulos);  
        }

        // Acción para obtener todas los Motivos
        [HttpGet]
        public ActionResult<IEnumerable<Motivos>> GetAllMotivos()
        {
            var motivosItems = _repository.GetAllMotivos();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoMotivos>>(motivosItems));
        }

        // Acción para obtener un Motivo por su Id
        [HttpGet("{id}",Name = "GetMotivosById")]
        public ActionResult<MantenedorDtoMotivos> GetMotivosById(int id)
        {
            var motivosItems = _repository.GetMotivosById(id);
            if(motivosItems != null){
                return Ok(_mapper.Map<MantenedorDtoMotivos>(motivosItems));
            }
            return NotFound();
        }

        [HttpPost]

        public ActionResult<MantenedorDtoMotivos> CreateMotivos(MantenedorCreateDtoMotivos mantenedorCreateDtoMotivos){
            var motivosModel = _mapper.Map<Motivos>(mantenedorCreateDtoMotivos);
            _repository.CreateMotivos(motivosModel);
            _repository.saveChanges(); 

            var mantenedorMotivos = _mapper.Map<MantenedorDtoMotivos>(motivosModel);

            return CreatedAtRoute(nameof(GetMotivosById),new{id = mantenedorMotivos.IdMotivo},mantenedorMotivos); 
        }

        // Acción para obtener todas los Usuarios
        [HttpGet]
        public ActionResult<IEnumerable<Usuarios>> GetAllUsuarios()
        {
            var usuariosItems = _repository.GetAllUsuarios();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoUsuarios>>(usuariosItems));
        }

        // Acción para obtener un Usuario por su Id
        [HttpGet("{id}",Name = "GetUsuariosById")]
        public ActionResult<MantenedorDtoUsuarios> GetUsuariosById(int id)
        {
            var usuariosItems = _repository.GetUsuariosById(id);
            if(usuariosItems != null){
                return Ok(_mapper.Map<MantenedorDtoUsuarios>(usuariosItems));
            }
            return NotFound();
        }

        [HttpPost] 
        public ActionResult<MantenedorDtoUsuarios> CreateUsuarios(MantenedorCreateDtoUsuarios mantenedorCreateDtoUsuarios){
            var usuariosModel = _mapper.Map<Usuarios>(mantenedorCreateDtoUsuarios); 
            _repository.CreateUsuarios(usuariosModel); 
            _repository.saveChanges();

            var mantendorDtoUsuarios = _mapper.Map<MantenedorDtoUsuarios>(usuariosModel);

            return CreatedAtRoute(nameof(GetUsuariosById),new{id = mantendorDtoUsuarios.IdUsuario},mantendorDtoUsuarios);
        }

        // Acción para obtener todas los Inventarios
        [HttpGet]
        public ActionResult<IEnumerable<Inventario>> GetAllInventarios()
        {
            var inventarioItems = _repository.GetAllInventario();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoInventario>>(inventarioItems));
        }

        // Acción para obtener un Inventario por su Id
        [HttpGet("{id}",Name ="GetInventariosById")]
        public ActionResult<MantenedorDtoInventario> GetInventariosById(int id)
        {
            var inventarioItems = _repository.GetInventarioById(id);
            if(inventarioItems != null){
                return Ok(_mapper.Map<MantenedorDtoInventario>(inventarioItems));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<MantenedorDtoInventario> CreateInventario(MantenedorCreateDtoInventario mantenedorCreateDtoInventario){
            var inventarioModel = _mapper.Map<Inventario>(mantenedorCreateDtoInventario);
            _repository.CreateInventario(inventarioModel); 
            _repository.saveChanges();

            var mantendorDtoInventario = _mapper.Map<MantenedorDtoInventario>(inventarioModel);

            return CreatedAtRoute(nameof(GetInventariosById),new{id = mantendorDtoInventario.IdInventario},mantendorDtoInventario); 
        }

        // Acción para obtener todas los Movimientos de Inventario
        [HttpGet]
        public ActionResult<IEnumerable<MovimientosInventario>> GetAllMovimientosInventario()
        {
            var movimientosInventarioItems = _repository.GetAllMovimientosInventario();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoMovimientosInventario>>(movimientosInventarioItems));
        }

        // Acción para obtener un Movimiento de Inventario por su Id
        [HttpGet("{id}",Name = "GetMovimientosInventarioById")]
        public ActionResult<MantenedorDtoMovimientosInventario> GetMovimientosInventarioById(int id)
        {
            var movimientosInventarioItems = _repository.GetMovimientosInventarioById(id);
            if(movimientosInventarioItems != null){
                return Ok(_mapper.Map<MantenedorDtoMovimientosInventario>(movimientosInventarioItems));
            }
            return NotFound(); 
        }

        [HttpPost] 
        public ActionResult<MantenedorDtoMovimientosInventario> CreateMovimientosInventario(MantenedorCreateDtoMovimientosInventario mantenedorCreateDtoMovimientosInventario){
            var movimientosModel = _mapper.Map<MovimientosInventario>(mantenedorCreateDtoMovimientosInventario);
            _repository.CreateMovimientosInventario(movimientosModel); 
            _repository.saveChanges(); 

            var mantenedorDtoMovimientosInventario = _mapper.Map<MantenedorDtoMovimientosInventario>(movimientosModel);

            return CreatedAtRoute(nameof(GetMovimientosInventarioById), new{id = mantenedorDtoMovimientosInventario.IdMovimiento},mantenedorDtoMovimientosInventario); 
        }
    }
}