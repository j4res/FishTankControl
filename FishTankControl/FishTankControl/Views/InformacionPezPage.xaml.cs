using FishTankControl.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

            string titulo = string.Empty;
            string extracto = string.Empty;
            string descripcion = string.Empty;
            bool encontroDatos = true;

            #region ConsultarInformacion

            var jsonTask = servicio.ConsultarInformacionPez(pPez);

            string jsonString = jsonTask.Result;

            JObject obj = JObject.Parse(jsonString);

            var paginaNula = obj.Last.Last.Last.Last["-1"];
            
            if (paginaNula != null)
            {
                encontroDatos = false;
                descripcion = "NO SE ENCONTRARON DATOS PARA EL PEZ BUSCADO";
            }                    
           
            if (encontroDatos)
            {
                
                var informacionPez = obj.Last.Last.Last.Last.Last.Last;
                titulo = informacionPez["title"].ToString();
                extracto = informacionPez["extract"].ToString();

                #region ConsultarImagen

                var imagenPezTask = servicio.ConsultarImagenPez(pPez);
                string URLImagen = ObtenerURLImagen(imagenPezTask.Result);
                ImagenPez.Source = new UriImageSource()
                {
                    Uri = new Uri(URLImagen)
                };

                #endregion region ConsultarImagen

                descripcion = extracto;
            }
            
            #endregion ConsultarInformacion
            

            Pez = new Pez
            {
                Nombre = titulo,
                Genero = pPez.Genero,
                Especie = pPez.Especie,
                Descripcion = descripcion
            };

            BindingContext = this;
        }

        private string ObtenerURLImagen(string jsonString)
        {
            string URLImagen = string.Empty;
            string URLPrimeraParte = "https://en.wikipedia.org/wiki/";
            string URLSegundaParte = string.Empty;
            string URLTerceraParte = "#/media/";
            string URLCuartaParte = string.Empty;


            JObject obj = JObject.Parse(jsonString);
            var imagenes = obj.Last.Last["pages"].Last.Last;

            URLSegundaParte = imagenes["title"].ToString().Replace(" ", "_");

            var nombresImagenes = imagenes["images"];

            foreach (var nombre in nombresImagenes)
            {
                var nombreString = nombre["title"].ToString();
                var extension = Path.GetExtension(nombreString).ToUpper();

                if (extension == ".JPG" || extension == ".JPEG")
                {
                    URLCuartaParte = nombreString;
                }

            }

            URLImagen = URLPrimeraParte + URLSegundaParte + URLTerceraParte + URLCuartaParte;

            return URLImagen;
        }

        private void AgregarAAcuario_Clicked(object sender, EventArgs e)
        {

        }
    }
}
