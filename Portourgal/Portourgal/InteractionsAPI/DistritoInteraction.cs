using Newtonsoft.Json;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Portourgal.InteractionsAPI
{
    public static class DistritoInteraction
    {
     
        public static async Task<List<Distrito>> GetDistritos()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://portourgalapi.azurewebsites.net/api/distritos/").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Distrito> distritos = JsonConvert.DeserializeObject<List<Distrito>>(json);
                    return distritos;
                }
                else return null;
            }
            return null;
        }

        public static async Task<Distrito> GetDistritos(string nome)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://portourgalapi.azurewebsites.net/api/distritos/nome/"+nome).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Distrito distrito = JsonConvert.DeserializeObject<Distrito>(json);
                    return distrito;
                }
                else return null;
            }
            return null;
        }
    }
}
