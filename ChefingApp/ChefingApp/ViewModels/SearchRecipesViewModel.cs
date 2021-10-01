using ChefingApp.Models;
using ChefingApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChefingApp.ViewModels
{
    class SearchRecipesViewModel : BaseViewModel
    {
        public string SearchString { get; set; }
        public ObservableCollection<RecipeHits> RecipesCollection { get; set; }

        public ICommand SearchCommand { get; }
        private IRecipesApiService _recipeApiService;
        public SearchRecipesViewModel()
        {
            SearchCommand = new Command(OnSearchClicked);
            _recipeApiService = new RecipesApiService();
        }

        public async void OnSearchClicked()
        {
            if (string.IsNullOrWhiteSpace(SearchString))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Debe especificar al menos un valor de búsqueda", "OK");
            }
            else if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Debe estar conectado a internet para acceder a nuestros datos", "OK");
            }
            else
            {
                RecipesCollection = await _recipeApiService.GetRecipesAsync(SearchString);
            }
        }
    }
}
