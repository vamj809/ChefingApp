using Prism.Commands;
using Prism.Navigation;
using ChefingApp.Helpers;
using ChefingApp.Models;
using System.Collections.ObjectModel;

namespace ChefingApp.ViewModels
{
    public class DiscoveryPageViewModel : BaseNavigationViewModel
    {
        private RecipeCategory _selectedRecipeCategory;
        public RecipeCategory SelectedRecipeCategory
        {
            get
            {
                return _selectedRecipeCategory;
            }
            set
            {
                _selectedRecipeCategory = value;
                if (_selectedRecipeCategory != null)
                {
                    NavigateToPageCommand.Execute(
                        new NavigationParams(
                            _selectedRecipeCategory.IsInternal ? NavigationConstants.Paths.Discovery : NavigationConstants.Paths.SearchRecipes,
                            NavigationConstants.Parameters.RecipeCategory, _selectedRecipeCategory.Description)
                        );
                }
            }
        }
        public ObservableCollection<RecipeCategory> DiscoveryMeals { get; set; }
        public DiscoveryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            DiscoveryMeals = Recipe.DishTypes;
        }
    }
}
