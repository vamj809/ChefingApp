using Prism.Navigation;
using PropertyChanged;
using System.ComponentModel;

namespace ChefingApp.ViewModels
{
    [SuppressPropertyChangedWarnings]
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected INavigationService NavigationService;
    }
}
