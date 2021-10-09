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

        protected override void OnInitialized() {
            InitializeComponent();

            NavigationService.NavigateAsync(NavigationConstants.Paths.HomePage);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.RegisterForNavigation<SearchRecipesPage, SearchRecipesViewModel>(NavigationConstants.Paths.SearchRecipes);
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.Register<IJsonSerializerService, JsonSerializerService>();
            containerRegistry.Register<IRecipesApiService, RecipesApiService>();
        }
    }
}
