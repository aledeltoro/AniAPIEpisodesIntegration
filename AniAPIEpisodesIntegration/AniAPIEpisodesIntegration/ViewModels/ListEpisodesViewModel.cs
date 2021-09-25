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

        private IDisplayAlertService _displayAlertService;

        public ICommand DownloadEpisodeCommand { get; set; }

        public ListEpisodesViewModel() { }

        public ListEpisodesViewModel(ObservableCollection<Episode> episodesList, IDisplayAlertService displayAlertService)
        {
            _displayAlertService = displayAlertService;
            DownloadEpisodeCommand = new Command<string>(DownloadEpisode);
            EpisodesList = episodesList;
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
    }
}
