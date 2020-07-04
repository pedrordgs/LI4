using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PortourgalAdmin.Model;

namespace PortourgalAdmin.Pages
{
    public class RoteirosModel : PageModel
    {
        public void OnGet()
        {
            Roteiros = GetRoteiros().Result;
        }

        public async Task<List<Roteiro>> GetRoteiros()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/roteiros/").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                String json = await response.Content.ReadAsStringAsync();
                List<Roteiro> r = JsonConvert.DeserializeObject<List<Roteiro>>(json);
                return r;
            }
            else
                return new List<Roteiro>();
        }

        public List<Roteiro> Roteiros { get; set; }
    }
}
