using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.WebApp.Models
{
    public class JogoModel
    {
        public string NomeJogo { get; set; }
        public string Nome { get; set; }
        public List<int> Numeros { get; set; }
        public DateTime Data { get; set; }

        public JogoModel()
        {
            this.Numeros = new List<int>();
        }
    }    
}