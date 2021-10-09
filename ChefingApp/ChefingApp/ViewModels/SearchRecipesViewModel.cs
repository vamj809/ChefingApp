using ChefingApp.Models;
using ChefingApp.Helpers;
using ChefingApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using Xamarin.Essentials;

namespace ChefingApp.ViewModels
{
    class SearchRecipesViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string SearchString { get; set; }
        public RecipeItem SelectedRecipe { get; set; }
        public ObservableCollection<RecipeHits> RecipesCollection { get; set; }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));
        public DelegateCommand SearchCommand { get; }

        private readonly IRecipesApiService _recipeApiService;
        private readonly IPageDialogService _pageDialog;
        public SearchRecipesViewModel(IPageDialogService pageDialog, IRecipesApiService recipesApiService, INavigationService navigationService) : base(navigationService)
        {
            SearchCommand = new DelegateCommand(OnSearchClicked);
            Title = "Search Recipes";
            _recipeApiService = recipesApiService;
            _pageDialog = pageDialog;
        }

        public async void ExecuteNavigateCommand()
        {
            await NavigationService.NavigateAsync(NavigationConstants.Paths.SearchRecipes);
        }

        public async void OnSearchClicked()
        {
            if (string.IsNullOrWhiteSpace(SearchString))
            {
                await _pageDialog.DisplayAlertAsync(AppResources.AlertDisplayTitle, AppResources.SearchRecipesEmptyFieldError, AppResources.AcceptButtonText);
            }
            else if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await _pageDialog.DisplayAlertAsync(AppResources.WarningDisplayTitle, AppResources.SearchRecipesDisconnectionError, AppResources.AcceptButtonText);
            }
            else
            {
                RecipesCollection = await _recipeApiService.GetRecipesAsync(SearchString);
            }
        }
    }
}
