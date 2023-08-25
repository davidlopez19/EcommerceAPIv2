using EcommerceAPI.Common.Classes.Contracts.Authenticate;
using EcommerceAPI.Dominio.Services.Ecommerce.Authenticate;
using EcommerceAPI.Dominio.Services.Ecommerce.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequestContract request)
        {
            LoginResponseContract cliente = await _authenticateService.Login(request);
            if (cliente != null)
                return Ok(cliente);

            return NotFound();
        }
    }
}
