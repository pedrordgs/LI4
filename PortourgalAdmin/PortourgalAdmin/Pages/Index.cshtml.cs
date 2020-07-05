using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PortourgalAdmin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if (String.IsNullOrEmpty(Request.Form["email"]) || String.IsNullOrEmpty(Request.Form["pwd"])) return new RedirectToPageResult("/Index");
            string email = Request.Form["email"];
            string pwd = Request.Form["pwd"];
            byte[] data = Encoding.ASCII.GetBytes(pwd);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hashpwd = Encoding.ASCII.GetString(data);

            byte[] data2 = Encoding.ASCII.GetBytes("admin");
            data2 = new System.Security.Cryptography.SHA256Managed().ComputeHash(data2);
            String hashpwd2 = Encoding.ASCII.GetString(data2);
            if (email == "admin" && hashpwd == hashpwd2)
                return new RedirectToPageResult("/Utilizadores");
            else
                return new RedirectToPageResult("/Index");
        }
    }
}
