using FishTankControl.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FishTankControl.Services
{
    public class ServicioRest
    {

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


        public async Task<string> ConsultarImagenPez(Pez pPez)
        {
            string json = string.Empty;
            string URLImagen = string.Empty;
            string urlConsulta = CrearUrlConsultaImagenPez(pPez);

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
        
        private string CrearUrlConsultaInformacionPez(Pez pez)
        {
            string resultado = string.Empty;
            const string urlPrimeraSeccion = "https://en.wikipedia.org/w/api.php?action=query&prop=extracts&explaintext&redirects&format=json&titles=";

            resultado = urlPrimeraSeccion + pez.Genero + "_" + pez.Especie;
            
            return resultado;
        }

        private string CrearUrlConsultaImagenPez(Pez pez)
        {
            string resultado = string.Empty;
            const string urlPrimeraSeccion = "https://en.wikipedia.org/w/api.php?action=query&prop=images&redirects&format=json&titles=";

            resultado = urlPrimeraSeccion + pez.Genero + "_" + pez.Especie;

            return resultado;
        }

    }
}
