using Prism;
using Prism.Ioc;
using Prism.Unity;
using ChefingApp.Views;
using ChefingApp.ViewModels;

namespace ChefingApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized() {
            InitializeComponent();

            MainPage = new SearchRecipesPage();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SearchRecipesPage, SearchRecipesViewModel>();
        }
    }
}
