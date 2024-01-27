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
            CreateMap<CentroDeSalud, MantenedorDtoCentroDeSalud>(); // Configuración de mapeo para CentroDeSalud a MantenedorDtoCentroDeSalud
            CreateMap<MantenedorCreateDtoCentroDeSalud,CentroDeSalud>();
            CreateMap<Articulos, MantenedorDtoArticulos>(); // Configuración de mapeo para Articulos a MantenedorDtoArticulos
            CreateMap<MantenedorCreateDtoArticulos,Articulos>();
            CreateMap<Motivos, MantenedorDtoMotivos>(); // Configuración de mapeo para Motivos a MantenedorDtoMotivos
            CreateMap<MantenedorCreateDtoMotivos,Motivos>();
            CreateMap<Usuarios, MantenedorDtoUsuarios>(); // Configuración de mapeo para Usuarios a MantenedorDtoUsuarios
            CreateMap<MantenedorCreateDtoUsuarios,Usuarios>();
            CreateMap<Inventario, MantenedorDtoInventario>(); // Configuración de mapeo para Inventario a MantenedorDtoInventario
            CreateMap<MantenedorCreateDtoInventario,Inventario>();
            CreateMap<MovimientosInventario, MantenedorDtoMovimientosInventario>(); // Configuración de mapeo para MovimientosInventario a MantenedorDtoMovimientosInventario
            CreateMap<MantenedorCreateDtoMovimientosInventario,MovimientosInventario>(); 
        }
    }
}
