using AniAPIEpisodesIntegration.Models;
using AniAPIEpisodesIntegration.Services;
using AniAPIEpisodesIntegration.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AniAPIEpisodesIntegration.ViewModels
{
    public class SearchEpisodesViewModel : BaseViewModel
    {
        public bool IsLoading { get; set; }
        public ICommand SearchEpisodesCommand { get; set; }

        private IAniApiService _aniApiService;
        private IDisplayAlertService _displayAlertService;

        public SearchEpisodesViewModel() { }

        public SearchEpisodesViewModel(IDisplayAlertService displayAlertService, IAniApiService aniApiService)
        {
            _displayAlertService = displayAlertService;
            _aniApiService = aniApiService;

            SearchEpisodesCommand = new Command(SearchEpisodes);
        }

        private async void SearchEpisodes()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                IsLoading = true;

                var response = await _aniApiService.GetEpisodesAsync();

                IsLoading = false;

                var episodesList = new ObservableCollection<Episode>(response.Data.Episodes);

                await App.Current.MainPage.Navigation.PushAsync(new ListEpisodesPage(episodesList));
            }
            else
            {
                await _displayAlertService.DisplayInfoAlert("Error", "Missing network connection. Try again later");

            }
        }
    }
}
