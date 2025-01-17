using Intelliponics.Repositories.Interfaces.API;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Intelliponics.Repositories.Implementations.API
{
    public class LoadSheddingRepository : ILoadSheddingRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _authToken;

        public LoadSheddingRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["LoadSheddingApi:BaseUrl"];
            _authToken = configuration["LoadSheddingApi:AuthToken"];
        }

        private void AddAuthorizationHeader()
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("token"))
            {
                _httpClient.DefaultRequestHeaders.Add("token", _authToken);
            }
        }

        public async Task<string> GetStatusAsync()
        {
            AddAuthorizationHeader();
            var response = await _httpClient.GetAsync($"{_baseUrl}/status");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAreaAsync(string areaId)
        {
            AddAuthorizationHeader();
            var response = await _httpClient.GetAsync($"{_baseUrl}/area?id={areaId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        //public async Task<string> GetAreasNearbyAsync(double latitude, double longitude)
        //{
        //    AddAuthorizationHeader();
        //    var response = await _httpClient.GetAsync($"{_baseUrl}/areas_nearby?lat={latitude}&lon={longitude}");
        //    response.EnsureSuccessStatusCode();
        //    return await response.Content.ReadAsStringAsync();
        //}

        public async Task<string> SearchAreasAsync(string searchText)
        {
            AddAuthorizationHeader();
            var response = await _httpClient.GetAsync($"{_baseUrl}/areas_search?text={searchText}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        //public async Task<string> GetTopicsNearbyAsync(double latitude, double longitude)
        //{
        //    AddAuthorizationHeader();
        //    var response = await _httpClient.GetAsync($"{_baseUrl}/topics_nearby?lat={latitude}&lon={longitude}");
        //    response.EnsureSuccessStatusCode();
        //    return await response.Content.ReadAsStringAsync();
        //}

        public async Task<string> GetApiAllowanceAsync()
        {
            AddAuthorizationHeader();
            var response = await _httpClient.GetAsync($"{_baseUrl}/api_allowance");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
