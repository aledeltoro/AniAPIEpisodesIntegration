using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AniAPIEpisodesIntegration.Services
{
    public class DisplayAlertService : IDisplayAlertService
    {
        public Task DisplayInfoAlert(string title, string message)
        {
            return App.Current.MainPage.DisplayAlert(title, message, "Ok");
        }

        public Task<bool> DisplayOptionAlert(string title, string message)
        {
            return App.Current.MainPage.DisplayAlert(title, message, "Yes", "No");
        }
    }
}
