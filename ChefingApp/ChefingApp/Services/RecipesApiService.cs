﻿using ChefingApp.Models;
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
        public async Task<ObservableCollection<RecipeHits>> GetRecipesAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"?type=public&app_id={Config.ApiApplicationID}&app_key={Config.ApiAccessKey}&q={query}&field=label&field=image&field=url");

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
