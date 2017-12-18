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
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            enviarRegistro.Clicked += EnviarRegistro_Clicked;
        }


        private void EnviarRegistro_Clicked(object sender, EventArgs e)
        {
            registrarUsuario();
        }

        private async Task registrarUsuario()
        {
            if (validar()) {
                await ServicioDeDatoscs.Registro(nombre.Text, pass.Text, fNacimiento.Date.ToString("yyyy-MM-dd"));
                App.usuarioLogeado = await ServicioDeDatoscs.GetUsuarioAsync(nombre.Text, pass.Text);
                Navigation.PushAsync(new Reservar());
            }
        }

        public bool validar() {
            bool correcto = false;
            if (nombre.Text != null && !nombre.Text.Equals(""))
            {
                if (pass.Text != null && !pass.Text.Equals(""))
                {
                    if (validarPass())
                    {
                        correcto = true;
                    }
                }
                else {
                    DisplayAlert("Contraseña vacia", "Debe rellenar la contraseña", "OK");
                }
            }else {
                DisplayAlert("Nombre vacio", "Debe rellenar el nombre", "OK");
            }

            return correcto;
        }

        public bool validarPass() {
            bool correcto = false;
            if (pass.Text.Equals(repetirPass.Text))
            {
                correcto = true;
            }
            else {
                DisplayAlert("Error con la contraseña","Las contraseñas no coinciden","OK");
            }

            return correcto;
        }
    }
}