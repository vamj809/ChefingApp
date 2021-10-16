using Prism.Commands;
using Prism.Navigation;
using ChefingApp.Helpers;
using ChefingApp.Models;
using System.Collections.ObjectModel;

namespace ChefingApp.ViewModels
{
    public class DiscoveryPageViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public ObservableCollection<RecipeCategory> DiscoveryMeals { get; set; }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        public DiscoveryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Discovery Page";
            DiscoveryMeals = Recipe.DishTypes;
        }

        async void ExecuteNavigateCommand()
        {
            await NavigationService.NavigateAsync(NavigationConstants.Paths.SearchRecipes);
        }
    }
}
