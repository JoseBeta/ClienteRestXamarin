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
    public partial class Reserva : ContentPage
    {
        public int Id { get; set; }
        public float PrecioParagado { get; set; }
        public Vuelo Vuelo { get; set; }
        public List<Viajero> Viajeros { get; set; }
        public Reserva()
        {
            InitializeComponent();
        }
    }
}