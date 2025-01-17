namespace Intelliponics.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
    }

}
