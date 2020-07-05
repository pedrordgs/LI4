using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PortourgalAdmin.Model;

namespace PortourgalAdmin.Pages
{
    public class NovoRoteiroModel : PageModel
    {
        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            if (String.IsNullOrEmpty(Request.Form["nome"]) || String.IsNullOrEmpty(Request.Form["ascii"]) || String.IsNullOrEmpty(Request.Form["dist"]) || String.IsNullOrEmpty(Request.Form["percurso"]) || String.IsNullOrEmpty(Request.Form["desc"]) || String.IsNullOrEmpty(Request.Form["imagemroteiro"]) || String.IsNullOrEmpty(Request.Form["imagempercurso"]))
                return new RedirectToPageResult("/Roteiros");
            string nome = Request.Form["nome"];
            string ascii = Request.Form["ascii"];
            int dist = Int32.Parse(Request.Form["dist"]);
            List<string> percurso =Request.Form["percurso"].ToString().Split(';').ToList();
            string desc = Request.Form["desc"];
            string imagemroteiro = Request.Form["imagemroteiro"];
            string imagempercurso = Request.Form["imagempercurso"];
            Roteiro r = new Roteiro(nome, ascii, dist, percurso, desc, imagemroteiro, imagempercurso);
            AddRoteiroAsync(r);
            return new RedirectToPageResult("/Roteiros");
        }

        public async void AddRoteiroAsync(Roteiro r)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://portourgalapi2020.azurewebsites.net/api/roteiros/", content);
        }
    }
}
