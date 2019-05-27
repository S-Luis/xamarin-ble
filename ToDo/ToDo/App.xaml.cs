using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDo.Views;

namespace ToDo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            SetMainPage();
        }
        public static void SetMainPage()
        {
            Current.MainPage = new NavigationPage(new MainPage());
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
