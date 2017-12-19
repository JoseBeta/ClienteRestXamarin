using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ClienteEnlaza
{
    public partial class App : Application
    {
        internal static object usuarioLogeado;
        public static string nombre;
        public static string pass;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ClienteEnlaza.MainPage());
            Usuario usuarioLogeado = new Usuario();
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
