using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClienteEnlaza
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Esperar();
        }

        private async Task Esperar()
        {
            logo.Source = ImageSource.FromResource("ClienteEnlaza.img.logo.png");
            await Task.Delay(3000);
            Navigation.PushAsync(new Login());
        }
    }
}
