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
    public class AtracaoModel : PageModel
    {
        public void OnGet(string nome, string cid, string ascii)
        {
            Distrito d = GetDistrito(ascii).Result;
            Ascii = ascii;
            Cid = cid;
            Atracao = d.Cidades.FirstOrDefault(x => x.Nome == cid).Atracoes.FirstOrDefault(a => a.Nome == nome);
        }

        public IActionResult OnPostDelete(string asciiname, string cid, string nome)
        {
            Distrito d = GetDistrito(asciiname).Result;
            DeleteAtracao(d, cid, nome);
            return new RedirectToPageResult("/Cidade", new { dascii = asciiname, nome=cid});
        }

        public async void DeleteAtracao(Distrito d, string cid, string nome)
        {
            Cidade c = d.Cidades.FirstOrDefault(x=> x.Nome==cid);
            c.Atracoes.RemoveAll(a => a.Nome == nome);
            d.Cidades.RemoveAll(x => x.Nome == cid);
            d.Cidades.Add(c);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://portourgalapi2020.azurewebsites.net/api/distritos/nome/" + d.ASCIIName, content);
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

        public Atracao Atracao { get; set; }
        public string Ascii { get; set; }
        public string Cid { get; set; }
    }
}
