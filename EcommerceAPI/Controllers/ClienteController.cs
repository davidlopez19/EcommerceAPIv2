using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Dominio.Services.Ecommerce.Clientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesService _clientesService;

        public ClienteController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clientesService.ObtenerClientes());
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public IActionResult GetbyID(int id)
        {
            return Ok(_clientesService.ObtenerCliente(id));
        }

        [HttpPost]
        [Route("ClienteInsertar")]
        public IActionResult Crear(ClienteContract contract)
        {
            ClienteContract cliente = _clientesService.Crear(contract);
            if (cliente == null)
            {
                return BadRequest();
            }
            return Ok(cliente);
        }

        [HttpPut]
        [Route("ClienteUpdate")]
        public IActionResult Update(ClienteContract contract)
        {
            ClienteContract cliente = _clientesService.Update(contract);
            if (cliente == null)
            {
                return BadRequest("No existe el cliente");
            }
            return Ok(cliente);
        }

        [HttpDelete]
        [Route("[Action]/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_clientesService.Delete(id));
        }
    }
}
