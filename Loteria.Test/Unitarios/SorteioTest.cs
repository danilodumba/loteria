using Loteria.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Test.Unitarios
{
    [TestFixture]
    public class SorteioTest
    {
        [Test]
        public void DeveFazerUmSorteioComAcertador()
        {
            List<int> numeros = new List<int>();
            for (int i = 1; i <= 60; i++)
            {
                numeros.Add(i);
            }

            int[] numero3 = { 1, 2, 3, 4, 5, 6 };
            List<Aposta> listaAposta = new List<Aposta>();
            listaAposta.Add(new Aposta(1, DateTime.Now, new MegaSena(), "Danilo Dumbá", numeros));
            listaAposta.Add(new Aposta(2, DateTime.Now, new MegaSena(), "Danilo Souza", numeros));
            listaAposta.Add(new Aposta(3, DateTime.Now, new MegaSena(), "Danilo Souza", numero3.ToList()));
            var sorteio = new Sorteio(listaAposta, new MegaSena());

            sorteio.Sortear();

            Assert.IsTrue(sorteio.GetGanhadoresReais().Count == 2);
        }
    }
}
