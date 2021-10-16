using ChefingApp.Helpers;
using ChefingApp.Models;
using Prism.Commands;
using Prism.Navigation;

namespace ChefingApp.ViewModels
{
    public class RecipeDetailsViewModel : BaseViewModel, IInitialize
    {
        public RecipeItem Recipe { get; set; }
        public DelegateCommand PreviewRecipeCommand { get; }
        public RecipeDetailsViewModel(INavigationService navigationService) : base(navigationService)
        {
            PreviewRecipeCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.Paths.RecipeViewer, new NavigationParameters()
                {
                    { NavigationConstants.Parameters.RecipeUrl, Recipe.Url }
                });
            });
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(NavigationConstants.Parameters.RecipeItem, out RecipeItem recipeItem))
            {
                Recipe = recipeItem;
            }
        }
    }
}
