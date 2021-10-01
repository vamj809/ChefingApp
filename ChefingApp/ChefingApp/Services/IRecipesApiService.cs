using ChefingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ChefingApp.Services
{
    public interface IRecipesApiService
    {
        Task<ObservableCollection<RecipeHits>> GetRecipesAsync(string query);
    }
}
