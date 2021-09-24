using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AniAPIEpisodesIntegration.Services
{
    public interface IAniApi
    {
        [Get("/v1/episode?locale=it&anime_id=1")]
        Task<HttpResponseMessage> GetEpisodesAsync();
    }
}
