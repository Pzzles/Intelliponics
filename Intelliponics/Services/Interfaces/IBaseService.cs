namespace Intelliponics.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
    }
}
