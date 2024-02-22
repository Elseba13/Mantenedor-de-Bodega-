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

        public MantenedorController(IMantenedorRepo repository, IMapper mapper, MantenedorContext context)
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
        [HttpGet("GetBodegaById/{id}", Name = "GetBodegaById")]
        public ActionResult<MantenedorDtoBodega> GetBodegaById(int id)
        {
            var bodegaItems = _repository.GetBodegaById(id);

            //var bodegaItems = new List<Bodega>();
            //bodegaItems.Add(new Bodega()); 

            if (bodegaItems != null)
            {
                return Ok(_mapper.Map<MantenedorDtoBodega>(bodegaItems));
            }

            return NotFound();
        }


        // Acción para crear una bodega 
        [HttpPost("CreateBodega")]
        public ActionResult<MantenedorDtoBodega> CreateBodega(int IdCentroDeSalud, MantenedorCreateDtoBodega mantenedorCreateDtoBodega)
        {
            var bodegaModel = _mapper.Map<Bodega>(mantenedorCreateDtoBodega);

            var centroSalud = _repository.GetCentroDeSaludById(IdCentroDeSalud);

            if (centroSalud == null)
            {
                return NotFound();
            }

            bodegaModel.CentroDeSaluds = centroSalud;

            _repository.CreateBodega(bodegaModel);
            _repository.saveChanges();



            var mantenedorBodegaDto = _mapper.Map<MantenedorDtoBodega>(bodegaModel);


            return CreatedAtRoute(nameof(GetBodegaById), new { id = mantenedorBodegaDto.CodigoBodega }, mantenedorBodegaDto);
        }

        //Accion para borrar una bodega 
        [HttpDelete("DeleteBodega/{id}")]
        public ActionResult DeleteBodega(int id)
        {
            var bodegaModelFromRepo = _repository.GetBodegaById(id);

            if (bodegaModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteBodega(bodegaModelFromRepo);
            _repository.saveChanges();

            return NoContent();

        }

        //Accion para crear un centro de salud
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
        [HttpGet("GetCentroDeSaludById/{id}", Name = "GetCentroDeSaludById")]
        public ActionResult<MantenedorDtoCentroDeSalud> GetCentroDeSaludById(int id)
        {
            var centroDeSaludItems = _repository.GetCentroDeSaludById(id);
            if (centroDeSaludItems != null)
            {
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
        [HttpGet("GetArticulosById/{id}", Name = "GetArticulosById")]
        public ActionResult<MantenedorDtoArticulos> GetArticulosById(int id)
        {
            var articulosItems = _repository.GetArticulosById(id);
            if (articulosItems != null)
            {
                return Ok(_mapper.Map<MantenedorDtoArticulos>(articulosItems));
            }
            return NotFound();
        }

        // Acción para crear una bodega 
        [HttpPost("CreateArticulos")]
        public ActionResult<MantenedorDtoArticulos> CreateArticulo(MantenedorCreateDtoArticulos mantenedorCreateDtoArticulos)
        {
            var articulosModel = _mapper.Map<Articulos>(mantenedorCreateDtoArticulos);

            _repository.CreateArticulos(articulosModel);
            _repository.saveChanges();

            var mantenedorArticulosDto = _mapper.Map<MantenedorDtoArticulos>(articulosModel);


            return CreatedAtRoute(nameof(GetArticulosById), new { id = mantenedorArticulosDto.IdArticulo }, mantenedorArticulosDto);
        }



        //Accion para Actualizar articulos 
        [HttpPut("UpdateArticulos/{id}")]
        public ActionResult UpdateArticulos(int id, MantenedorUpdateDtoArticulos mantenedorUpdateDtoArticulos)
        {
            var articulosModelFromRepo = _repository.GetArticulosById(id);
            if (articulosModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(mantenedorUpdateDtoArticulos, articulosModelFromRepo);

            _repository.UpdateArticulos(articulosModelFromRepo);

            _repository.saveChanges();

            return NoContent();
        }

        //Accion para actulizar parcialmente articulos 
        [HttpPatch("PartialArticulosUpdate/{id}")]
        public ActionResult PartialArticulosUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoArticulos> jsonPatchDocument)
        {

            var articulosModelFromRepo = _repository.GetArticulosById(id);

            if (articulosModelFromRepo == null)
            {
                return NotFound();
            }

            var articulosToPatch = _mapper.Map<MantenedorUpdateDtoArticulos>(articulosModelFromRepo);

            jsonPatchDocument.ApplyTo(articulosToPatch, ModelState);

            if (!TryValidateModel(articulosToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(articulosToPatch, articulosModelFromRepo);

            _repository.UpdateArticulos(articulosModelFromRepo);

            _repository.saveChanges();

            return NoContent();
        }


        //Accion para eliminar articulos por ID 
        [HttpDelete("DeleteArticulos/{id}")]

        public ActionResult DeleteArticulos(int id)
        {

            var articulosModelFromRepo = _repository.GetArticulosById(id);

            if (articulosModelFromRepo == null)
            {
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
        [HttpGet("GetMotivosById/{id}", Name = "GetMotivosById")]
        public ActionResult<MantenedorDtoMotivos> GetMotivosById(int id)
        {
            var motivosItems = _repository.GetMotivosById(id);
            if (motivosItems != null)
            {
                return Ok(_mapper.Map<MantenedorDtoMotivos>(motivosItems));
            }
            return NotFound();
        }

        //Accion para crear motivos 
        [HttpPost("CreateMotivos")]

        public ActionResult<MantenedorDtoMotivos> CreateMotivos(MantenedorCreateDtoMotivos mantenedorCreateDtoMotivos)
        {
            var motivosModel = _mapper.Map<Motivos>(mantenedorCreateDtoMotivos);

            _repository.CreateMotivos(motivosModel);
            _repository.saveChanges();

            var mantenedorMotivos = _mapper.Map<MantenedorDtoMotivos>(motivosModel);

            return CreatedAtRoute(nameof(GetMotivosById), new { id = mantenedorMotivos.IdMotivo }, mantenedorMotivos);
        }

        //Accion para actulizar los motivos por ID 
        [HttpPut("UpdateMotivos/{id}")]
        public ActionResult UpdateMotivos(int id, MantenedorUpdateDtoMotivos mantenedorUpdateDtoMotivos)
        {
            var motivosModelFromRepo = _repository.GetMotivosById(id);
            if (motivosModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(mantenedorUpdateDtoMotivos, motivosModelFromRepo);

            _repository.UpdateMotivos(motivosModelFromRepo);

            _repository.saveChanges();

            return NotFound();

        }

        //Acción para actuliazar parcialmente los motivos por ID
        [HttpPatch("PartialMotivosUpdate/{id}")]
        public ActionResult PartialMotivosUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoMotivos> jsonPatchDocument)
        {

            var motivosModelFromRepo = _repository.GetMotivosById(id);

            if (motivosModelFromRepo == null)
            {
                return NotFound();
            }

            var motivosToPatch = _mapper.Map<MantenedorUpdateDtoMotivos>(motivosModelFromRepo);

            jsonPatchDocument.ApplyTo(motivosToPatch, ModelState);

            if (!TryValidateModel(motivosToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(motivosToPatch, motivosModelFromRepo);

            _repository.UpdateMotivos(motivosModelFromRepo);

            _repository.saveChanges();

            return NoContent();
        }

        //Accion para eliminar un motivo Por ID
        [HttpDelete("DeleteMotivos/{id}")]
        public ActionResult DeleteMotivos(int id)
        {

            var motivosModelFromRepo = _repository.GetMotivosById(id);

            if (motivosModelFromRepo == null)
            {
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
        [HttpGet("GetUsuariosById/{id}", Name = "GetUsuariosById")]
        public ActionResult<MantenedorDtoUsuarios> GetUsuariosById(int id)
        {
            var usuariosItems = _repository.GetUsuariosById(id);
            if (usuariosItems != null)
            {
                return Ok(_mapper.Map<MantenedorDtoUsuarios>(usuariosItems));
            }
            return NotFound();
        }


        //Accion para crear un usuario 
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
        public ActionResult AumentoDeStock(int id, int stock, int idUsuario, int IdBodega)
        {
            // Obtener el modelo del artículo por su ID
            var articuloModel = _repository.GetArticulosById(id);

            // Obtener el modelo del usuario por su ID
            var usuarioModel = _repository.GetUsuariosById(idUsuario);

            var inventarioModel = _context.Inventarios.FirstOrDefault(i => i.IdArticulos == id && i.CodigoBodega == IdBodega);

            // Modelo de bodega inicializado
            var bodegaModel = new Bodega();

            // Iterar sobre las bodegas asociadas al artículo para encontrar la bodega deseada por su ID
            foreach (var bodega in articuloModel.Bodegas)
            {
                if (bodega.bodega.CodigoBodega == IdBodega)
                {
                    bodegaModel = bodega.bodega;
                    break;
                }
            }

            // Verificar si el artículo fue encontrado
            if (articuloModel == null)
            {
                return NotFound("El Articulo no fue encontrado");
            }

            // Verificar si el usuario fue encontrado
            if (usuarioModel == null)
            {
                return NotFound("El Usuario no fue encontrado");
            }

            // Crear un nuevo motivo para el movimiento de inventario (aumento de stock)
            var motivosModel = new Motivos
            {
                Motivo = "Aumento de stock"
            };

            // Crear un nuevo movimiento de inventario
            var movimientosInventario = new MovimientosInventario
            {
                Cantidad = stock, // Establecer la cantidad de aumento de stock
                FechaDeMovimiento = DateTime.Now, // Establecer la fecha del movimiento
                Motivo = motivosModel, // Asignar el motivo al movimiento
                BodegaDeOrigen = bodegaModel, // Asignar la bodega de origen al movimiento
                BodegaDestino = null, // No hay bodega de destino en un aumento de stock
                Articulo = articuloModel, // Asignar el artículo al movimiento
                Usuario = usuarioModel, // Asignar el usuario al movimiento 
                StockInicialBodegaOrigen = inventarioModel.StockActual,
                StockFinalBodegaDestino = inventarioModel.StockActual + stock 
            };

            // Actualizar el stock actual de la bodega correspondiente al aumento de stock
            foreach (var bodega in articuloModel.Bodegas)
            {
                if (bodega.bodega.CodigoBodega == IdBodega)
                {
                    bodega.StockActual += stock; // Aumentar el stock actual
                    break;
                }
            }

            // Actualizar el artículo en el repositorio
            _repository.UpdateArticulos(articuloModel);

            // Crear el nuevo movimiento de inventario en el repositorio
            _repository.CreateMovimientosInventario(movimientosInventario);

            // Crear el motivo del movimiento en el repositorio
            _repository.CreateMotivos(motivosModel);

            // Guardar los cambios en el repositorio
            _repository.saveChanges(); 

            // Retornar una respuesta exitosa
            return Ok();
        }


        //Acción para disminuir stock de un inventario asociado a un articulo
        [HttpPut("DisminucionDeStock/{id}")]
        public ActionResult DisminucionDeStock(int id, int stock, int idUsuario, int IdBodega)
        {
            // Obtener el modelo del artículo por su ID
            var articulosModel = _repository.GetArticulosById(id);

            // Obtener el modelo del usuario por su ID
            var usuarioModel = _repository.GetUsuariosById(idUsuario);

            // Modelo de bodega inicializado
            var bodegaModel = new Bodega();

            var inventarioModel = _context.Inventarios.FirstOrDefault(i => i.IdArticulos == id && i.CodigoBodega == IdBodega);

            // Iterar sobre las bodegas asociadas al artículo para encontrar la bodega deseada por su ID
            foreach (var bodega in articulosModel.Bodegas)
            {
                if (bodega.bodega.CodigoBodega == IdBodega)
                {
                    bodegaModel = bodega.bodega;
                    break;
                }
            }

            // Verificar si el usuario fue encontrado
            if (usuarioModel == null)
            {
                return NotFound("El usuario ingresado no existe");
            }

            // Verificar si el artículo fue encontrado
            if (articulosModel == null)
            {
                return NotFound("El articulo ingresado no existe");
            }

            // Crear un nuevo motivo para el movimiento de inventario (descuento de stock)
            var motivosModel = new Motivos
            {
                Motivo = "Descuento de stock"
            };

            // Crear un nuevo movimiento de inventario
            var movimientosInventarioModel = new MovimientosInventario
            {
                Cantidad = stock, // Establecer la cantidad de descuento de stock
                FechaDeMovimiento = DateTime.Now, // Establecer la fecha del movimiento
                Motivo = motivosModel, // Asignar el motivo al movimiento
                BodegaDeOrigen = bodegaModel, // Asignar la bodega de origen al movimiento
                BodegaDestino = null, // No hay bodega de destino en un descuento de stock
                Articulo = articulosModel, // Asignar el artículo al movimiento
                Usuario = usuarioModel, // Asignar el usuario al movimiento 
                StockInicialBodegaOrigen = inventarioModel.StockActual,
                StockFinalBodegaOrigen = inventarioModel.StockActual - stock
            };

            // Actualizar el stock actual de la bodega correspondiente al descuento de stock
            foreach (var bodegas in articulosModel.Bodegas)
            {
                if (bodegas.bodega.CodigoBodega == IdBodega)
                {
                    bodegas.StockActual -= stock; // Disminuir el stock actual
                    break;
                }
            }

            // Actualizar el artículo en el repositorio
            _repository.UpdateArticulos(articulosModel);

            // Crear el nuevo movimiento de inventario en el repositorio
            _repository.CreateMovimientosInventario(movimientosInventarioModel);

            // Crear el motivo del movimiento en el repositorio
            _repository.CreateMotivos(motivosModel);

            // Guardar los cambios en el repositorio
            _repository.saveChanges();

            // Retornar una respuesta exitosa
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
        [HttpGet("GetMovimientosInventarioById/{id}", Name = "GetMovimientosInventarioById")]
        public ActionResult<MantenedorDtoMovimientosInventario> GetMovimientosInventarioById(int id)
        {
            var movimientosInventarioItems = _repository.GetMovimientosInventarioById(id);
            if (movimientosInventarioItems != null)
            {
                return Ok(_mapper.Map<MantenedorDtoMovimientosInventario>(movimientosInventarioItems));
            }
            return NotFound();
        }

        //Accion para crear los movimeinto de inventario 
        [HttpPost("CreateMovimientosInventario")]
        public ActionResult<MantenedorDtoMovimientosInventario> CreateMovimientosInventario(MantenedorCreateDtoMovimientosInventario mantenedorCreateDtoMovimientosInventario)
        {
            var movimientosModel = _mapper.Map<MovimientosInventario>(mantenedorCreateDtoMovimientosInventario);
            _repository.CreateMovimientosInventario(movimientosModel);
            _repository.saveChanges();

            var mantenedorDtoMovimientosInventario = _mapper.Map<MantenedorDtoMovimientosInventario>(movimientosModel);

            return CreatedAtRoute(nameof(GetMovimientosInventarioById), new { id = mantenedorDtoMovimientosInventario.IdMovimiento }, mantenedorDtoMovimientosInventario);
        }


        //Accion para actualizar los movimientos de inventario por ID 
        [HttpPut("UpdateMovimientosInventario/{id}")]

        public ActionResult UpdateMovimientosInventario(int id, MantenedorUpdateDtoMovimientosInventario mantenedorUpdateDtoMovimientosInventario)
        {
            var movimientosInventarioModelFromRepo = _repository.GetMovimientosInventarioById(id);
            if (movimientosInventarioModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(mantenedorUpdateDtoMovimientosInventario, movimientosInventarioModelFromRepo);

            _repository.UpadateMovimientosInventario(movimientosInventarioModelFromRepo);

            _repository.saveChanges();

            return NotFound();

        }

        //Accion para actualizar parcialmente los movimientos de inventario por ID 
        [HttpPatch("PartialMovimientosInventarioUpdate/{id}")]
        public ActionResult PartialMovimientosInventarioUpdate(int id, JsonPatchDocument<MantenedorUpdateDtoMovimientosInventario> jsonPatchDocument)
        {

            var movimientoInventarioModelFromRepo = _repository.GetMovimientosInventarioById(id);

            if (movimientoInventarioModelFromRepo == null)
            {
                return NotFound();
            }

            var movimientosToPatch = _mapper.Map<MantenedorUpdateDtoMovimientosInventario>(movimientoInventarioModelFromRepo);

            jsonPatchDocument.ApplyTo(movimientosToPatch, ModelState);

            if (!TryValidateModel(movimientosToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(movimientosToPatch, movimientoInventarioModelFromRepo);

            _repository.UpadateMovimientosInventario(movimientoInventarioModelFromRepo);

            _repository.saveChanges();

            return NoContent();
        }


        [HttpPost("AsignarArticulosEnBodega")]
        public ActionResult AsignarArticuloEnBodega(int idArticulo, int idBodega, int stock, int idUsuario)
        {
            var articulosModel = _repository.GetArticulosById(idArticulo);
            var bodegasModel = _repository.GetBodegaById(idBodega);
            var usuarioModel = _repository.GetUsuariosById(idUsuario); 


            if (articulosModel == null)
            {
                return NotFound();
            }

            if (bodegasModel == null)
            {
                return NotFound();
            }

            var inventarioModel = _context.Inventarios.FirstOrDefault(i => i.IdArticulos == idArticulo && i.CodigoBodega == idBodega);
            if (inventarioModel != null)
            {
                return Conflict();
            }

            var motivosModel = new Motivos
            {
                Motivo = "Insercion Inicial"
            };

            var inventario = new Inventario
            {
                IdArticulos = idArticulo,
                articulos = articulosModel,
                CodigoBodega = idBodega,
                bodega = bodegasModel,
                StockActual = stock
            };

            var movimientosModel = new MovimientosInventario
            {
                Cantidad = stock,
                FechaDeMovimiento = DateTime.Now,
                BodegaDeOrigen = bodegasModel,
                Motivo = motivosModel,
                BodegaDestino = null,
                Articulo = articulosModel,
                Usuario = usuarioModel,
                StockInicialBodegaOrigen = 0,
                StockFinalBodegaOrigen = stock
            };


           
            _repository.UpdateArticulos(articulosModel);
            _repository.UpdateBodega(bodegasModel);
            _repository.CreateInventario(inventario);
            _repository.CreateMovimientosInventario(movimientosModel); 
            _repository.saveChanges();




            return Ok();
        }

        //Acción para hacer el ajuste de inventario
        [HttpPut("AjusteDeInventario")]
        public ActionResult AjusteDeInventario(int idArticulo, int idBodega, int stockReal, int idUsuario)
        {
            // Obtener el modelo del usuario por su ID
            var usuarioModel = _repository.GetUsuariosById(idUsuario);

            // Obtener el modelo del artículo por su ID
            var articuloModel = _repository.GetArticulosById(idArticulo);

            // Obtener el modelo de la bodega por su ID
            var bodegaModel = _repository.GetBodegaById(idBodega);

            // Obtener el modelo de inventario asociado al artículo y la bodega
            var inventarioModel = _context.Inventarios.FirstOrDefault(i => i.IdArticulos == idArticulo && i.CodigoBodega == idBodega);

            // Verificar si el modelo de inventario fue encontrado
            if (inventarioModel == null)
            {
                return NotFound();
            }

            // Crear un nuevo motivo para el ajuste de inventario
            var motivosModel = new Motivos
            {
                Motivo = "Ajuste de inventario"
            };

            // Calcular la cantidad de ajuste de inventario
            var ajusteCantidad = inventarioModel.StockActual - stockReal;

            // Crear un nuevo movimiento de inventario para el ajuste
            var movimientoModel = new MovimientosInventario
            {
                Cantidad = ajusteCantidad, // Establecer la cantidad de ajuste
                FechaDeMovimiento = DateTime.Now, // Establecer la fecha del movimiento
                BodegaDeOrigen = _repository.GetBodegaById(idBodega), // Establecer la bodega de origen del movimiento
                Motivo = motivosModel, // Asignar el motivo al movimiento
                BodegaDestino = null, // No hay bodega de destino en un ajuste de inventario
                Articulo = _repository.GetArticulosById(idArticulo), // Asignar el artículo al movimiento
                Usuario = usuarioModel,// Asignar el usuario al movimiento
                StockInicialBodegaOrigen = inventarioModel.StockActual,
                StockFinalBodegaOrigen = stockReal 
            };

            // Actualizar el stock actual en el inventario con el valor real proporcionado
            inventarioModel.StockActual = stockReal;

            // Crear el motivo del ajuste de inventario en el repositorio
            _repository.CreateMotivos(motivosModel);

            // Crear el movimiento de inventario del ajuste en el repositorio
            _repository.CreateMovimientosInventario(movimientoModel);

            // Actualizar el inventario en el repositorio con el nuevo stock actualizado
            _repository.UpdateInventario(inventarioModel);

            // Guardar los cambios en el repositorio
            _repository.saveChanges();

            // Retornar una respuesta exitosa
            return Ok();
        }

        //Accion de traslado de articulos
        [HttpPost("TrasladoDeArticulos")]
        public ActionResult TrasladoDeArticulos(int idArticulos, int BodegaOrigen, int BodegaDestino, int idUsuario, int cantidad)
        {
            // Obtener el modelo del artículo por su ID
            var articuloModel = _repository.GetArticulosById(idArticulos);

            // Obtener el modelo de la bodega de origen por su ID
            var bodegaOrigenModel = _repository.GetBodegaById(BodegaOrigen);

            // Obtener el modelo de la bodega de destino por su ID
            var bodegaDestinoModel = _repository.GetBodegaById(BodegaDestino);

            // Obtener el modelo del usuario por su ID
            var usuarioModel = _repository.GetUsuariosById(idUsuario);

            // Verificar si alguno de los modelos no fue encontrado
            if (articuloModel == null || bodegaOrigenModel == null || bodegaDestinoModel == null || usuarioModel == null)
            {
                return NotFound(); // Si algún modelo no fue encontrado, retorna un error NotFound
            }

            // Buscar el inventario en la bodega de origen asociado al artículo
            var inventarioOrigen = _context.Inventarios.FirstOrDefault(i => i.IdArticulos == idArticulos && i.CodigoBodega == BodegaOrigen);

            // Verificar si el inventario en la bodega de origen fue encontrado o si la cantidad solicitada excede el stock disponible
            if (inventarioOrigen == null || inventarioOrigen.StockActual < cantidad)
            {
                return BadRequest(); // Si el inventario no fue encontrado o la cantidad excede el stock, retorna un error BadRequest
            }

 
            // Buscar el inventario en la bodega de destino asociado al artículo
            var inventarioDestino = _context.Inventarios.FirstOrDefault(i => i.IdArticulos == idArticulos && i.CodigoBodega == BodegaDestino);

            if(inventarioDestino != null)
            {
                var motivosModelExistente = new Motivos
                {
                    Motivo = "Traspaso de articulos",
                };

                // Crear un nuevo movimiento de inventario para el traspaso
                var MovimientoModelNuevo = new MovimientosInventario
                {
                    Cantidad = cantidad,
                    FechaDeMovimiento = DateTime.Now,
                    BodegaDeOrigen = bodegaOrigenModel,
                    BodegaDestino = bodegaDestinoModel,
                    Motivo = motivosModelExistente,
                    Articulo = articuloModel,
                    Usuario = usuarioModel,
                    StockInicialBodegaOrigen = inventarioOrigen.StockActual,
                    StockFinalBodegaOrigen = inventarioOrigen.StockActual - cantidad,
                    StockInicialBodegaDestino = inventarioDestino.StockActual,
                    StockFinalBodegaDestino = inventarioDestino.StockActual + cantidad
                };


                // Actualizar el stock en el inventario de la bodega de origen y destino
                inventarioOrigen.StockActual -= cantidad;
                inventarioDestino.StockActual += cantidad;


                // Crear el movimiento de inventario del traspaso en el repositorio
                _repository.CreateMovimientosInventario(MovimientoModelNuevo);

                // Crear el motivo del movimiento en el repositorio
                _repository.CreateMotivos(motivosModelExistente);

                // Actualizar el inventario de destino en el repositorio
                _repository.UpdateInventario(inventarioDestino);

                // Guardar los cambios en el repositorio
                _repository.saveChanges();


                return Ok(); 
            }
            
            // Si el inventario en la bodega de destino no existe, crear uno nuevo
            if (inventarioDestino == null)
            {
                inventarioDestino = new Inventario
                {
                    IdArticulos = idArticulos,
                    articulos = articuloModel,
                    CodigoBodega = BodegaDestino,
                    bodega = bodegaDestinoModel,
                    StockActual = 0
                };
            }

            
            // Crear un nuevo motivo para el movimiento de inventario (traspaso de artículos)
            var motivosModel = new Motivos
            {
                Motivo = "Traspaso de articulos",
            };

            // Crear un nuevo movimiento de inventario para el traspaso
            var MovimientoModel = new MovimientosInventario
            {
                Cantidad = cantidad,
                FechaDeMovimiento = DateTime.Now,
                BodegaDeOrigen = bodegaOrigenModel,
                BodegaDestino = bodegaDestinoModel,
                Motivo = motivosModel,
                Articulo = articuloModel,
                Usuario = usuarioModel, 
                StockInicialBodegaOrigen = inventarioOrigen.StockActual,
                StockFinalBodegaOrigen = inventarioOrigen.StockActual - cantidad,
                StockInicialBodegaDestino = inventarioDestino.StockActual,
                StockFinalBodegaDestino = inventarioDestino.StockActual + cantidad
            };


            
            // Actualizar el stock en el inventario de la bodega de origen y destino
            inventarioOrigen.StockActual -= cantidad;
            inventarioDestino.StockActual += cantidad;


            // Crear el movimiento de inventario del traspaso en el repositorio
            _repository.CreateMovimientosInventario(MovimientoModel);

            // Crear el motivo del movimiento en el repositorio
            _repository.CreateMotivos(motivosModel);

            // Crear el inventario de destino en el repositorio si no existe
            _repository.CreateInventario(inventarioDestino);

            // Actualizar el inventario de origen en el repositorio
            _repository.UpdateInventario(inventarioOrigen);

            // Guardar los cambios en el repositorio
            _repository.saveChanges();

            // Retornar una respuesta exitosa
            return Ok();
        }

        [HttpPost("CreateSolicitudDePedido")]
        public ActionResult CreateSolicitudDePedido(int idUsuario, int idArticulo, int Cantidad, string TipoDeSolicitud, int CodigoBodega)
        {
            var usuarioModel = _repository.GetUsuariosById(idUsuario);
            var articuloModel = _repository.GetArticulosById(idArticulo);

            if (usuarioModel == null)
            {
                return NotFound();
            }

            if (articuloModel == null)
            {
                return NotFound(); 
            }

            var inventarioModel = _context.Inventarios.FirstOrDefault(i => i.IdArticulos == idArticulo && i.CodigoBodega == CodigoBodega); 

            if(inventarioModel.StockActual < Cantidad)
            {
                return BadRequest("Stock actual es menor a la cantidad ingresada"); 
            }

            var solicitudModel = new SolicitudDePedido
            {
                Usuario = usuarioModel,
                FechaDePedido = DateTime.Now,
                Articulo = articuloModel,
                Cantidad = Cantidad,
                TipoDeSolicitud = TipoDeSolicitud
            };  

            _repository.CreateSolicitudDePedido(solicitudModel);

            _repository.saveChanges();

            return Ok("Solicitud creada con exito"); 

        }


    }


}