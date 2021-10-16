using ChefingApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ChefingApp.Services
{
    public interface IRecipesApiService
    {
        Task<ObservableCollection<RecipeHits>> GetRecipesAsync(string query, bool randomRequest = false);
    }
}
