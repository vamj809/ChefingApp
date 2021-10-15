using ChefingApp.Helpers;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefingApp.ViewModels
{
    public class RecipeDetailsViewModel : BaseViewModel
    {
        public DelegateCommand PreviewRecipeCommand { get; }
        public RecipeDetailsViewModel(INavigationService navigationService) : base(navigationService)
        {
            PreviewRecipeCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(NavigationConstants.Paths.RecipeViewer);
            });
        }
    }
}
