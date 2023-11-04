using Entity;

namespace Data
{
    public interface IRepository<T>
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
    }
}