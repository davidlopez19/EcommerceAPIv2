using AutoMapper;
using EcommerceAPI.Common.Classes.Contracts.Clientes;
using EcommerceAPI.Common.Classes.Contracts.Compras;
using EcommerceAPI.Common.Classes.Contracts.Productos;
using EcommerceAPI.Infraestructura.Database.Entities.Clientes;
using EcommerceAPI.Infraestructura.Database.Entities.Compras;
using EcommerceAPI.Infraestructura.Database.Entities.Productos;

namespace EcommerceAPI.Configuracion.Configuracion
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ClientesEntities, ClientesContract>().ReverseMap();
            CreateMap<ProductosEntities, ProductosContract>().ReverseMap();
            CreateMap<StockEntities, StockContract>().ReverseMap();
            CreateMap<ComprasEntities, ComprasContract>().ReverseMap();
            CreateMap<DetalleComprasEntities, DetalleComprasContract>().ReverseMap();
        }
    }
}
