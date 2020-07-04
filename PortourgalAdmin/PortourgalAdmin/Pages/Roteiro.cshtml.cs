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
    public class RoteiroModel : PageModel
    {
        public void OnGet(string nome, string cid, string ascii)
        {
            Roteiro = GetRoteiro(ascii).Result;
        }

        public async Task<Roteiro> GetRoteiro(string ascii)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/roteiros/nome/" + ascii).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                String json = await response.Content.ReadAsStringAsync();
                Roteiro r = JsonConvert.DeserializeObject<Roteiro>(json);
                return r;
            }
            else return null;
        }

        public Roteiro Roteiro { get; set; }
    }
}
