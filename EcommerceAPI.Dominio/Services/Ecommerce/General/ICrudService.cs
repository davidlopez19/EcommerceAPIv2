namespace EcommerceAPI.Dominio.Services.Ecommerce.General
{
    public interface ICrudService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetbyID(int id);
        Task<T> Create(T contract);
        Task<T> Update(T contract);
    }
}
