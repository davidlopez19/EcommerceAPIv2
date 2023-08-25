using AutoMapper;
using EcommerceAPI.Common.Classes.Contracts.Compras;
using EcommerceAPI.Common.Classes.Contracts.Productos;
using EcommerceAPI.Dominio.Services.Ecommerce.General;
using EcommerceAPI.Infraestructura.Database.Entities.Compras;
using EcommerceAPI.Infraestructura.Database.Entities.Productos;
using EcommerceAPI.Infraestructura.ECommerce.Repositories.Compras;
using EcommerceAPI.Infraestructura.ECommerce.Repositories.General;
using EcommerceAPI.Infraestructura.ECommerce.Repositories.Productos;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Compras
{
    public class ComprasService : ICrudService<ComprasContract>
    {
        private readonly ICrudRepository<ComprasEntities> _repository;
        private readonly ICrudRepository<DetalleComprasEntities> _repositoryDetalles;
        private readonly ICrudRepository<ProductosEntities> _repositoryProductos;
        private readonly IDetalleComprasRepository _detalleComprasRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public ComprasService(ICrudRepository<ComprasEntities> repository
            , IDetalleComprasRepository detalleComprasRepository
            , IMapper mapper
            , ICrudRepository<DetalleComprasEntities> repositoryDetalles
            , ICrudRepository<ProductosEntities> repositoryProductos
            , IStockRepository stockRepository
            )
        {
            _repository = repository;
            _detalleComprasRepository = detalleComprasRepository;
            _mapper = mapper;
            _repositoryDetalles = repositoryDetalles;
            _repositoryProductos = repositoryProductos;
            _stockRepository = stockRepository;
        }


        public async Task<List<ComprasContract>> GetAll()
        {
            List<ComprasContract> compras = _mapper.Map<List<ComprasContract>>(await _repository.GetAll());
            if (compras != null)
            {
                compras.ForEach(x =>
                {
                    x.detalles = _mapper.Map<List<DetalleComprasContract>>(_detalleComprasRepository.GetDetallesCompra(x.id_compra).Result);
                    x.detalles?.ForEach(y =>
                    {
                        y.Producto = _mapper.Map<ProductosContract>(_repositoryProductos.GetbyID(y.id_producto).Result);
                        y.Producto.Stock = _mapper.Map<StockContract>(_stockRepository.GetStockByProducto(y.id_producto).Result);
                    });
                });
            }
            return compras;
        }
        public async Task<ComprasContract> GetbyID(int id)
        {
            ComprasContract compra = _mapper.Map<ComprasContract>(await _repository.GetbyID(id));
            if (compra != null)
            {
                compra.detalles = _mapper.Map<List<DetalleComprasContract>>(await _detalleComprasRepository.GetDetallesCompra(compra.id_compra));
                foreach (DetalleComprasContract detalle in compra.detalles)
                {
                    detalle.Producto = _mapper.Map<ProductosContract>(await _repositoryProductos.GetbyID(detalle.id_producto));
                    if (detalle.Producto != null)
                        detalle.Producto.Stock = _mapper.Map<StockContract>(await _stockRepository.GetStockByProducto(detalle.id_producto));
                }
            }
            return compra;
        }
        public async Task<ComprasContract> Create(ComprasContract contract)
        {
            ComprasContract compra = _mapper.Map<ComprasContract>(await _repository.Create(_mapper.Map<ComprasEntities>(contract)));
            if (compra != null)
            {
                //Inserta detalles
                foreach (DetalleComprasContract detalle in contract.detalles)
                {
                    detalle.id_compra = compra.id_compra;
                    DetalleComprasContract _detalle = _mapper.Map<DetalleComprasContract>(await _repositoryDetalles.Create(_mapper.Map<DetalleComprasEntities>(detalle)));
                    if (_detalle != null)
                    {
                        _detalle.Producto = _mapper.Map<ProductosContract>(await _repositoryProductos.GetbyID(detalle.id_producto));
                        if (_detalle.Producto != null)
                            _detalle.Producto.Stock = _mapper.Map<StockContract>(await _stockRepository.GetStockByProducto(detalle.id_producto));
                        compra.detalles.Add(_detalle);
                    }
                }
            }
            return compra;
        }
        public async Task<ComprasContract> Update(ComprasContract contract)
        {
            ComprasContract compra = _mapper.Map<ComprasContract>(await _repository.Update(_mapper.Map<ComprasEntities>(contract)));
            if (compra != null)
            {
                return await GetbyID(compra.id_compra);
            }
            return compra;
        }
    }
}
