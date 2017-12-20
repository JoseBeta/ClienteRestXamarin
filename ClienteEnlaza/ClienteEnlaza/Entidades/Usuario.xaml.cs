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
    public partial class Usuario : ContentPage
    {
        new public int  Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string FNacimiento { get; set; }
        public List<Busqueda> Busquedas { get; set; }
        public List<Reserva> Reservas { get; set; }

        public Usuario()
        {
            InitializeComponent();
            labelNombre.Text = "Nombre: "+App.nombre;
            labelPass.Text = "Contraseña: " + App.pass;
            borrar.Clicked += Borrar_Clicked;
            butonPass.Clicked += ButonPass_Clicked;
        }

        private void ButonPass_Clicked(object sender, EventArgs e)
        {
            cambiarContrasena();
        }

        private void Borrar_Clicked(object sender, EventArgs e)
        {
            borrarUsuario();
        }

        public async Task cambiarContrasena() {
            if (nuevoPass.Text != null && !nuevoPass.Text.Equals(""))
            {
                await ServicioDeDatoscs.cambiarContrasena(nuevoPass.Text);
                App.pass = nuevoPass.Text;
                labelPass.Text = "Contraseña: " + nuevoPass.Text;
            }
            else {
                DisplayAlert("El campo esta vacio", "Debe rellenar el campo para cambiar la contraseña", "OK");
            }
        }

        public async Task borrarUsuario() {
            await ServicioDeDatoscs.BorrarUsuario();
            DisplayAlert("Usuario borrado", "El usuario actual se ha borrado de la base de datos", "OK");
            Navigation.PushAsync(new MainPage());
        }
    }
}