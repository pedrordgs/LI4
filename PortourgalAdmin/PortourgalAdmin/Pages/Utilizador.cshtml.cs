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
    public class UtilizadorModel : PageModel
    {
        public void OnGet(string email)
        {
            Utilizador = GetUtilizador(email).Result;
        }
        public IActionResult OnPostDelete(string email)
        {
            DeleteUtilizador(email);
            return new RedirectToPageResult("/Utilizadores");
        }

        public async Task<Utilizador> GetUtilizador(string email)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://portourgalapi2020.azurewebsites.net/api/users/email/" + email).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                String json = await response.Content.ReadAsStringAsync();
                Utilizador u = JsonConvert.DeserializeObject<Utilizador>(json);
                return u;
            }
            else return null;
        }

        public async void DeleteUtilizador(string email)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync("https://portourgalapi2020.azurewebsites.net/api/users/email/" + email).ConfigureAwait(false);
        }

        public Utilizador Utilizador { get; set; }
    }
}
