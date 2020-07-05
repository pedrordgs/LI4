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
    public class NovaAtracaoModel : PageModel
    {
        public void OnGet(string dascii, string cid)
        {
            DASCII = dascii;
            Cid = cid;
        }

        public ActionResult OnPost(string ascii, string cid)
        {
            if (String.IsNullOrEmpty(Request.Form["nome"]) || String.IsNullOrEmpty(Request.Form["localidade"]) || String.IsNullOrEmpty(Request.Form["historia"]) || String.IsNullOrEmpty(Request.Form["imagem"]))
                return new RedirectToPageResult("/Cidade",new { nome = cid, dascii = ascii });
            string nome = Request.Form["nome"];
            string localidade = Request.Form["localidade"];
            string historia = Request.Form["historia"];
            string imagem = Request.Form["imagem"];
            Atracao a = new Atracao(nome, localidade, historia, imagem, new List<Avaliacao>());
            AddAtracao(ascii, cid, a);
            return new RedirectToPageResult("/Cidade", new { nome = cid, dascii = ascii });
        }

        public async void AddAtracao(string ascii, string cid, Atracao a)
        {
            Distrito d = GetDistrito(ascii).Result;
            Cidade c = d.Cidades.FirstOrDefault(x => x.Nome == cid);
            c.Atracoes.Add(a);
            d.Cidades.RemoveAll(x => x.Nome == cid);
            d.Cidades.Add(c);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://portourgalapi2020.azurewebsites.net/api/distritos/nome/"+ascii, content);
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

        public string DASCII { get; set; }
        public string Cid { get; set; }
    }
}
