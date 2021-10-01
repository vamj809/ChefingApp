using ChefingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChefingApp.Services
{
    public class RecipesApiService : IRecipesApiService
    {
        private HttpClient _httpClient;
        IJsonSerializerService serializer = new JsonSerializerService();
        private const string ApiApplicationID = "8acfdcef";
        private const string ApiAccessKey = "YOUR ACCESS KEY";

        public RecipesApiService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.edamam.com/api/recipes/v2")
            };
        }
        public async Task<ObservableCollection<RecipeHits>> GetRecipesAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"?type=public&app_id={ApiApplicationID}&app_key={ApiAccessKey}&q={query}&field=label&field=image&field=url");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                RecipeSearchResults recipeResponse = serializer.Deserialize<RecipeSearchResults>(responseString);

                return recipeResponse.Hits;
            }

            return null;
        }
    }
}
