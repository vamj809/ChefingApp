using Prism.Navigation;
using ChefingApp.Models;
using System.Collections.ObjectModel;
using Prism.Commands;
using ChefingApp.Helpers;
using Xamarin.Essentials;
using Prism.Services;
using ChefingApp.Services;
using System.Linq;
using System.Collections.Generic;
using System;

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
        public async void GetSuggestedRecipes()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await _pageDialog.DisplayAlertAsync(AppResources.WarningDisplayTitle, AppResources.SearchRecipesDisconnectionError, AppResources.AcceptButtonText);
            }
            else
            {
                Random randomIndex = new Random();
                ObservableCollection<RecipeHits> recipes = await _recipeApiService.GetRecipesAsync(Recipe.MealTypes[randomIndex.Next(0, Recipe.MealTypes.Count)].Description, true);
                RecipesSuggestions = recipes.Take(5);
            }
        }

        private readonly IRecipesApiService _recipeApiService;
        private readonly IPageDialogService _pageDialog;
        public IEnumerable<RecipeHits> RecipesSuggestions { get; set; }
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
