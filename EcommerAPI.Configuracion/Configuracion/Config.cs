using AutoMapper;
using EcommerceAPI.Infraestructura.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace EcommerceAPI.Configuracion.Configuracion
{
    public class Config
    {

        /// <summary>
        /// Metodo para completar la configuración del proyecto.
        /// </summary>
        /// <param name="services">servicios de inicio</param>
        /// <param name="configuration">configuración de inicio</param>
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            #region [Configuración Perfil AutoMapper]
            var configMapper = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapper()));
            var mapper = configMapper.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region [Inicializar Conexion con Base de Datos]
            services.AddTransient<ApplicationContext, ApplicationContext>();
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
            services.AddSingleton<IConfiguration>(configuration);

            #endregion

            #region [Registro Inyección de Dependencias]
            var assembliesToScan = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.Load("EcommerceAPI.Dominio"),
                Assembly.Load("EcommerceAPI.Infraestructura"),
                Assembly.Load("EcommerceAPI.Common"),
            };
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.Name.EndsWith("Repository") ||
                       c.Name.EndsWith("Service") ||
                       c.Name.EndsWith("Resource"))
                .AsPublicImplementedInterfaces();
            #endregion
        }
    }
}
