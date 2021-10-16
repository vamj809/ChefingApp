using Prism.Navigation;
using ChefingApp.Models;
using System.Collections.ObjectModel;
using Prism.Commands;
using ChefingApp.Helpers;
using Xamarin.Essentials;
using Prism.Services;
using ChefingApp.Services;
using System.Linq;

namespace ChefingApp.ViewModels
{
    public class HomeViewModel : BaseNavigationViewModel
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
        private RecipeHits _selectedRecipe;
        public RecipeHits SelectedRecipe
        {
            get
            {
                return _selectedRecipe;
            }
            set
            {
                _selectedRecipe = value;
                if (_selectedRecipe != null)
                {
                    _ = 3;
                }
            }
        }
        private readonly IRecipesApiService _recipeApiService;
        private readonly IPageDialogService _pageDialog;
        public async void GetSuggestedRecipes()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await _pageDialog.DisplayAlertAsync(AppResources.WarningDisplayTitle, AppResources.SearchRecipesDisconnectionError, AppResources.AcceptButtonText);
            }
            else
            {
                RecipesSuggestions = await _recipeApiService.GetRecipesAsync("a",true);
                RecipesSuggestions = (ObservableCollection<RecipeHits>)RecipesSuggestions.Take(5);
            }
        }
        public ObservableCollection<RecipeHits> RecipesSuggestions { get; set; }
        public ObservableCollection<RecipeCategory> MealsOfTheDayList { get; set; }
        public HomeViewModel(INavigationService navigationService, IPageDialogService pageDialog, IRecipesApiService recipesApiService) : base(navigationService)
        {
            _pageDialog = pageDialog;
            _recipeApiService = recipesApiService;
            MealsOfTheDayList = Recipe.MealTypes;
            GetSuggestedRecipes();
        }
    }
}
