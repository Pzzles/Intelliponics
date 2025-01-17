using Intelliponics.Repositories.Interfaces.API;
using Intelliponics.Services.Interfaces;
using System.Threading.Tasks;

namespace Intelliponics.Services.Implementations
{
    public class LoadSheddingService : ILoadSheddingService
    {
        private readonly ILoadSheddingRepository _loadSheddingRepository;

        public LoadSheddingService(ILoadSheddingRepository loadSheddingRepository)
        {
            _loadSheddingRepository = loadSheddingRepository;
        }

        public async Task<string> GetStatusAsync()
        {
            return await _loadSheddingRepository.GetStatusAsync();
        }

        public async Task<string> GetAreaAsync(string areaId)
        {
            return await _loadSheddingRepository.GetAreaAsync(areaId);
        }

        //public async Task<string> GetAreasNearbyAsync(double latitude, double longitude)
        //{
        //    return await _loadSheddingRepository.GetAreasNearbyAsync(latitude, longitude);
        //}

        public async Task<string> SearchAreasAsync(string searchText)
        {
            return await _loadSheddingRepository.SearchAreasAsync(searchText);
        }

        //public async Task<string> GetTopicsNearbyAsync(double latitude, double longitude)
        //{
        //    return await _loadSheddingRepository.GetTopicsNearbyAsync(latitude, longitude);
        //}

        public async Task<string> GetApiAllowanceAsync()
        {
            return await _loadSheddingRepository.GetApiAllowanceAsync();
        }
    }
}
