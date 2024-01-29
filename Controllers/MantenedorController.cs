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

        public MantenedorController(IMantenedorRepo repository ,IMapper mapper)
        {
            _repository = repository; 
            _mapper = mapper;
        }
        
        // Acción para obtener todas las Bodegas
        [HttpGet("GetAllBodegas")]
        public ActionResult<IEnumerable<Bodega>> GetAllBodegas()
        {
            var bodegaItems = _repository.GetAllBodegas();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoBodega>>(bodegaItems));
        }

        // Acción para obtener una Bodega por su Id
        [HttpGet("GetBodegaById/{id}",Name = "GetBodegaById")] 
        public ActionResult<MantenedorDtoBodega> GetBodegaById(int id)
        {
            var bodegaItems = _repository.GetBodegaById(id);
            if(bodegaItems != null)
            {
                return Ok(_mapper.Map<MantenedorDtoBodega>(bodegaItems));
            }
            return NotFound();
        }
        
        [HttpPost("CreateBodega")]
        public ActionResult<MantenedorDtoBodega> CreateBodega(MantenedorCreateDtoBodega mantenedorCreateDtoBodega)
        {
            var bodegaModel = _mapper.Map<Bodega>(mantenedorCreateDtoBodega);
            _repository.CreateBodega(bodegaModel); 
            _repository.saveChanges(); 

            var mantenedorBodegaDto = _mapper.Map<MantenedorDtoBodega>(bodegaModel); 


            return CreatedAtRoute(nameof(GetBodegaById),new{id = mantenedorBodegaDto.CodigoBodega},mantenedorBodegaDto);
        }

        [HttpPut("UpdateBodega/{id}")]
        public ActionResult UpdateBodega(int id, MantenedorUpdateDtoBodega mantenedorUpdateDtoBodega )
        {
            var bodegaModelFromRepo = _repository.GetBodegaById(id);
            if(bodegaModelFromRepo == null){
                return NotFound(); 
            } 

            _mapper.Map(mantenedorUpdateDtoBodega, bodegaModelFromRepo);

            _repository.UpdateBodega(bodegaModelFromRepo); 

            _repository.saveChanges(); 

            return NoContent(); 
            
        } 
        [HttpPatch("PartialBodegaUpdate/{id}")]
        public ActionResult PartialBodegaUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoBodega> patchDoc)
        {
            var bodegaModelFromRepo = _repository.GetBodegaById(id); 
            if(bodegaModelFromRepo == null)
            {
                return NotFound();
            }

            var bodegaToPatch = _mapper.Map<MantenedorUpdateDtoBodega>(bodegaModelFromRepo); 

            patchDoc.ApplyTo(bodegaToPatch,ModelState); 

            if(TryValidateModel(bodegaToPatch)){
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(bodegaToPatch,bodegaModelFromRepo); 

            _repository.UpdateBodega(bodegaModelFromRepo); 

            _repository.saveChanges(); 

            return NoContent(); 


        }

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

        [HttpPost("CreateCentroDeSalud")]
        public ActionResult<MantenedorDtoCentroDeSalud> CreateCentroDeSalud(MantenedorCreateDtoCentroDeSalud mantenedorCreateDtoCentroDeSalud){
            var centroDeSaludModel = _mapper.Map<CentroDeSalud>(mantenedorCreateDtoCentroDeSalud); 
            _repository.CreateCentroDeSalud(centroDeSaludModel); 
            _repository.saveChanges(); 

            var mantenedorCentroDeSaludDto = _mapper.Map<MantenedorDtoCentroDeSalud>(centroDeSaludModel); 

            return CreatedAtRoute(nameof(GetCentroDeSaludById),new{id = mantenedorCentroDeSaludDto.CodigoCentroSalud},mantenedorCentroDeSaludDto);
        }

        [HttpPut("UpdateCentroDeSalud/{id}")] 
        public ActionResult UpdateCentroDeSalud(int id, MantenedorUpdateDtoCentroDeSalud mantenedorUpdateDtoCentroDeSalud){
            var centroDeSaludModelFromRepo = _repository.GetCentroDeSaludById(id); 
            if(centroDeSaludModelFromRepo == null){
                return NotFound(); 
            } 

            _mapper.Map(mantenedorUpdateDtoCentroDeSalud,centroDeSaludModelFromRepo); 

            _repository.UpdateCentroDeSalud(centroDeSaludModelFromRepo);

            _repository.saveChanges(); 

            return NoContent();  
        }

        [HttpPatch("PartialCentroDeSaludUpdate/{id}")]
        public ActionResult PartialCentroDeSaludUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoCentroDeSalud> jsonPatchDoc){
            var centroDeSaludModelFromRepo = _repository.GetCentroDeSaludById(id); 
            
            if(centroDeSaludModelFromRepo == null){
                return NotFound(); 
            }

            var centroDeSaludToPatch = _mapper.Map<MantenedorUpdateDtoCentroDeSalud>(centroDeSaludModelFromRepo); 

            jsonPatchDoc.ApplyTo(centroDeSaludToPatch,ModelState); 

            if(TryValidateModel(centroDeSaludToPatch)){
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(centroDeSaludToPatch,centroDeSaludModelFromRepo); 

            _repository.UpdateCentroDeSalud(centroDeSaludModelFromRepo); 

            _repository.saveChanges(); 

            return NoContent(); 
        }

        [HttpDelete("DeleteCentroDeSalud/{id}")]

        public ActionResult DeleteCentroDeSalud(int id){
            var centroDeSaludModelFromRepo = _repository.GetCentroDeSaludById(id); 
            
            if(centroDeSaludModelFromRepo == null){
                return NotFound(); 
            }

            _repository.DeleteCentroDeSalud(centroDeSaludModelFromRepo); 
            _repository.saveChanges();

            return NoContent(); 
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

        [HttpPost("CreateArticulos")]
        public ActionResult<MantenedorDtoArticulos> CreateArticulos(MantenedorCreateDtoArticulos mantenedorCreateDtoArticulos){
            var articulosModel = _mapper.Map<Articulos>(mantenedorCreateDtoArticulos); 
            _repository.CreateArticulos(articulosModel); 
            _repository.saveChanges(); 

            var mantenedorDtoArticulos = _mapper.Map<MantenedorDtoArticulos>(articulosModel);

            return CreatedAtRoute(nameof(GetArticulosById),new{id = mantenedorDtoArticulos.IdArticulo},mantenedorDtoArticulos);  
        }

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

        [HttpPatch("PartialArticulosUpdate/{id}")]
        public ActionResult PartialArticulosUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoArticulos> jsonPatchDocument){
            
            var articulosModelFromRepo = _repository.GetArticulosById(id);
            
            if( articulosModelFromRepo == null){
                return NotFound(); 
            }

            var articulosToPatch = _mapper.Map<MantenedorUpdateDtoArticulos>(articulosModelFromRepo); 

            jsonPatchDocument.ApplyTo(articulosToPatch,ModelState);  

            if(TryValidateModel(articulosToPatch)){
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(articulosToPatch,articulosModelFromRepo); 

            _repository.UpdateArticulos(articulosModelFromRepo); 

            _repository.saveChanges(); 

            return NoContent(); 
        }

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

        [HttpPost("CreateMotivos")]

        public ActionResult<MantenedorDtoMotivos> CreateMotivos(MantenedorCreateDtoMotivos mantenedorCreateDtoMotivos){
            var motivosModel = _mapper.Map<Motivos>(mantenedorCreateDtoMotivos);
            _repository.CreateMotivos(motivosModel);
            _repository.saveChanges(); 

            var mantenedorMotivos = _mapper.Map<MantenedorDtoMotivos>(motivosModel);

            return CreatedAtRoute(nameof(GetMotivosById),new{id = mantenedorMotivos.IdMotivo},mantenedorMotivos); 
        }

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

        [HttpPatch("PartialMotivosUpdate/{id}")]
        public ActionResult PartialMotivosUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoMotivos> jsonPatchDocument){
            
            var motivosModelFromRepo = _repository.GetMotivosById(id); 
            
            if( motivosModelFromRepo == null){
                return NotFound(); 
            }

            var motivosToPatch = _mapper.Map<MantenedorUpdateDtoMotivos>(motivosModelFromRepo); 

            jsonPatchDocument.ApplyTo(motivosToPatch,ModelState);  

            if(TryValidateModel(motivosToPatch)){
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(motivosToPatch,motivosModelFromRepo); 

            _repository.UpdateMotivos(motivosModelFromRepo); 

            _repository.saveChanges(); 

            return NoContent(); 
        }

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
        public ActionResult<MantenedorDtoUsuarios> CreateUsuarios(MantenedorCreateDtoUsuarios mantenedorCreateDtoUsuarios){
            var usuariosModel = _mapper.Map<Usuarios>(mantenedorCreateDtoUsuarios); 
            _repository.CreateUsuarios(usuariosModel); 
            _repository.saveChanges();

            var mantendorDtoUsuarios = _mapper.Map<MantenedorDtoUsuarios>(usuariosModel);

            return CreatedAtRoute(nameof(GetUsuariosById),new{id = mantendorDtoUsuarios.IdUsuario},mantendorDtoUsuarios);
        }

        [HttpPut("UpdateUsuarios/{id}")]
        public ActionResult UpdateUsuarios(int id, MantenedorUpdateDtoUsuarios mantenedorUpdateDtoUsuarios){
            var usuariosModelFromRepo = _repository.GetUsuariosById(id); 
            if(usuariosModelFromRepo == null){
                return NotFound(); 
            }

            _mapper.Map(mantenedorUpdateDtoUsuarios,usuariosModelFromRepo);

            _repository.UpdateUsuarios(usuariosModelFromRepo); 

            _repository.saveChanges(); 

            return NotFound(); 

        }

        [HttpPatch("PartialUsuariosUpdate/{id}")]
        public ActionResult PartialUsuariosUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoUsuarios> jsonPatchDocument)
        {
            var usuariosModelFromRepo = _repository.GetUsuariosById(id); 
            
            if( usuariosModelFromRepo == null){
                return NotFound(); 
            }

            var usuariosToPatch = _mapper.Map<MantenedorUpdateDtoUsuarios>(usuariosModelFromRepo); 

            jsonPatchDocument.ApplyTo(usuariosToPatch,ModelState);  

            if(TryValidateModel(usuariosToPatch)){
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(usuariosToPatch,usuariosModelFromRepo); 

            _repository.UpdateUsuarios(usuariosModelFromRepo); 

            _repository.saveChanges(); 

            return NoContent(); 
        }

        [HttpDelete("DeleteUsuarios/{id}")]
        public ActionResult DeleteUsuarios(int id){
           
            var usuariosModelFromRepo = _repository.GetUsuariosById(id); 
            
            if(usuariosModelFromRepo == null){
                return NotFound(); 
            }

            _repository.DeleteUsuarios(usuariosModelFromRepo); 
            _repository.saveChanges();

            return NoContent(); 
        }

        // Acción para obtener todas los Inventarios
        [HttpGet("GetAllInventarios")]
        public ActionResult<IEnumerable<Inventario>> GetAllInventarios()
        {
            var inventarioItems = _repository.GetAllInventario();
            return Ok(_mapper.Map<IEnumerable<MantenedorDtoInventario>>(inventarioItems));
        }

        // Acción para obtener un Inventario por su Id
        [HttpGet("GetInventariosById/{id}",Name ="GetInventariosById")]
        public ActionResult<MantenedorDtoInventario> GetInventariosById(int id)
        {
            var inventarioItems = _repository.GetInventarioById(id);
            if(inventarioItems != null){
                return Ok(_mapper.Map<MantenedorDtoInventario>(inventarioItems));
            }
            return NotFound();
        }

        [HttpPost("CreateInventario")]
        public ActionResult<MantenedorDtoInventario> CreateInventario(MantenedorCreateDtoInventario mantenedorCreateDtoInventario){
            var inventarioModel = _mapper.Map<Inventario>(mantenedorCreateDtoInventario);
            _repository.CreateInventario(inventarioModel); 
            _repository.saveChanges();

            var mantendorDtoInventario = _mapper.Map<MantenedorDtoInventario>(inventarioModel);

            return CreatedAtRoute(nameof(GetInventariosById),new{id = mantendorDtoInventario.IdInventario},mantendorDtoInventario); 
        }

        [HttpPut("UpdateInventario/{id}")]
        public ActionResult UpdateInventario(int id, MantenedorUpdateDtoInventario mantenedorUpdateDtoInventario){
            var inventarioModelFromRepo = _repository.GetInventarioById(id); 
            if(inventarioModelFromRepo == null){
                return NotFound(); 
            }

            _mapper.Map(mantenedorUpdateDtoInventario,inventarioModelFromRepo); 

            _repository.UpdateInventario(inventarioModelFromRepo); 

            _repository.saveChanges(); 

            return NotFound(); 
        }

        [HttpPatch("PartialInventarioUpdate/{id}")]
        public ActionResult PartialInventarioUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoInventario> jsonPatchDocument)
        {
            var inventarioModelFromRepo = _repository.GetInventarioById(id); 
            
            if( inventarioModelFromRepo == null){
                return NotFound(); 
            }

            var inventarioToPatch = _mapper.Map<MantenedorUpdateDtoInventario>(inventarioModelFromRepo); 

            jsonPatchDocument.ApplyTo(inventarioToPatch,ModelState);  

            if(TryValidateModel(inventarioToPatch)){
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(inventarioToPatch,inventarioModelFromRepo); 

            _repository.UpdateInventario(inventarioModelFromRepo); 

            _repository.saveChanges(); 

            return NoContent(); 
        }

        [HttpDelete("DeleteInventario/{id}")]

        public ActionResult DeleteInventario(int id){
            var inventarioModelFromRepo = _repository.GetInventarioById(id); 
            
            if(inventarioModelFromRepo == null){
                return NotFound(); 
            }

            _repository.DeleteInventario(inventarioModelFromRepo); 
            _repository.saveChanges();

            return NoContent(); 
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

        [HttpPost("CreateMovimientosInventario")] 
        public ActionResult<MantenedorDtoMovimientosInventario> CreateMovimientosInventario(MantenedorCreateDtoMovimientosInventario mantenedorCreateDtoMovimientosInventario){
            var movimientosModel = _mapper.Map<MovimientosInventario>(mantenedorCreateDtoMovimientosInventario);
            _repository.CreateMovimientosInventario(movimientosModel); 
            _repository.saveChanges(); 

            var mantenedorDtoMovimientosInventario = _mapper.Map<MantenedorDtoMovimientosInventario>(movimientosModel);

            return CreatedAtRoute(nameof(GetMovimientosInventarioById), new{id = mantenedorDtoMovimientosInventario.IdMovimiento},mantenedorDtoMovimientosInventario); 
        }

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

        [HttpPatch("PartialMovimientosInventarioUpdate/{id}")]
        public ActionResult PartialMovimientosInventarioUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoMovimientosInventario> jsonPatchDocument){
            
            var movimientoInventarioModelFromRepo = _repository.GetMovimientosInventarioById(id);
            
            if( movimientoInventarioModelFromRepo == null){
                return NotFound(); 
            }

            var movimientosToPatch = _mapper.Map<MantenedorUpdateDtoMovimientosInventario>(movimientoInventarioModelFromRepo); 

            jsonPatchDocument.ApplyTo(movimientosToPatch,ModelState);  

            if(TryValidateModel(movimientosToPatch)){
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(movimientosToPatch,movimientoInventarioModelFromRepo); 

            _repository.UpadateMovimientosInventario(movimientoInventarioModelFromRepo); 

            _repository.saveChanges(); 

            return NoContent(); 
        }

        [HttpDelete("DeleteMovimientosInventario/{id}")]
        public ActionResult DeleteMovimientosInventario(int id){
            
            var movimientoModelFromRepo = _repository.GetMovimientosInventarioById(id); 
            
            if(movimientoModelFromRepo == null){
                return NotFound(); 
            }

            _repository.DeleteMovimientoInventario(movimientoModelFromRepo); 
            _repository.saveChanges();

            return NoContent(); 
        }

    }

    
}