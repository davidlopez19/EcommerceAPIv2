using AutoMapper;
using EcommerceAPI.Dominio.Services.Ecommerce.Clientes;
using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Repositorios.Clientes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NetCore.AutoRegisterDi;
using System.Reflection;
using System.Text;

namespace EcommerceAPI.Configuracion.Inicial
{
    public class Container
    {
        public static void ConfiguracionDependencias(IServiceCollection services, IConfiguration configuration)
        {
            #region [Configuracion de AUTO Mapper]
            var configMapper = new MapperConfiguration(cfg => cfg.AddProfile(new PerfilAutoMapper()));
            var mapper = configMapper.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region [Inyectar depencia de Contexto de BD]
            // services.AddScoped<EcommerceContext, EcommerceContext>();
            services.AddDbContext<EcommerceContext>(options => options.UseSqlServer(configuration.GetConnectionString("ProductsConnection")));
            services.AddSingleton<IConfiguration>(configuration);
            #endregion

            #region [Registro de Inyección de Dependencias]

            //services.AddScoped<IClientesRepository,ClientesRepository>();
            //services.AddTransient<IClientesService, ClientesService>();

            var assembliesToScan = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.Load("ECommerceAPI.Dominio"),
                Assembly.Load("ECommerceAPI.Infraestructura"),
                Assembly.Load("ECommerceAPI.Comunes"),
            };
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.Name.EndsWith("Repository") ||
                       c.Name.EndsWith("Service"))                       
                .AsPublicImplementedInterfaces();
            #endregion

            #region [JWT]
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidIssuer = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
                };
            });
            #endregion
        }
    }
}
