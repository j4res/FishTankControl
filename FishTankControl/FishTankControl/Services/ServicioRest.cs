using FishTankControl.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FishTankControl.Services
{
    public class ServicioRest
    {

     //   public async void Conectar()
     //   {   
     //       try
     //       {

     //           if (!CrossConnectivity.Current.IsConnected)
     //           {
     //               return;
     //           }

     //           using (var httpClient = new HttpClient())
     //           {
					//var llamada = await httpClient.GetAsync("http://restcountries.eu/rest/v2/all").ConfigureAwait(false);
                    
					//if (llamada.IsSuccessStatusCode)
					//{
					//	var json = await llamada.Content.ReadAsStringAsync().ConfigureAwait(false);

					//	var resultado = JsonConvert.DeserializeObject<PezJSON[]>(json);
					//}
     //               //var resultado = await httpClient.GetAsync("/").ConfigureAwait(false);

     //               //var codigo = resultado.StatusCode;
     //           }
     //       }
     //       catch (Exception ex)
     //       {

     //       }

     //   }


        public async Task<string> ConsultarInformacionPez(Pez pPez)
        {
            string json = string.Empty;
            string urlConsulta = CrearUrlConsultaInformacionPez(pPez);

            try
            {

                if (!CrossConnectivity.Current.IsConnected)
                {
                    json = string.Empty;
                }

                using (var httpClient = new HttpClient())
                {
                    var llamada = await httpClient.GetAsync(urlConsulta).ConfigureAwait(false);

                    if (llamada.IsSuccessStatusCode)
                    {
                        json = await llamada.Content.ReadAsStringAsync().ConfigureAwait(false);
                    }

                }
            }
            catch (Exception ex)
            {
                json = string.Empty;
            }

            return json;
        }


        //public async void ConsultarImagenPez(Pez pez)
        //{
        //    try
        //    {

        //        if (!CrossConnectivity.Current.IsConnected)
        //        {
        //            return;
        //        }

        //        using (var httpClient = new HttpClient())
        //        {
        //            var llamada = await httpClient.GetAsync("http://restcountries.eu/rest/v2/all").ConfigureAwait(false);

        //            if (llamada.IsSuccessStatusCode)
        //            {
        //                var json = await llamada.Content.ReadAsStringAsync().ConfigureAwait(false);

        //                var resultado = JsonConvert.DeserializeObject<PezJSON[]>(json);
        //            }
        //            //var resultado = await httpClient.GetAsync("/").ConfigureAwait(false);

        //            //var codigo = resultado.StatusCode;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}


        private string CrearUrlConsultaInformacionPez(Pez pez)
        {
            string resultado = string.Empty;
            const string urlPrimeraSeccion = "https://en.wikipedia.org/w/api.php?action=query&prop=extracts&explaintext&redirects&format=json&titles=";

            resultado = urlPrimeraSeccion + pez.Genero + "_" + pez.Especie;
            
            return resultado;
        }

        //private string CrearUrlConsultaImagenPez(Pez pez)
        //{
        //    string resultado = string.Empty;
        //    const string urlPrimeraSeccion = "https://en.wikipedia.org/w/api.php?action=query&prop=extracts&explaintext&redirects&format=json&titles=";

        //    resultado = urlPrimeraSeccion + pez.Genero + "_" + pez.Especie;

        //    return resultado;
        //}

    }
}
