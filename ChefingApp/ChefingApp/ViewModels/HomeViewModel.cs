using Prism.Navigation;
using ChefingApp.Models;
using System.Collections.ObjectModel;

namespace ChefingApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<RecipeCategory> MealsOfTheDayList { get; set; }
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            MealsOfTheDayList = Recipe.MealTypes;
        }
    }
}
