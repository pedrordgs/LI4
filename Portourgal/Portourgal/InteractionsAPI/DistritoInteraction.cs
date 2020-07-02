using Newtonsoft.Json;
using Portourgal.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
                HttpResponseMessage response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/distritos/").ConfigureAwait(false);
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

        public static async Task<Distrito> GetDistrito(string nomeASCII)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/distritos/nome/"+ nomeASCII).ConfigureAwait(false);
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

        public static async void UpdateDistrito(string nomeASCII, Distrito d)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("https://portourgalapi2020.azurewebsites.net/api/distritos/nome/" + nomeASCII, content);
            }
        }
    }
}
