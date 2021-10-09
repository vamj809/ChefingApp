using Prism.Commands;
using Prism.Navigation;
using ChefingApp.Helpers;

namespace ChefingApp.ViewModels
{
    public class DiscoveryPageViewModel : BaseViewModel
    {
        public string Title { get; set; }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        private readonly INavigationService _navigationService;
        public DiscoveryPageViewModel(INavigationService navigationService)
        {
            Title = "Discovery Page";
            _navigationService = navigationService;
        }

        async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync(NavigationConstants.Paths.SearchRecipes);
        }
    }
}
