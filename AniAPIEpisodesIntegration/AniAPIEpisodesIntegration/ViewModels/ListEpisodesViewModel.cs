using AniAPIEpisodesIntegration.Models;
using AniAPIEpisodesIntegration.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AniAPIEpisodesIntegration.ViewModels
{
    public class ListEpisodesViewModel: BaseViewModel
    {
        public ObservableCollection<Models.Episode> EpisodesList { get; set; }

        private IAniApiService _aniApiService;

        public ListEpisodesViewModel() { }

        public ListEpisodesViewModel(IAniApiService aniApiService)
        {
            _aniApiService = aniApiService;
            LoadAnimeEpisodesAsync();
        }

        private async void LoadAnimeEpisodesAsync()
        {
            var response = await _aniApiService.GetEpisodesAsync();
            EpisodesList = new ObservableCollection<Episode>(response.Data.Episodes);
        }

    }
}
