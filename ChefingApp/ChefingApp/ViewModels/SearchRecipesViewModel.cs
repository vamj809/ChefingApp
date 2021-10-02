using ChefingApp.Models;
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

        //private DelegateCommand _navigateCommand;

        //public DelegateCommand NavigateCommand =>
        //    _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        public string SearchString { get; set; }
        public ObservableCollection<RecipeHits> RecipesCollection { get; set; }

        public DelegateCommand SearchCommand { get; }
        private readonly INavigationService _navigationService;
        private readonly IRecipesApiService _recipeApiService;
        private readonly IPageDialogService _pageDialog;
        public SearchRecipesViewModel(IPageDialogService pageDialog, IRecipesApiService recipesApiService, INavigationService navigationService)
        {
            SearchCommand = new DelegateCommand(OnSearchClicked);
            Title = "Search Recipes";
            _recipeApiService = recipesApiService;
            _navigationService = navigationService;
            _pageDialog = pageDialog;
        }

        public async void OnSearchClicked()
        {
            if (string.IsNullOrWhiteSpace(SearchString))
            {
                await _pageDialog.DisplayAlertAsync("Alerta", "Debe especificar al menos un valor de búsqueda", "OK");
            }
            else if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await _pageDialog.DisplayAlertAsync("Advertencia", "Debe estar conectado a internet para acceder a nuestros datos", "OK");
            }
            else
            {
                RecipesCollection = await _recipeApiService.GetRecipesAsync(SearchString);
            }
        }
    }
}
