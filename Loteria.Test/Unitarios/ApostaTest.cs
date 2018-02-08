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
    public class ApostaTest
    {
        public ApostaTest()
        {

        }

        [Test]
        public void DeveValidarUmaApostaMegaSenaMinima()
        {
            var megaSena = new MegaSena();
            int[] numeros = { 1, 2, 5, 8 };
            Assert.Throws<Exception>(delegate
            {
                new Aposta(1, DateTime.Now, megaSena, "Danilo de Souza", numeros.ToList());
            });
        }

        [Test]
        public void DeveValidarUmaApostaMegaSenaComNumerosInvalidos()
        {
            var megaSena = new MegaSena();
            int[] numeros = { 0, 2, 5, 8, 10, 2, 23, 2, 4, 5, 8, 8 };
            Assert.Throws<Exception>(delegate
            {
                new Aposta(1, DateTime.Now, megaSena, "Danilo de Souza", numeros.ToList());
            });
        }

        [Test]
        public void DeveValidarUmaApostaMegaSenaComNumerosRepetidos()
        {
            var megaSena = new MegaSena();
            int[] numeros = { 2, 5, 8, 10, 2, 23, 2, 4, 5, 8, 8 };
            //int[] numeros = { 1, 20, 30, 40, 50, 60 };
            Assert.Throws<Exception>(delegate
            {
                new Aposta(1, DateTime.Now, megaSena, "Danilo de Souza", numeros.ToList());
            });
            //var aposta = new Aposta(megaSena, "Danilo de Souza", numeros.ToList());
        }

        [Test]
        public void DeveValidarUmaApostaMegaSenaCorreta()
        {
            var megaSena = new MegaSena();
            int[] numeros = { 1, 20, 30, 40, 50, 60 };
            var aposta = new Aposta(1, DateTime.Now, megaSena, "Danilo de Souza", numeros.ToList());

            Assert.IsTrue(aposta.Numeros.Count == 6, "Quantidade de números diferente de 6");
            Assert.IsTrue(aposta.Numeros[0] == 1, "Número na posição 0 errado");
            Assert.IsTrue(aposta.Numeros[1] == 20, "Número na posição 1 errado");
            Assert.IsTrue(aposta.Numeros[2] == 30, "Número na posição 2 errado");
            Assert.IsTrue(aposta.Numeros[3] == 40, "Número na posição 3 errado");
            Assert.IsTrue(aposta.Numeros[4] == 50, "Número na posição 4 errado");
            Assert.IsTrue(aposta.Numeros[5] == 60, "Número na posição 5 errado");
        }
    }
}
