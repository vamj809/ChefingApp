using Prism.Navigation;
using ChefingApp.Models;
using System.Collections.ObjectModel;
using Prism.Commands;
using ChefingApp.Helpers;

namespace ChefingApp.ViewModels
{
    public class HomeViewModel : BaseRecipeNavigationViewModel
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
        public ObservableCollection<RecipeCategory> MealsOfTheDayList { get; set; }
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            MealsOfTheDayList = Recipe.MealTypes;
        }
    }
}
