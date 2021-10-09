using Prism;
using Prism.Ioc;
using Prism.Unity;
using ChefingApp.Views;
using ChefingApp.Services;
using ChefingApp.ViewModels;
using Xamarin.Forms;
using ChefingApp.Helpers;

namespace ChefingApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(NavigationConstants.Paths.BaseLayoutPage);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<BaseLayoutPage>();
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.RegisterForNavigation<DiscoveryPage>();
            containerRegistry.RegisterForNavigation<SearchRecipesPage, SearchRecipesViewModel>(NavigationConstants.Paths.SearchRecipes);
            containerRegistry.Register<IJsonSerializerService, JsonSerializerService>();
            containerRegistry.Register<IRecipesApiService, RecipesApiService>();
        }
    }
}
