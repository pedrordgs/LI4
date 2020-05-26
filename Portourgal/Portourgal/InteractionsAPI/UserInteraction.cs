using Portourgal.Model;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Newtonsoft.Json;

namespace Portourgal.InteractionsAPI
{
    public static class UserInteraction
    {
        public static Utilizador user;

        public static async Task<Utilizador> AddUtilizadorDB(Utilizador u)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://portourgalapi.azurewebsites.net/api/users/", content);
                user = u;
                if (response.IsSuccessStatusCode) return u;
            }
            return null;
        }

        public static async Task<bool> AutenticaUtilizador(String email, String password)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://portourgalapi.azurewebsites.net/api/users/" + email);
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    Utilizador u = JsonConvert.DeserializeObject<Utilizador>(json);
                    //user = u;
                    if (u != null && u.Password == password && email == u.Email) { user = u; return true; }
                    else return false;
                }
            }
            return false;
        }

        public static async Task<Utilizador> EditaUtilizador(String email, Utilizador u)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("https://portourgalapi.azurewebsites.net/api/users/"+email, content);
                user = u;
                if (response.IsSuccessStatusCode) return u;
            }
            return null;
        }
    }
}
