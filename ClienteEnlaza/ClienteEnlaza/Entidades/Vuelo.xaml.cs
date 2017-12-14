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
        public Aeropuerto Aerpuerto1 { get; set; }
        public Aeropuerto Aerpuerto2 { get; set; }
        public string Fecha{get; set;}
        public float Precio { get; set; }

        public Vuelo()
        {
            InitializeComponent();
        }
    }
}