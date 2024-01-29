using AutoMapper;
using Mantenedor.Dtos;
using models;

namespace Mantenedor.Profiles
{
    public class MantenedorProfile : Profile
    {
        public MantenedorProfile()
        {
            CreateMap<Bodega, MantenedorDtoBodega>(); // Configuración de mapeo para Bodega a MantenedorDtoBodega
            CreateMap<MantenedorCreateDtoBodega, Bodega>();
            CreateMap<MantenedorUpdateDtoBodega,Bodega>(); 
            CreateMap<Bodega,MantenedorUpdateDtoBodega>(); 
            CreateMap<CentroDeSalud, MantenedorDtoCentroDeSalud>(); // Configuración de mapeo para CentroDeSalud a MantenedorDtoCentroDeSalud
            CreateMap<MantenedorCreateDtoCentroDeSalud,CentroDeSalud>();
            CreateMap<MantenedorUpdateDtoCentroDeSalud,CentroDeSalud>();
            CreateMap<CentroDeSalud,MantenedorUpdateDtoCentroDeSalud>(); 
            CreateMap<Articulos, MantenedorDtoArticulos>(); // Configuración de mapeo para Articulos a MantenedorDtoArticulos
            CreateMap<MantenedorCreateDtoArticulos,Articulos>();
            CreateMap<MantenedorUpdateDtoArticulos,Articulos>(); 
            CreateMap<Articulos,MantenedorUpdateDtoArticulos>(); 
            CreateMap<Motivos, MantenedorDtoMotivos>(); // Configuración de mapeo para Motivos a MantenedorDtoMotivos
            CreateMap<MantenedorCreateDtoMotivos,Motivos>();
            CreateMap<MantenedorUpdateDtoMotivos,Motivos>(); 
            CreateMap<Motivos,MantenedorUpdateDtoMotivos>(); 
            CreateMap<Usuarios, MantenedorDtoUsuarios>(); // Configuración de mapeo para Usuarios a MantenedorDtoUsuarios
            CreateMap<MantenedorCreateDtoUsuarios,Usuarios>();
            CreateMap<MantenedorUpdateDtoUsuarios,Usuarios>();
            CreateMap<Usuarios,MantenedorUpdateDtoUsuarios>();  
            CreateMap<Inventario, MantenedorDtoInventario>(); // Configuración de mapeo para Inventario a MantenedorDtoInventario
            CreateMap<MantenedorCreateDtoInventario,Inventario>();
            CreateMap<MantenedorUpdateDtoInventario,Inventario>(); 
            CreateMap<Inventario,MantenedorUpdateDtoInventario>(); 
            CreateMap<MovimientosInventario, MantenedorDtoMovimientosInventario>(); // Configuración de mapeo para MovimientosInventario a MantenedorDtoMovimientosInventario
            CreateMap<MantenedorCreateDtoMovimientosInventario,MovimientosInventario>(); 
            CreateMap<MantenedorUpdateDtoMovimientosInventario,MovimientosInventario>(); 
            CreateMap<MovimientosInventario,MantenedorUpdateDtoMovimientosInventario>(); 
        }
    }
}
