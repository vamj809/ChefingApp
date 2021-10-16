using ChefingApp.Helpers;
using ChefingApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefingApp.ViewModels
{
    public class BaseRecipeNavigationViewModel : BaseViewModel
    {
        public DelegateCommand<string> GoToSearchCommand { get; }

        public BaseRecipeNavigationViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoToSearchCommand = new DelegateCommand<string>(async (query) =>
            {
                await navigationService.NavigateAsync($"{NavigationConstants.Paths.SearchRecipes}", new NavigationParameters()
                {
                    { NavigationConstants.Parameters.RecipeCategory, query }
                });
            });
        }
    }
}
