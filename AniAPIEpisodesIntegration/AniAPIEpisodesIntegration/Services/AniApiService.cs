using AniAPIEpisodesIntegration.Models;
using Refit;
using System.Threading.Tasks;

namespace AniAPIEpisodesIntegration.Services
{
    public class AniApiService : IAniApiService
    {
        public const string ANI_API_BASE_URL = "https://api.aniapi.com";

        private IAniApi _aniApi;

        private IJsonSerializerService _serializer = new JsonSerializerService();

        public AniApiService()
        {
            _aniApi = RestService.For<IAniApi>(ANI_API_BASE_URL);
        }

        public async Task<EpisodesListResponse> GetEpisodesAsync()
        {
            var response = await _aniApi.GetEpisodesAsync();

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();

                var episodesListResponse = _serializer.Deserialize<EpisodesListResponse>(responseString);

                return episodesListResponse;
            }

            return null;
        }
    }
}
