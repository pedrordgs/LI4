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
    public class NovoHotelModel : PageModel
    {
        public void OnGet(string dascii, string cid)
        {
            DASCII = dascii;
            Cid = cid;
        }

        public ActionResult OnPost(string ascii, string cid)
        {
            if (String.IsNullOrEmpty(Request.Form["nome"]) || String.IsNullOrEmpty(Request.Form["morada"]) || String.IsNullOrEmpty(Request.Form["classificacao"]) || String.IsNullOrEmpty(Request.Form["imagem"]))
                return new RedirectToPageResult("/Cidade", new { nome = cid, dascii = ascii });
            string nome = Request.Form["nome"];
            string morada = Request.Form["morada"];
            double classificacao = double.Parse(Request.Form["classificacao"]);
            string imagem = Request.Form["imagem"];
            Hotel h = new Hotel(nome, morada, classificacao, imagem);
            AddHotel(ascii, cid, h);
            return new RedirectToPageResult("/Cidade", new { nome = cid, dascii = ascii });
        }

        public async void AddHotel(string ascii, string cid, Hotel h)
        {
            Distrito d = GetDistrito(ascii).Result;
            Cidade c = d.Cidades.FirstOrDefault(x => x.Nome == cid);
            c.Hoteis.Add(h);
            d.Cidades.RemoveAll(x => x.Nome == cid);
            d.Cidades.Add(c);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync("https://portourgalapi2020.azurewebsites.net/api/distritos/nome/" + ascii, content);
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
