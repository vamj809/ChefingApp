using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefingApp.ViewModels
{
    public class RecipeViewerViewModel : BaseViewModel
    {
        public string RecipeUrl { get; }
        public RecipeViewerViewModel(INavigationService navigationService) : base(navigationService)
        {
            //TempURL
            RecipeUrl = "https://www.google.com.do";
        }
    }
}
