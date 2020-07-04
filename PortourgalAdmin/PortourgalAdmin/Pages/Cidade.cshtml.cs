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
    public class CidadeModel : PageModel
    {
        public void OnGet(string nome, string dascii)
        {
            Distrito = GetDistrito(dascii).Result;
            Cidade = Distrito.Cidades.FirstOrDefault(x => x.Nome == nome);
        }

        public async Task<Distrito> GetDistrito(string ascii)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/distritos/nome/" + ascii).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                String json = await response.Content.ReadAsStringAsync();
                Distrito d = JsonConvert.DeserializeObject<Distrito>(json);
                return d;
            }
            else return null;
        }

        public Cidade Cidade { get; set; }
        public Distrito Distrito { get; set; }
    }
}
