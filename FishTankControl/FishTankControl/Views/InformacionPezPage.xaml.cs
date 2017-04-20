using FishTankControl.Models;
using Newtonsoft.Json.Linq;
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
    public partial class InformacionPezPage : ContentPage
    {
        public Pez Pez { get; set; }

        public InformacionPezPage(Pez pPez)
        {
            InitializeComponent();

            var servicio = new Services.ServicioRest();

            var jsonTask = servicio.ConsultarInformacionPez(pPez);

            string jsonString = jsonTask.Result;

            if (!string.IsNullOrEmpty(jsonString)) {

                JObject obj = JObject.Parse(jsonString);

                //string extracto = (string)obj["extract"]["img_url"]; (string)obj["extract"];
            }

            Pez = new Pez
            {
                Genero = pPez.Genero,
                Especie = pPez.Especie,
                Descripcion = jsonString
            };

            BindingContext = this;
        }

        private void AgregarAAcuario_Clicked(object sender, EventArgs e)
        {

        }
    }
}
