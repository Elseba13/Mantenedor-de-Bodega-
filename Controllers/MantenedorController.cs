// Importa los espacios de nombres necesarios
using AutoMapper;
using Azure;
using Mantenedor.Data;
using Mantenedor.Dtos;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly MantenedorContext _context;

        public MantenedorController(IMantenedorRepo repository ,IMapper mapper,MantenedorContext context)
        {
            _repository = repository; 
            _mapper = mapper;
            _context = context; 
        }
        
        // Acción para obtener todas las Bodegas
        [HttpGet("GetAllBodegas")]
        public ActionResult<IEnumerable<Bodega>> GetAllBodegas()
        {
            //var bodegaItems = new List<Bodega>();
            //bodegaItems.Add(new Bodega()); 
            
            var bodegaItems = _repository.GetAllBodegas();
             
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoBodega>>(bodegaItems));
        }

        // Acción para obtener una Bodega por su Id
        [HttpGet("GetBodegaById/{id}",Name = "GetBodegaById")] 
        public ActionResult<MantenedorDtoBodega> GetBodegaById(int id)
        {
            var bodegaItems = _repository.GetBodegaById(id);

            //var bodegaItems = new List<Bodega>();
            //bodegaItems.Add(new Bodega()); 

            if(bodegaItems != null)
            {
                return Ok(_mapper.Map<MantenedorDtoBodega>(bodegaItems));
            }

            return NotFound();
        }
        

        // Acción para crear una bodega 
        [HttpPost("CreateBodega")]
        public ActionResult<MantenedorDtoBodega> CreateBodega(int IdCentroDeSalud,MantenedorCreateDtoBodega mantenedorCreateDtoBodega)
        {
            var bodegaModel = _mapper.Map<Bodega>(mantenedorCreateDtoBodega);

            var centroSalud = _repository.GetCentroDeSaludById(IdCentroDeSalud); 
            
            if(centroSalud == null)
            {
                return NotFound(); 
            }

            bodegaModel.CentroDeSaluds = centroSalud; 

            _repository.CreateBodega(bodegaModel); 
            _repository.saveChanges(); 



            var mantenedorBodegaDto = _mapper.Map<MantenedorDtoBodega>(bodegaModel); 


            return CreatedAtRoute(nameof(GetBodegaById),new{id = mantenedorBodegaDto.CodigoBodega},mantenedorBodegaDto);
        }

        //Accion para borrar una bodega 
        [HttpDelete("DeleteBodega/{id}")]
        public ActionResult DeleteBodega(int id){
            var bodegaModelFromRepo = _repository.GetBodegaById(id); 
            
            if(bodegaModelFromRepo == null){
                return NotFound(); 
            }

            _repository.DeleteBodega(bodegaModelFromRepo); 
            _repository.saveChanges();

            return NoContent(); 

        }

        [HttpPost("CreateCentroDeSalud")]
        public ActionResult<MantenedorDtoCentroDeSalud> CreateBodega(MantenedorCreateDtoCentroDeSalud mantenedorCreateDtoCentroDeSalud)
        {
            var centroDeSaludModel = _mapper.Map<CentroDeSalud>(mantenedorCreateDtoCentroDeSalud);
            
            _repository.CreateCentroDeSalud(centroDeSaludModel);
            _repository.saveChanges();

            var mantenedorDtoCentroDeSalud = _mapper.Map<MantenedorDtoCentroDeSalud>(centroDeSaludModel);


            return CreatedAtRoute(nameof(GetCentroDeSaludById), new { id = mantenedorDtoCentroDeSalud.CodigoCentroSalud }, mantenedorDtoCentroDeSalud);
        }



        // Acción para obtener todas los Centros de Salud
        [HttpGet("GetAllCentroDeSalud")]
        public ActionResult<IEnumerable<CentroDeSalud>> GetAllCentroDeSalud()
        {
            var centroDeSaludItems = _repository.GetAllCentroSalud();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoCentroDeSalud>>(centroDeSaludItems));
        }

        // Acción para obtener un Centro de Salud por su Id
        [HttpGet("GetCentroDeSaludById/{id}",Name = "GetCentroDeSaludById")]
        public ActionResult<MantenedorDtoCentroDeSalud> GetCentroDeSaludById(int id)
        {
            var centroDeSaludItems = _repository.GetCentroDeSaludById(id);
            if(centroDeSaludItems != null){
                return Ok(_mapper.Map<MantenedorDtoCentroDeSalud>(centroDeSaludItems)); 
            }
            return NotFound();
        }


        // Acción para obtener todas los Artículos
        [HttpGet("GetAllArticulos")]
        public ActionResult<IEnumerable<Articulos>> GetAllArticulos()
        {
            var articulosItems = _repository.GetAllArticulos();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoArticulos>>(articulosItems));
        }

        // Acción para obtener un Artículo por su Id
        [HttpGet("GetArticulosById/{id}",Name ="GetArticulosById")]
        public ActionResult<MantenedorDtoArticulos> GetArticulosById(int id)
        {
            var articulosItems = _repository.GetArticulosById(id);
            if(articulosItems != null){
                return Ok(_mapper.Map<MantenedorDtoArticulos>(articulosItems));
            }
            return NotFound();
        }

        // Acción para crear una bodega 
        [HttpPost("CreateArticulos")]
        public ActionResult<MantenedorDtoArticulos> CreateArticulo(int IdBodega,int stock,MantenedorCreateDtoArticulos mantenedorCreateDtoArticulos)
        {
            var articulosModel = _mapper.Map<Articulos>(mantenedorCreateDtoArticulos);

            var bodega = _repository.GetBodegaById(IdBodega);

            
            if (bodega == null)
            {
                return NotFound("No se encontro la bodega");
            }
            
            articulosModel.StockInicial = stock;
            articulosModel.StockActual = stock;
            articulosModel.Bodega = bodega;
          
            
            _repository.CreateArticulos(articulosModel);
            _repository.saveChanges();

            var mantenedorArticulosDto = _mapper.Map<MantenedorDtoArticulos>(articulosModel);


            return CreatedAtRoute(nameof(GetArticulosById), new { id = mantenedorArticulosDto.IdArticulo }, mantenedorArticulosDto);
        }



        //Accion para Actualizar articulos 
        [HttpPut("UpdateArticulos/{id}")]
        public ActionResult UpdateArticulos(int id, MantenedorUpdateDtoArticulos mantenedorUpdateDtoArticulos){
            var articulosModelFromRepo = _repository.GetArticulosById(id); 
            if(articulosModelFromRepo == null){
                return NotFound(); 
            }

            _mapper.Map(mantenedorUpdateDtoArticulos,articulosModelFromRepo); 

            _repository.UpdateArticulos(articulosModelFromRepo);

            _repository.saveChanges(); 

            return NoContent();  
        }

        //Accion para actulizar parcialmente articulos 
        [HttpPatch("PartialArticulosUpdate/{id}")]
        public ActionResult PartialArticulosUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoArticulos> jsonPatchDocument){
            
            var articulosModelFromRepo = _repository.GetArticulosById(id);
            
            if( articulosModelFromRepo == null){
                return NotFound(); 
            }

            var articulosToPatch = _mapper.Map<MantenedorUpdateDtoArticulos>(articulosModelFromRepo); 

            jsonPatchDocument.ApplyTo(articulosToPatch,ModelState);  

            if(!TryValidateModel(articulosToPatch)){
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(articulosToPatch,articulosModelFromRepo); 

            _repository.UpdateArticulos(articulosModelFromRepo); 

            _repository.saveChanges(); 

            return NoContent(); 
        }


        //Accion para eliminar articulos por ID 
        [HttpDelete("DeleteArticulos/{id}") ]

        public ActionResult DeleteArticulos(int id){
            
            var articulosModelFromRepo = _repository.GetArticulosById(id); 
            
            if(articulosModelFromRepo == null){
                return NotFound(); 
            }

            _repository.DeleteArticulos(articulosModelFromRepo); 
            _repository.saveChanges();

            return NoContent(); 
        }

        // Acción para obtener todas los Motivos
        [HttpGet("GetAllMotivos")]
        public ActionResult<IEnumerable<Motivos>> GetAllMotivos()
        {
            var motivosItems = _repository.GetAllMotivos();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoMotivos>>(motivosItems));
        }

        // Acción para obtener un Motivo por su Id
        [HttpGet("GetMotivosById/{id}",Name = "GetMotivosById")]
        public ActionResult<MantenedorDtoMotivos> GetMotivosById(int id)
        {
            var motivosItems = _repository.GetMotivosById(id);
            if(motivosItems != null){
                return Ok(_mapper.Map<MantenedorDtoMotivos>(motivosItems));
            }
            return NotFound();
        }

        //Accion para crear motivos 
        [HttpPost("CreateMotivos")]

        public ActionResult<MantenedorDtoMotivos> CreateMotivos(MantenedorCreateDtoMotivos mantenedorCreateDtoMotivos){
            var motivosModel = _mapper.Map<Motivos>(mantenedorCreateDtoMotivos);
            
            _repository.CreateMotivos(motivosModel);
            _repository.saveChanges(); 

            var mantenedorMotivos = _mapper.Map<MantenedorDtoMotivos>(motivosModel);

            return CreatedAtRoute(nameof(GetMotivosById),new{id = mantenedorMotivos.IdMotivo},mantenedorMotivos); 
        }

        //Accion para actulizar los motivos por ID 
        [HttpPut("UpdateMotivos/{id}")]
        public ActionResult UpdateMotivos(int id, MantenedorUpdateDtoMotivos mantenedorUpdateDtoMotivos){
            var motivosModelFromRepo = _repository.GetMotivosById(id); 
            if(motivosModelFromRepo == null){
                return NotFound(); 
            }
            
            _mapper.Map(mantenedorUpdateDtoMotivos,motivosModelFromRepo); 

            _repository.UpdateMotivos(motivosModelFromRepo); 

            _repository.saveChanges(); 

            return NotFound(); 

        }

        //Acción para actuliazar parcialmente los motivos por ID
        [HttpPatch("PartialMotivosUpdate/{id}")]
        public ActionResult PartialMotivosUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoMotivos> jsonPatchDocument){
            
            var motivosModelFromRepo = _repository.GetMotivosById(id); 
            
            if( motivosModelFromRepo == null){
                return NotFound(); 
            }

            var motivosToPatch = _mapper.Map<MantenedorUpdateDtoMotivos>(motivosModelFromRepo); 

            jsonPatchDocument.ApplyTo(motivosToPatch,ModelState);  

            if(!TryValidateModel(motivosToPatch)){
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(motivosToPatch,motivosModelFromRepo); 

            _repository.UpdateMotivos(motivosModelFromRepo); 

            _repository.saveChanges(); 

            return NoContent(); 
        }

        //Accion para eliminar un motivo Por ID
        [HttpDelete("DeleteMotivos/{id}")]
        public ActionResult DeleteMotivos(int id){
            
            var motivosModelFromRepo = _repository.GetMotivosById(id); 
            
            if(motivosModelFromRepo == null){
                return NotFound(); 
            }

            _repository.DeleteMotivos(motivosModelFromRepo); 
            _repository.saveChanges();

            return NoContent(); 
        }

        // Acción para obtener todas los Usuarios
        [HttpGet("GetAllUsuarios")]
        public ActionResult<IEnumerable<Usuarios>> GetAllUsuarios()
        {
            var usuariosItems = _repository.GetAllUsuarios();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoUsuarios>>(usuariosItems));
        }

        // Acción para obtener un Usuario por su Id
        [HttpGet("GetUsuariosById/{id}",Name = "GetUsuariosById")]
        public ActionResult<MantenedorDtoUsuarios> GetUsuariosById(int id)
        {
            var usuariosItems = _repository.GetUsuariosById(id);
            if(usuariosItems != null){
                return Ok(_mapper.Map<MantenedorDtoUsuarios>(usuariosItems));
            }
            return NotFound();
        }

        [HttpPost("CreateUsuarios")]

        public ActionResult<MantenedorDtoUsuarios> CreateUsuario(MantenedorCreateDtoUsuarios mantenedorCreateDtoUsuarios)
        {
            var usuariosModel = _mapper.Map<Usuarios>(mantenedorCreateDtoUsuarios);
            _repository.CreateUsuarios(usuariosModel);
            _repository.saveChanges();

            var mantenedorUsuarios = _mapper.Map<MantenedorDtoUsuarios>(usuariosModel);

            return CreatedAtRoute(nameof(GetUsuariosById), new { id = mantenedorUsuarios.IdUsuario }, mantenedorUsuarios);
        }

        //Accion para aumentar stock de un inventario asociado a un articulo
        [HttpPut("AumentoDeStock/{id}")]
        public ActionResult AumentoDeStock (int id, int stock)
        {
            var articuloModel = _repository.GetArticulosById(id);
            if(articuloModel == null)
            {
                return NotFound("El Articulo no fue encontrado");
            }

            articuloModel.StockActual += stock;

            _repository.UpdateArticulos(articuloModel); 
            _repository.saveChanges();

            return Ok(); 

        }

        //Acción para disminuir stock de un inventario asociado a un articulo
        [HttpPut("DisminucionDeStock/{id}")]
        public ActionResult DisminucionDeStock(int id, int stock, int idUsuario) 
        {
            var articulosModel = _repository.GetArticulosById(id);
            var usuarioModel = _repository.GetUsuariosById(idUsuario);
            var motivoModel = _repository.GetMotivosById(2);
            var bodegaModel = _repository.GetBodegaById(articulosModel.Bodega.CodigoBodega); 

            if(usuarioModel == null)
            {
                return NotFound("El usuario ingresado no existe");
            }

            if(articulosModel == null)
            {
                return NotFound("El articulo ingresado no existe"); 
            }

            if(articulosModel.StockActual < stock)
            {
                return BadRequest("La cantidad a disminuir excede el stock actual"); 
            }

            var movimientosInventarioModel = new MovimientosInventario
            {
                Cantidad = stock,
                FechaDeMovimiento = DateTime.Now,
                Motivo = motivoModel, 
                BodegaDeOrigen = bodegaModel, 
                BodegaDestino = null,
                Articulo = articulosModel,
                Usuario = usuarioModel
            };

            articulosModel.StockActual -= stock;
            _repository.UpdateArticulos(articulosModel);
            _repository.CreateMovimientosInventario(movimientosInventarioModel);
            _repository.saveChanges();

            return Ok(); 

        }
            
        // Acción para obtener todas los Movimientos de Inventario
        [HttpGet("GetAllMovimientosInventario")]
        public ActionResult<IEnumerable<MovimientosInventario>> GetAllMovimientosInventario()
        {
            var movimientosInventarioItems = _repository.GetAllMovimientosInventario();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoMovimientosInventario>>(movimientosInventarioItems));
        }

        // Acción para obtener un Movimiento de Inventario por su Id
        [HttpGet("GetMovimientosInventarioById/{id}",Name = "GetMovimientosInventarioById")]
        public ActionResult<MantenedorDtoMovimientosInventario> GetMovimientosInventarioById(int id)
        {
            var movimientosInventarioItems = _repository.GetMovimientosInventarioById(id);
            if(movimientosInventarioItems != null){
                return Ok(_mapper.Map<MantenedorDtoMovimientosInventario>(movimientosInventarioItems));
            }
            return NotFound(); 
        }

        //Accion para crear los movimeinto de inventario 
        [HttpPost("CreateMovimientosInventario")] 
        public ActionResult<MantenedorDtoMovimientosInventario> CreateMovimientosInventario(MantenedorCreateDtoMovimientosInventario mantenedorCreateDtoMovimientosInventario){
            var movimientosModel = _mapper.Map<MovimientosInventario>(mantenedorCreateDtoMovimientosInventario);
            _repository.CreateMovimientosInventario(movimientosModel); 
            _repository.saveChanges(); 

            var mantenedorDtoMovimientosInventario = _mapper.Map<MantenedorDtoMovimientosInventario>(movimientosModel);

            return CreatedAtRoute(nameof(GetMovimientosInventarioById), new{id = mantenedorDtoMovimientosInventario.IdMovimiento},mantenedorDtoMovimientosInventario); 
        }


        //Accion para actualizar los movimientos de inventario por ID 
        [HttpPut("UpdateMovimientosInventario/{id}")]

        public ActionResult UpdateMovimientosInventario(int id, MantenedorUpdateDtoMovimientosInventario mantenedorUpdateDtoMovimientosInventario){
            var movimientosInventarioModelFromRepo = _repository.GetMovimientosInventarioById(id); 
            if(movimientosInventarioModelFromRepo == null){
                return NotFound(); 
            }

            _mapper.Map(mantenedorUpdateDtoMovimientosInventario,movimientosInventarioModelFromRepo); 

            _repository.UpadateMovimientosInventario(movimientosInventarioModelFromRepo);

            _repository.saveChanges();  

            return NotFound(); 

        }


        //Accion para actualizar parcialmente los movimientos de inventario por ID 
        [HttpPatch("PartialMovimientosInventarioUpdate/{id}")]
        public ActionResult PartialMovimientosInventarioUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoMovimientosInventario> jsonPatchDocument){
            
            var movimientoInventarioModelFromRepo = _repository.GetMovimientosInventarioById(id);
            
            if( movimientoInventarioModelFromRepo == null){
                return NotFound(); 
            }

            var movimientosToPatch = _mapper.Map<MantenedorUpdateDtoMovimientosInventario>(movimientoInventarioModelFromRepo); 

            jsonPatchDocument.ApplyTo(movimientosToPatch,ModelState);  

            if(!TryValidateModel(movimientosToPatch)){
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(movimientosToPatch,movimientoInventarioModelFromRepo); 

            _repository.UpadateMovimientosInventario(movimientoInventarioModelFromRepo); 

            _repository.saveChanges(); 

            return NoContent(); 
        }

    }

    
}