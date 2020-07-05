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
    public class NovaCidadeModel : PageModel
    {
        public void OnGet(string asciiname)
        {
            ASCII = asciiname;
        }

        public ActionResult OnPost(string ascii)
        {
            Distrito d = GetDistrito(ascii).Result;
            if (String.IsNullOrEmpty(Request.Form["nome"])) return new RedirectToPageResult("/Distrito", new { ascii = d.ASCIIName });
            string nome = Request.Form["nome"];
            Cidade c = new Cidade(nome, new List<Atracao>(), new List<Restaurante>(), new List<Hotel>());
            AddCidade(d,c);
            return new RedirectToPageResult("/Distrito",new { ascii = d.ASCIIName });
        }

        public async void AddCidade(Distrito d, Cidade c)
        {
            d.Cidades.Add(c);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://portourgalapi2020.azurewebsites.net/api/distritos/nome/"+d.ASCIIName, content);
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

        public string ASCII { get; set; }
    }
}
