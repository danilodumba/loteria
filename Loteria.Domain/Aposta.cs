using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Domain
{
    public class Aposta
    {        
        public int Id { get; set; }
        public Jogo Jogo { get; private set; }
        public string Nome { get; private set; }
        public List<int> Numeros { get; private set; }
        public DateTime Data { get; private set; }

        public Aposta(int id, DateTime data, Jogo jogo, string nome, List<int> numeros)
        {
            this.Jogo = jogo ?? throw new ArgumentNullException("jogo", "Informe qual o jogo que pretende fazer");

            this.Nome = nome;
            this.Data = data;
            this.SetNumeros(numeros);
            this.Id = id;
        }

        private void SetNumeros(List<int> numeros)
        {
            if (numeros == null || numeros.Count == 0)
                throw new Exception("Informe os números de sua aposta.");

            if (numeros.Count < this.Jogo.ApostaMinima)
                throw new Exception("Quantidade de números inferior ao mínimo exigido");


            this.ValidaNumeros(numeros);
            this.Numeros = numeros;
        }

        

        private void ValidaNumeros(List<int> numeros)
        {
            for (int i = 0; i < numeros.Count; i++)
            {
                //Ja faz a validação se o número é ou não permitido para a aposta.
                if (numeros[i] > this.Jogo.MaiorNumeroAposta || numeros[i] < this.Jogo.MenorNumeroAposta)
                    throw new Exception(string.Format("Informe um número entre {0} e {1}.", this.Jogo.MenorNumeroAposta, this.Jogo.MaiorNumeroAposta));
                                
                for (int j = 0; j < numeros.Count; j++)
                {
                    if (numeros[i] == numeros[j] && i != j)
                    {
                        throw new Exception("Não informe números repetidos.");
                    }
                }
            }
        }
    }
}
