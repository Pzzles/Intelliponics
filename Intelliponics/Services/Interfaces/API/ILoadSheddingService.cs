using System.Threading.Tasks;

namespace Intelliponics.Services.Interfaces
{
    public interface ILoadSheddingService
    {
        Task<string> GetStatusAsync();
        Task<string> GetAreaAsync(string areaId);
        //Task<string> GetAreasNearbyAsync(double latitude, double longitude);
        Task<string> SearchAreasAsync(string searchText);
        //Task<string> GetTopicsNearbyAsync(double latitude, double longitude);
        Task<string> GetApiAllowanceAsync();
    }
}
