using ChefingApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using ChefingApp.Helpers;

namespace ChefingApp.Services
{
    public class RecipesApiService : IRecipesApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonSerializerService _serializer;

        public RecipesApiService(IJsonSerializerService jsonSerializer)
        {
            _serializer = jsonSerializer;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Config.ApiBaseUrl)
            };
        }
        /*public async bool isQueryValid(string query)
        {
            if (string.IsNullOrWhiteSpace(SearchString))
            {
                await _pageDialog.DisplayAlertAsync(AppResources.AlertDisplayTitle, AppResources.SearchRecipesEmptyFieldError, AppResources.AcceptButtonText);
            }
            else if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await _pageDialog.DisplayAlertAsync(AppResources.WarningDisplayTitle, AppResources.SearchRecipesDisconnectionError, AppResources.AcceptButtonText);
            }
            return true;
        }*/
        public async Task<ObservableCollection<RecipeHits>> GetRecipesAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"?type=public&app_id={Config.ApiApplicationID}&app_key={Config.ApiAccessKey}&q={query}&field=label&field=image&field=url&field=ingredientLines&field=calories&field=source");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                RecipeSearchResults recipeResponse = _serializer.Deserialize<RecipeSearchResults>(responseString);

                return recipeResponse.Hits;
            }

            return null;
        }
    }
}
