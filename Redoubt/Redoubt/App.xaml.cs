using Redoubt.Models;
using Redoubt.Pages;
using Redoubt.Services;
using Redoubt.Services.Interfaces;
using Xamarin.Forms;

namespace Redoubt
{
    public partial class App : Application
    {
        public static Player Player { get; set; }

        public App()
        {
            InitializeComponent();
            DependencyService.Register<IItemService, ItemService>();
            DependencyService.Register<IPlayerService, PlayerService>();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
