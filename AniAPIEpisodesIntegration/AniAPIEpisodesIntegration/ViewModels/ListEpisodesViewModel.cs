using AniAPIEpisodesIntegration.Models;
using AniAPIEpisodesIntegration.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AniAPIEpisodesIntegration.ViewModels
{
    public class ListEpisodesViewModel : BaseViewModel
    {
        public ObservableCollection<Models.Episode> EpisodesList { get; set; }

        private IAniApiService _aniApiService;
        private IDisplayAlertService _displayAlertService;

        public bool IsLoading { get; set; }

        public ICommand SearchEpisodesCommand { get; set; }
        public ICommand DownloadEpisodeCommand { get; set; }

        public ListEpisodesViewModel() { }

        public ListEpisodesViewModel(IAniApiService aniApiService, IDisplayAlertService displayAlertService)
        {
            _aniApiService = aniApiService;
            _displayAlertService = displayAlertService;

            SearchEpisodesCommand = new Command(SearchEpisodes);
            DownloadEpisodeCommand = new Command<string>(DownloadEpisode);
        }

        private async void DownloadEpisode(string videoURL)
        {
            var videoURI = new Uri(videoURL);

            bool canOpenBrowser = await _displayAlertService.DisplayOptionAlert("Info", "Are you sure you want to continue and download the episode");

            if (canOpenBrowser)
            {
                await Browser.OpenAsync(videoURI, BrowserLaunchMode.SystemPreferred);
            }
        }

        private async void SearchEpisodes()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                IsLoading = true;

                var response = await _aniApiService.GetEpisodesAsync();

                IsLoading = false;

                EpisodesList = new ObservableCollection<Episode>(response.Data.Episodes);
            }
            else
            {
                await _displayAlertService.DisplayInfoAlert("Error", "Missing network connection. Try again later");

            }
        }

    }
}
