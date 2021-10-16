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
    class SearchRecipesViewModel : BaseNavigationViewModel, IInitialize
    {
        public string Title { get; set; }
        public string SearchString { get; set; }

        private RecipeHits _selectedRecipe;
        public RecipeHits SelectedRecipe
        {
            get {
                return _selectedRecipe;
            }
            set {
                _selectedRecipe = value;
                if(_selectedRecipe != null)
                {
                    NavigateToPageCommand.Execute(
                        new NavigationParams(
                            NavigationConstants.Paths.RecipeDetails,
                            NavigationConstants.Parameters.RecipeItem,
                            _selectedRecipe.Recipe
                        )
                    );
                }
            }
        }
        public ObservableCollection<RecipeHits> RecipesCollection { get; set; }
        public DelegateCommand<RecipeHits> GoToRecipeDetailsCommand { get; set; }
        public DelegateCommand SearchCommand { get; }

        private readonly IRecipesApiService _recipeApiService;
        private readonly IPageDialogService _pageDialog;
        public SearchRecipesViewModel(IPageDialogService pageDialog, IRecipesApiService recipesApiService, INavigationService navigationService) : base(navigationService)
        {
            SearchCommand = new DelegateCommand(OnSearchClicked);
            _recipeApiService = recipesApiService;
            _pageDialog = pageDialog;
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

        public void Initialize(INavigationParameters parameters)
        {
            _selectedRecipe = null;
            if (parameters.TryGetValue(NavigationConstants.Parameters.RecipeCategory, out string searchString))
            {
                SearchString = searchString;
                if(SearchString != null)
                {
                    OnSearchClicked();
                }
            }
        }
    }
}
