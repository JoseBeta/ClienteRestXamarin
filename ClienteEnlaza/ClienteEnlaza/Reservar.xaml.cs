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
    public partial class Reservar : ContentPage
    {
        private Reserva reserva = new Reserva();
        private int numViajeros;
        private int cont = 0;
        private string origen;
        private string destino;
        List<Vuelo> vuelos = new List<Vuelo>();

        public Reservar()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            enviarViajero.Clicked += EnviarViajero_Clicked;
            enviarReserva.Clicked += EnviarReserva_Clicked;
        }

        private void EnviarReserva_Clicked(object sender, EventArgs e)
        {
            if (pickerOrigen.SelectedIndex >= 0)
            {
                origen = pickerOrigen.SelectedItem.ToString();
                if (pickerDestino.SelectedIndex >= 0)
                {
                    destino = pickerDestino.SelectedItem.ToString();
                    if (!String.IsNullOrEmpty(entryViajero.Text) || !String.IsNullOrWhiteSpace(entryViajero.Text))
                    {
                        numViajeros = Convert.ToInt32(entryViajero.Text);
                        layoutReservar.IsVisible = false;
                        layoutViajero.IsVisible = true;
                    }
                    else
                    {
                        DisplayAlert("Error numero de viajeros", "El numero de viajeros no puede esta vacior", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Destino vacio", "Debe seleccionar destino", "OK");
                }
            }
            else {
                DisplayAlert("Origen vacio", "Debe seleccionar origen", "OK");
            }
        }

        private async Task encontrarVuelos() {
            vuelos = await ServicioDeDatoscs.getVuelosAsync(origen, destino);
            layoutViajero.Children.Add(new Label { Text = vuelos.Count().ToString() });
        }

        private void EnviarViajero_Clicked(object sender, EventArgs e)
        {
            guardarViajeros();
        }

        private async Task guardarViajeros() {

            if (cont < numViajeros)
            {
                reserva.Viajeros.Add(new Viajero());
                cont++;
            }
            else {
                Navigation.PushAsync(new MainPage());
            }
        }

        private Viajero NuevoViajero()
        {
            Viajero viajero = new Viajero();
            if (!String.IsNullOrWhiteSpace(entryNombre.Text) || !String.IsNullOrEmpty(entryNombre.Text))
            {
                if (!String.IsNullOrWhiteSpace(entryDni.Text) || !String.IsNullOrEmpty(entryDni.Text))
                {
                    viajero.Nombre = entryNombre.Text;
                    if (entryDni.Text.Length == 9)
                    {
                            viajero.Dni = entryDni.Text;
                    }
                    else {
                        DisplayAlert("Error en el dni", "El dni introducido no es valido", "OK");
                        return null;
                    }
                    viajero.FNacimiento = fNacimiento.Date.ToString("yyyy-MM-dd");
                    return viajero;
                }
            }

            DisplayAlert("Viajero no valido", "Los campos de viajero no pueden estar vacios", "OK");
            return null;
        }
    }
}