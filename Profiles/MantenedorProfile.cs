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
            CreateMap<CentroDeSalud, MantenedorDtoCentroDeSalud>(); // Configuración de mapeo para CentroDeSalud a MantenedorDtoCentroDeSalud
            CreateMap<Articulos, MantenedorDtoArticulos>(); // Configuración de mapeo para Articulos a MantenedorDtoArticulos
            CreateMap<Motivos, MantenedorDtoMotivos>(); // Configuración de mapeo para Motivos a MantenedorDtoMotivos
            CreateMap<Usuarios, MantenedorDtoUsuarios>(); // Configuración de mapeo para Usuarios a MantenedorDtoUsuarios
            CreateMap<Inventario, MantenedorDtoInventario>(); // Configuración de mapeo para Inventario a MantenedorDtoInventario
            CreateMap<MovimientosInventario, MantenedorDtoMovimientosInventario>(); // Configuración de mapeo para MovimientosInventario a MantenedorDtoMovimientosInventario
        }
    }
}
