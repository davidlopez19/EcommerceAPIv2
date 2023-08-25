namespace EcommerceAPI.Infraestructura.ECommerce.Repositories.General
{
    public interface ICrudRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetbyID(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
    }
}
