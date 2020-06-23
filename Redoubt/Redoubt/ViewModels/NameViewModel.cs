namespace Redoubt.ViewModels
{
    public class NameViewModel : BaseViewModel
    {
        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
    }
}
