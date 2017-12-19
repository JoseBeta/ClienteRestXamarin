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
    public partial class Vuelo : ContentPage
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Aeropuerto Aerpouerto1 { get; set; }
        public Aeropuerto Aeropuerto2 { get; set; }
        public float Precio { get; set; }
        public bool Selected { get; internal set; }

        public Vuelo()
        {
            InitializeComponent();
        }
    }
}