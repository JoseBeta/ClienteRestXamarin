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

            boton.Clicked += Boton_Clicked;
        }

        private async void Boton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

    }
}
