using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Domain
{
    public class Ganhadores
    {
        public int QuantidadeAcertos { get; set; }
        public Aposta Aposta { get; set; }

        public Ganhadores(Aposta aposta)
        {
            this.Aposta = aposta ?? throw new ArgumentNullException("aposta", "Informe uma aposta ganhadora");
            this.QuantidadeAcertos = 1;
        }

        public void IncramentaAcertos()
        {
            this.QuantidadeAcertos += 1;
        }
    }
}
