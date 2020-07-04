using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PortourgalAdmin.Model;

namespace PortourgalAdmin.Pages
{
    public class UtilizadoresModel : PageModel
    {
        public void OnGet()
        {
            Utilizadores = GetUtilizadores().Result;
        }

        public async Task<List<Utilizador>> GetUtilizadores()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/users/").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                String json = await response.Content.ReadAsStringAsync();
                List<Utilizador> u = JsonConvert.DeserializeObject<List<Utilizador>>(json);
                return u;
            }
            else
                return new List<Utilizador>();
        }

        public List<Utilizador> Utilizadores { get; set; }
    }
}
