using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.ViewModel
{
    class Palavra
    {
        public string Nome { get; set; }
        public string Texto { get; set; }
    }
    class PerfilViewModel
    {

        public PerfilViewModel()
        {
            Frases = new List<Palavra>
            {
                new Palavra{ Nome = "https://cdn-cv.r4you.co/wp-content/uploads/2018/10/iStock-536613027.jpg", Texto = "OLA123" },
                new Palavra{ Nome = "https://cdn-cv.r4you.co/wp-content/uploads/2018/10/iStock-536613027.jpg", Texto = "OLAOLA"},
                new Palavra{ Nome = "https://st.depositphotos.com/1752371/1250/i/450/depositphotos_12507644-stock-photo-a-sword-with-a-red.jpg", Texto = "olaollll"}
            };
        }

        public List<Palavra> Frases { get; set; }
    }
}
