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
    public static class RoteiroInteraction
    {
        public static async Task<List<Roteiro>> GetRoteiros()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/roteiros/").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Roteiro> roteiros = JsonConvert.DeserializeObject<List<Roteiro>>(json);
                    return roteiros;
                }
                else return null;
            }
            return null;
        }
    }
}
