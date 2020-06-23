using Redoubt.Services.Interfaces;
using Redoubt.ViewModels;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Redoubt.Pages
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        IPlayerService PlayerService => DependencyService.Get<IPlayerService>();

        MainViewModel ViewModel { get; }

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = ViewModel = new MainViewModel();
            ViewModel.Navigation = Navigation;
        }

        async void OnNewGame(object sender, EventArgs args)
        {
            var previous = Navigation.NavigationStack.LastOrDefault();
            await Navigation.PushAsync(new NamePage());
            Navigation.RemovePage(previous);
        }

        async void OnLoadGame(object sender, EventArgs args)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/player"))
            {
                await PlayerService.LoadPlayerAsync();
                var previous = Navigation.NavigationStack.LastOrDefault();
                await Navigation.PushAsync(new HomePage());
                Navigation.RemovePage(previous);
            }
        }
    }
}
