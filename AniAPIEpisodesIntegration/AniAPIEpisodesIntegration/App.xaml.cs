using AniAPIEpisodesIntegration.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AniAPIEpisodesIntegration
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SearchEpisodesPage()) { 
                BarBackgroundColor = Color.FromHex("#00A19D")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
