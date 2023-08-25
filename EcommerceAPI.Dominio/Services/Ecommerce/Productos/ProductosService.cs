using AutoMapper;
using EcommerceAPI.Common.Classes.Contracts.Productos;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using EcommerceAPI.Infraestructura.Database.Entities.Productos;
using EcommerceAPI.Infraestructura.ECommerce.Repositories.General;
using EcommerceAPI.Infraestructura.ECommerce.Repositories.Productos;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Productos
{
    public class ProductosService : ICrudService<ProductosContract>
    {
        private readonly ICrudRepository<ProductosEntities> _productosRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public ProductosService(ICrudRepository<ProductosEntities> productosRepository, IMapper mapper, IStockRepository stockRepository)
        {
            _productosRepository = productosRepository;
            _mapper = mapper;
            _stockRepository = stockRepository;
        }
        public async Task<ProductosContract> Create(ProductosContract producto)
        {
            ProductosContract _producto = _mapper.Map<ProductosContract>(await _productosRepository.Create(_mapper.Map<ProductosEntities>(producto)));
            if (_producto.id_producto > 0)
            {
                //Inserta Stock
                _producto.Stock = new StockContract();
                _producto.Stock.cantidad = producto.Stock.cantidad;
                _producto.Stock.id_producto = _producto.id_producto;
                _producto.Stock = _mapper.Map<StockContract>(await _stockRepository.Create(_mapper.Map<StockEntities>(_producto.Stock)));
            }
            return _producto;
        }

        public async Task<List<ProductosContract>> GetAll()
        {
            List<ProductosContract> productos = _mapper.Map<List<ProductosContract>>(await _productosRepository.GetAll());
            productos.ForEach(p =>
            {
                p.Stock = _mapper.Map<StockContract>(_stockRepository.GetStockByProducto(p.id_producto).Result);
            });
            return productos;
        }

        public async Task<ProductosContract> GetbyID(int id)
        {
            ProductosContract producto = _mapper.Map<ProductosContract>(await _productosRepository.GetbyID(id));
            producto.Stock = _mapper.Map<StockContract>(_stockRepository.GetStockByProducto(producto.id_producto).Result);
            return producto;
        }

        public async Task<ProductosContract> Update(ProductosContract producto)
        {
            ProductosContract _producto = _mapper.Map<ProductosContract>(await _productosRepository.Update(_mapper.Map<ProductosEntities>(producto)));
            if (_producto != null)
            {
                _producto.Stock = _mapper.Map<StockContract>(_stockRepository.GetStockByProducto(_producto.id_producto).Result);
                _producto.Stock.cantidad = producto.Stock.cantidad;
                //Actualiza Stock del Productos
                _producto.Stock = _mapper.Map<StockContract>(await _stockRepository.Update(_mapper.Map<StockEntities>(_producto.Stock)));
            }
            return _producto;
        }
    }
}
