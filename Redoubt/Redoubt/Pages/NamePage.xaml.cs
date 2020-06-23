using Redoubt.Services.Interfaces;
using Redoubt.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Redoubt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NamePage : ContentPage
    {
        IPlayerService PlayerService => DependencyService.Get<IPlayerService>();

        NameViewModel ViewModel { get; }

        public NamePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = ViewModel = new NameViewModel();
            ViewModel.Navigation = Navigation;
        }

        async void OnSaveGame(object sender, EventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(ViewModel.Name))
            {
                App.Player = await PlayerService.NewPlayerAsync(ViewModel.Name);
                await PlayerService.SavePlayerAsync();
                var previous = Navigation.NavigationStack.LastOrDefault();
                await Navigation.PushAsync(new HomePage());
                Navigation.RemovePage(previous);
            }
        }
    }
}