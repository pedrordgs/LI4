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
    public class DistritosModel : PageModel
    {
        public void OnGet()
        {
            Distritos = GetDistritos().Result;
        }

        public async Task<List<Distrito>> GetDistritos()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/distritos/").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                String json = await response.Content.ReadAsStringAsync();
                List<Distrito> d = JsonConvert.DeserializeObject<List<Distrito>>(json);
                return d;
            }
            else
                return new List<Distrito>();
        }

        public List<Distrito> Distritos { get; set; }
    }
}
