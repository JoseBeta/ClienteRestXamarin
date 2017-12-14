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
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string FNacimiento { get; set; }
        public List<Busqueda> Busquedas { get; set; }
        public List<Reserva> Reservas { get; set; }
        public Usuario()
        {
            InitializeComponent();
        }
    }
}