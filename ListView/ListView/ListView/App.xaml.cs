using ListView.View;
using ListView.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ListView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            var mainViewModel = MainViewModel.GetInstance();            // esta comprobando que el main view model este creado
            mainViewModel.Paises = new PaisesViewModel();                //creando y llamando al constructor view model
            this.MainPage = new NavigationPage(new PaisesPage());        //asignando que la pagina principal es paises page
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
