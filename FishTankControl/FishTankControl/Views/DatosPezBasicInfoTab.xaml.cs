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
    public partial class DatosPezBasicInfoTab : ContentPage
    {
        public Pez Pez { get; set; }

        public DatosPezBasicInfoTab()
        {

            //ESTO SE DEBE SUSTITUIR POR LA CARGA DEL PEZ DESDE LA BD, DE ACUERDO AL IDENTIFICADOR RESPECTIVO
            Pez PezTemp = new Pez
            {
                Genero = "paracheirodon",
                Especie = "innesi"
            };

            InitializeComponent();

            var servicio = new Services.ServicioRest();

            string titulo = string.Empty;
            string extracto = string.Empty;
            string descripcion = string.Empty;

            #region ConsultarInformacion

            var jsonTask = servicio.ConsultarInformacionPez(PezTemp);

            string jsonString = jsonTask.Result;

            JObject obj = JObject.Parse(jsonString);

            var paginaNula = obj.Last.Last.Last.Last["-1"];
              
            var informacionPez = obj.Last.Last.Last.Last.Last.Last;
            titulo = informacionPez["title"].ToString();
            extracto = informacionPez["extract"].ToString();

            descripcion = extracto;
            


            #endregion ConsultarInformacion


            Pez = new Pez
            {
                Nombre = titulo,
                Genero = PezTemp.Genero,
                Especie = PezTemp.Especie,
                Descripcion = descripcion
            };

            BindingContext = this;
        }

    }
}
