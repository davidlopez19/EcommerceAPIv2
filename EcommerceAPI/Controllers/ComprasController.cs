using EcommerceAPI.Common.Classes.Contracts.Compras;
using EcommerceAPI.Dominio.Services.Ecommerce.Authorization;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComprasController : ControllerBase
    {
        private readonly ICrudService<ComprasContract> _service;
        public ComprasController(ICrudService<ComprasContract> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ComprasContract> compras = await _service.GetAll();
            if (compras.Any())
                return Ok(compras);

            return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ComprasContract compra = await _service.GetbyID(id);
            if (compra != null)
                return Ok(compra);

            return NoContent();
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Create(ComprasContract contract)
        {
            contract = await _service.Create(contract);
            if (contract != null)
            {
                return Ok(contract);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Update(ComprasContract contract)
        {
            contract = await _service.Update(contract);
            if (contract != null)
            {
                return Ok(contract);
            }
            return BadRequest();
        }
    }
}
