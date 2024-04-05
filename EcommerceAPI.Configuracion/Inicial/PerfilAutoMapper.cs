using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Infraestructura.Database.Entities;

namespace EcommerceAPI.Configuracion.Inicial
{
    public class PerfilAutoMapper : Profile
    {
        public PerfilAutoMapper()
        {
            // si son con lo mismos parametros
            //CreateMap<ClienteEntity, ClienteContract>().ReverseMap();

            //Si son distintos
            CreateMap<ClienteEntity, ClienteContract>()
                    .ForMember(dest => dest.Consecutivo, opt => opt.MapFrom(src => src.id_cliente))
                    .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.nombre))
                    .ForMember(dest => dest.contrasena, opt => opt.MapFrom(src => src.contrasena))
                    .ForMember(dest => dest.correo, opt => opt.MapFrom(src => src.correo))
                    .ForMember(dest => dest.direccioncliente, opt => opt.MapFrom(src => src.direccioncliente))
                    .ForMember(dest => dest.telefono, opt => opt.MapFrom(src => src.telefono))
                    .ReverseMap();
        }
    }
}
