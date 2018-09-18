﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Aritex
{

    using Views;
    public partial class App : Application
    {
        public static NavigationPage  Navigator { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage(new U_CotizacionPage());
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
