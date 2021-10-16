using ChefingApp.Helpers;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefingApp.ViewModels
{
    public class RecipeViewerViewModel : BaseViewModel, IInitialize
    {
        public string RecipeUrl { get; set; }
        public RecipeViewerViewModel(INavigationService navigationService) : base(navigationService) { }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(NavigationConstants.Parameters.RecipeUrl, out string recipeUrl))
            {
                RecipeUrl = recipeUrl;
            }
        }
    }
}
