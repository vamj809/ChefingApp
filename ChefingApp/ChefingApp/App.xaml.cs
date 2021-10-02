using Prism;
using Prism.Ioc;
using Prism.Unity;
using ChefingApp.Views;
using ChefingApp.Services;
using ChefingApp.ViewModels;
using Xamarin.Forms;

namespace ChefingApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized() {
            InitializeComponent();

            NavigationService.NavigateAsync($"NavigationPage/SearchRecipes");

            //NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SearchRecipesPage, SearchRecipesViewModel>("SearchRecipes");
            containerRegistry.Register<IJsonSerializerService, JsonSerializerService>();
            containerRegistry.Register<IRecipesApiService, RecipesApiService>();

            //containerRegistry.RegisterForNavigation<MainPage>("MainPage");
            //containerRegistry.RegisterForNavigation<>();
        }
    }
}
