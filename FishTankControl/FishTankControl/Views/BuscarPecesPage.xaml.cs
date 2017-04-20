using FishTankControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FishTankControl.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarPecesPage : ContentPage
    {

        public Pez Pez { get; set; }

        public BuscarPecesPage()
        {
            InitializeComponent();

            Pez = new Pez
            {
                Genero = "paracheirodon",
                Especie = "innesi"
            };

            BindingContext = this;
        }
                
        async private void BotonBuscar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InformacionPezPage(this.Pez));
        }
    }
}
