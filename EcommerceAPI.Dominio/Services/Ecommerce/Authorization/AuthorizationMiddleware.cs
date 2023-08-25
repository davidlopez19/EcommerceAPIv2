using EcommerceAPI.Dominio.Services.Ecommerce.Authenticate;
using EcommerceAPI.Dominio.Services.Ecommerce.Clientes;
using Microsoft.AspNetCore.Http;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Authorization
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IClientesService clienteService, IJWTService jwtService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var idCliente = jwtService.ValidationToken(token);
            if (idCliente != null)
            {
                // attach user to context on successful jwt validation
                context.Items["Cliente"] = await clienteService.GetById(idCliente.Value);
            }

            await _next(context);

        }
    }
}
