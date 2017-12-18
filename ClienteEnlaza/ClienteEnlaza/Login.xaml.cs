using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClienteEnlaza
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        private string nombre;
        private string pass;
		public Login ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing() {
            base.OnAppearing();
            imagenUsuario.Source = ImageSource.FromResource("ClienteEnlaza.img.user.png");
            enviarNombre.Clicked += EnviarNombre_Clicked;
            enviarPass.Clicked += EnviarPass_Clicked;
            registro.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked()));
        }

        private void OnLabelClicked()
        {
            Navigation.PushAsync(new Registro());
        }

        private void EnviarPass_Clicked(object sender, EventArgs e)
        {
            if (entryPass.Text != null && !entryPass.Text.Equals("")) {
                pass = entryPass.Text;
                layoutPass.IsVisible = false;
                comprobarUsuario();
            }
        }

        private void EnviarNombre_Clicked(object sender, EventArgs e)
        {
            if (entryNombre.Text != null && !entryNombre.Text.Equals("")) {
                layoutNombre.IsVisible = false;
                layoutPass.IsVisible = true;
                nombre = entryNombre.Text;
            }
        }

        private async Task comprobarUsuario() {
            string resultado = await ServicioDeDatoscs.GetAuthAsync(nombre, pass);
            if (resultado.Equals("1"))
            {
                App.usuarioLogeado = await ServicioDeDatoscs.GetUsuarioAsync(nombre, pass);
                Navigation.PushAsync(new Reservar());
            }
            else {
                DisplayAlert("Usuario incorrecto", "Intentelo de nuevo", "OK");
                layoutNombre.IsVisible = true;
            }
        }
    }
}