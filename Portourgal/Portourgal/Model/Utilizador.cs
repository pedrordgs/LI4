using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Portourgal.Model
{
    class Utilizador
    {
        public Utilizador()
        {
            this.Nome = "";
            this.Cidade = "";
            this.Distrito = "";
            this.Email = "";
            this.Password = "";
        }

        public Utilizador(String n, String c, String d, String m, String p)
        {
            this.Nome = n;
            this.Cidade = c;
            this.Distrito = d;
            this.Email = m;
            this.Password = p;
        }

        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Distrito { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public async Task AddUtilizadorDB()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://portourgalapi.azurewebsites.net/api/users/", content);
            }
        }
    }
}
