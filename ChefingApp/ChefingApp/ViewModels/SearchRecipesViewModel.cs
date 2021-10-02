using ChefingApp.Models;
using ChefingApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Prism.Mvvm;

namespace ChefingApp.ViewModels
{
    public class SearchRecipesViewModel : BaseViewModel
    {
        //private string _title;

        //public string Title
        //{
        //    get { return _title; }
        //    set { SetPriority(ref _title, value); }
        //}

        //private DelegateCommand _navigateCommand;
        //private readonly INavigationService _navigationService;

        //public DelegateCommand NavigateCommand =>
        //    _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));



        //public SearchRecipesViewModel(INavigationService navigationService)
        //{
        //    Title = "Main Page";
        //    _navigationService = navigationService;
        //}

        //async void ExecuteNavigateCommand()
        //{
        //    await _navigationService.NavigateAsync("");
        //}



        public string SearchString { get; set; }
        public ObservableCollection<RecipeHits> RecipesCollection { get; set; }

        public DelegateCommand SearchCommand { get; }
        private readonly IRecipesApiService _recipeApiService;
        private readonly IPageDialogService _pageDialog;
        public SearchRecipesViewModel(IPageDialogService pageDialog)
        {
            SearchCommand = new DelegateCommand(OnSearchClicked);
            _recipeApiService = new RecipesApiService();
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
