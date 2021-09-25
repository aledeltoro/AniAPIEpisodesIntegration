using AniAPIEpisodesIntegration.Services;
using AniAPIEpisodesIntegration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AniAPIEpisodesIntegration.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchEpisodesPage : ContentPage
    {
        public SearchEpisodesPage()
        {
            InitializeComponent();
            BindingContext = new SearchEpisodesViewModel(new DisplayAlertService(), new AniApiService());
        }
    }
}