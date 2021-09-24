using AniAPIEpisodesIntegration.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AniAPIEpisodesIntegration.Services
{  
    public interface IAniApiService
    {
        Task<EpisodesListResponse> GetEpisodesAsync();
    }
}
