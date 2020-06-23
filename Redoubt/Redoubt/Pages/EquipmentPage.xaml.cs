using Redoubt.Models;
using Redoubt.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Redoubt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquipmentPage : ContentPage
    {
        EquipmentViewModel ViewModel { get; }

        public EquipmentPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = ViewModel = new EquipmentViewModel();
            ViewModel.Navigation = Navigation;
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e) =>
            await Navigation.PushAsync(new EquipmentDetailPage((Item)e.Item));
    }
}