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
    public class MegaSenaTest
    {        
        public MegaSenaTest()
        {
           
        }   
        
        [Test]
        public void DeveFazerUmaSurpresinha()
        {
            var megaSena = new MegaSena();

            var numeros = megaSena.Surpresinha(6);
            Assert.IsTrue(numeros.Count == 6);

            //Numeros não podem ser repetidos.
            for (int i = 0; i < numeros.Count; i++)
            {
                for (int j = 0; j < numeros.Count; j++)
                {
                    if (numeros[i] == numeros[j] && i != j)
                    {
                        throw new Exception("Sorteio sendo gerado com numeros repetidos.");
                    }
                }
            }
        }


        [Test]
        public void DeveInstanciarMegaSenaCorreta()
        {
            var megaSena = new MegaSena();

            Assert.IsTrue(megaSena.MaiorNumeroAposta == 60);
            Assert.IsTrue(megaSena.MenorNumeroAposta == 1);
            Assert.IsTrue(megaSena.ApostaMinima == 6);
            Assert.IsTrue(megaSena.QtdeAcertosIniciaGanhos == 4);
        }

        [Test]
        public void DeveSortearNumerosCorretos()
        {

            var megaSena = new MegaSena();
            var numeros = megaSena.Sortear();

            Assert.IsTrue(numeros.Count == 6);

            //Numeros não podem ser repetidos.
            for (int i = 0; i < numeros.Count; i++)
            {   
                for (int j = 0; j < numeros.Count; j++)
                {
                    if (numeros[i] == numeros[j] && i != j)
                    {
                        throw new Exception("Sorteio sendo gerado com numeros repetidos.");
                    }
                }
            }
        }
    }
}
