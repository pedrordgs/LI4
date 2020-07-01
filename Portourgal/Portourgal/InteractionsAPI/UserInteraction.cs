using Portourgal.Model;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.Collections.Generic;

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
                HttpResponseMessage response = await client.PostAsync("https://portourgalapi2020.azurewebsites.net/api/users/", content);
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
                HttpResponseMessage response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/users/email/" + email);
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
                HttpResponseMessage response = await client.PutAsync("https://portourgalapi2020.azurewebsites.net/api/users/email/"+email, content);
                user = u;
                if (response.IsSuccessStatusCode) return u;
            }
            return null;
        }

        public static async void updateUser()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("https://portourgalapi2020.azurewebsites.net/api/users/email/" + user.Email, content);
                response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/users/email/" + user.Email);
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    Utilizador u = JsonConvert.DeserializeObject<Utilizador>(json);
                    //user = u;
                    user = u;
                }
            }
        }

        public static async Task<List<Utilizador>> getUtilizadores()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/users/").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    List<Utilizador> u = JsonConvert.DeserializeObject<List<Utilizador>>(json);
                    return u;
                }
            }
            return null;
        }

        public static void terminarSessao()
        {
            user = null;
        }
    }
}
