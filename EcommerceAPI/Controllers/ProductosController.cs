using EcommerceAPI.Common.Classes.Contracts.Productos;
using EcommerceAPI.Dominio.Services.Ecommerce.Authorization;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly ICrudService<ProductosContract> _productosService;
        public ProductosController(ICrudService<ProductosContract> productosService)
        {
            _productosService = productosService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ProductosContract> productos = await _productosService.GetAll();
            if (productos.Any())
                return Ok(productos);

            return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ProductosContract producto = await _productosService.GetbyID(id);
            if (producto != null)
                return Ok(producto);

            return NoContent();
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Create(ProductosContract producto)
        {
            producto = await _productosService.Create(producto);
            if (producto != null)
            {
                return Ok(producto);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Update(ProductosContract producto)
        {
            producto = await _productosService.Update(producto);
            if (producto != null)
            {
                return Ok(producto);
            }
            return BadRequest();
        }

    }
}
