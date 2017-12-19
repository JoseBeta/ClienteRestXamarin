using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        private int cont;
        private string origen;
        private string destino;
        List<Vuelo> vuelos = new List<Vuelo>();
        Vuelo vueloSeleccionado = new Vuelo();

        public Reservar()
        {
            InitializeComponent();

            cont = 0;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            enviarReserva.Clicked += EnviarReserva_Clicked;
            enviarVuelo.Clicked += EnviarVuelo_Clicked;
        }

        private void EnviarVuelo_Clicked(object sender, EventArgs e)
        {
            if (vueloSeleccionado != null)
            {
                Reservando();
                layoutVuelo.IsVisible = false;
            }
            else {
                DisplayAlert("Vuelo no seleccionado","Debe seleccionar un vuelo para continuar","OK");
            }
        }

        public async Task Reservando()
        {
            await ServicioDeDatoscs.Reservar(vueloSeleccionado);
            App.usuarioLogeado = await ServicioDeDatoscs.GetUsuarioAsync(App.nombre, App.pass);
            Usuario user = (Usuario) App.usuarioLogeado;

            Navigation.PushAsync(user);
        }

        private void EnviarReserva_Clicked(object sender, EventArgs e)
        {
            if (pickerOrigen.SelectedIndex >= 0)
            {
                origen = pickerOrigen.SelectedItem.ToString();
                if (pickerDestino.SelectedIndex >= 0)
                {
                    destino = pickerDestino.SelectedItem.ToString();
                        encontrarVuelos();
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
            try
            {
                vuelos = await ServicioDeDatoscs.getVuelosAsync(origen, destino);
                vuelosView.ItemsSource = vuelos;
                layoutReservar.IsVisible = false;
                layoutVuelo.IsVisible = true;

                  vuelosView.ItemSelected += async (sender, e) => {

                    if (e.SelectedItem == null) return; // don't do anything if we just de-selected the row

                    vueloSeleccionado.Id = (e.SelectedItem as Vuelo).Id;
                    vueloSeleccionado.Precio = (e.SelectedItem as Vuelo).Precio;

                      // Search the current (last) selected item

                      int lastIdx = vuelos.FindIndex(o => o.Selected == true);

                    if (lastIdx >= 0)
                        vuelos[lastIdx].Selected = false; // De-select the last selected because now I have another selected item

                    // Search on your list the selectedItem
                    int idx = vuelos.FindIndex(o => o.Fecha == (e.SelectedItem as Vuelo).Fecha);

                    // Set "Selected" to selected item
                    vuelos[idx].Selected = true;

                    ((ListView)sender).SelectedItem = null; // de-select the row
                };
            }
            catch {
                DisplayAlert("Error de conexion", "Intentelo de nuevo. Si el problema persiste contacte con nuetros sevicio técnico", "OK");
            }
        }
    }
}