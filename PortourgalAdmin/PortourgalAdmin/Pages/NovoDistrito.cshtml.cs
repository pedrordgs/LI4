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
    public class NovoDistritoModel : PageModel
    {
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (String.IsNullOrEmpty(Request.Form["nome"]) || String.IsNullOrEmpty(Request.Form["asciiname"]) || String.IsNullOrEmpty(Request.Form["pontos"]) || String.IsNullOrEmpty(Request.Form["historia"]) || String.IsNullOrEmpty(Request.Form["imagem"])) 
                    return new RedirectToPageResult("/Distritos");
            string nome = Request.Form["nome"];
            string asciiname = Request.Form["asciiname"];
            int pontos = Int32.Parse(Request.Form["pontos"]);
            string historia = Request.Form["historia"];
            string imagem = Request.Form["imagem"];
                Distrito d = new Distrito(nome, asciiname, historia, pontos, new List<Cidade>(), imagem);
            AddDistritoAsync(d);
            return new RedirectToPageResult("/Distritos");
        }

        public async void AddDistritoAsync(Distrito d)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://portourgalapi2020.azurewebsites.net/api/distritos/", content);
        }
    }
}
