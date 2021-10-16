using ChefingApp.Helpers;
using ChefingApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChefingApp.ViewModels
{
    public class BaseNavigationViewModel : BaseViewModel
    {
        public DelegateCommand<NavigationParams> NavigateToPageCommand { get; }

        public BaseNavigationViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToPageCommand = new DelegateCommand<NavigationParams>(NavigateAsyncToPage);
        }

        public async void NavigateAsyncToPage(NavigationParams navigationParams)
        {
            await NavigationService.NavigateAsync(
                navigationParams.DestinationPage,
                navigationParams.ParameterName == null || navigationParams.ParameterObject == null ? null : new NavigationParameters() {
                    { navigationParams.ParameterName, navigationParams.ParameterObject }
                },
                navigationParams.IsModal
            );
        }
    }
}
