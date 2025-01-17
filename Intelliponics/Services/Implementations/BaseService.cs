using Intelliponics.Repositories.Interfaces;
using Intelliponics.Services.Interfaces;

namespace Intelliponics.Services.Implementations
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(int id, T entity)
        {
            return await _repository.UpdateAsync(id, entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }


}
