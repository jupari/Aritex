using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Aritex.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Aritex
{

    using Views;
    public partial class App : Application
    {
        public static NavigationPage  Navigator { get; internal set; }

        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQ4NzhAMzEzNjJlMzIyZTMwWUtNYW04ZERLQi9SaEdXVDhuUFlua2xLazhMVHJWM0d4SnduTTVhVFhuWT0=");

            InitializeComponent();

            MainViewModel.GetInstance().Contenido = new ContenidoViewModel();
            MainPage =new NavigationPage(new ContenidoPage());
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
