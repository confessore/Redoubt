using Redoubt.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Redoubt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        StatsViewModel ViewModel { get; }

        public StatsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = ViewModel = new StatsViewModel();
            ViewModel.Navigation = Navigation;
        }
    }
}