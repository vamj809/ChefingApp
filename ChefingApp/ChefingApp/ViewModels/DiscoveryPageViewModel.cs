using Prism.Commands;
using Prism.Navigation;
using ChefingApp.Helpers;
using ChefingApp.Models;
using System.Collections.ObjectModel;

namespace ChefingApp.ViewModels
{
    public class DiscoveryPageViewModel : BaseRecipeNavigationViewModel
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
                    GoToSearchCommand.Execute(
                        _selectedRecipeCategory.IsInternal ? null : _selectedRecipeCategory.Description);
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
