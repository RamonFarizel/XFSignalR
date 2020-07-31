using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSignalR.Views;

namespace XFSignalR
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ChatPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
