using EcommerceAPI.Common.Classes.Contracts.Clientes;
using EcommerceAPI.Dominio.Services.Ecommerce.Authorization;
using EcommerceAPI.Dominio.Services.Ecommerce.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clienteService;
        public ClientesController(IClientesService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ClientesContract> clientes = await _clienteService.GetAll();
            if (clientes.Any())
                return Ok(clientes);

            return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ClientesContract cliente = await _clienteService.GetById(id);
            if (cliente != null)
                return Ok(cliente);

            return NoContent();
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Create(ClientesContract cliente)
        {
            cliente = await _clienteService.Create(cliente);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Update(ClientesContract cliente)
        {
            cliente = await _clienteService.Update(cliente);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await _clienteService.Delete(id));
        }
    }
}
