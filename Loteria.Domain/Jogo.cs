using System;
using System.Collections.Generic;
using System.Linq;

namespace Loteria.Domain
{
    public abstract class Jogo
    {
        public int MenorNumeroAposta { get; private set; } //Valor máximo de numeros na cartela
        public int MaiorNumeroAposta { get; private set; } //Valor mínimo de numero na cartela
        public int ApostaMinima { get; private set; } //Quantidade mínima na aposta
        public int QtdeAcertosIniciaGanhos { get; private set; } //Quantidade minimo de acertos que ganha alguma coisa.


        public Jogo(int menorNumeroAposta, int maiorNumeroAposta, int apostaMinima, int qtdeAcertosIniciaGanhos)
        {
            this.MenorNumeroAposta = menorNumeroAposta;
            this.MaiorNumeroAposta = maiorNumeroAposta;
            this.ApostaMinima = apostaMinima;
            this.QtdeAcertosIniciaGanhos = qtdeAcertosIniciaGanhos;
        }

        public abstract void SetGanhadores(List<int> numeros);

        public virtual List<int> Sortear()
        {
            var listaSoteio = new List<int>();
            var sorteio = new Random();
            while (listaSoteio.Count < this.ApostaMinima)
            {
                int numero = sorteio.Next(this.MenorNumeroAposta, this.MaiorNumeroAposta);

                if (!listaSoteio.Any(x => x.Equals(numero)))
                {
                    listaSoteio.Add(numero);
                }
            }

            return listaSoteio;
        }

        public List<int> Surpresinha(int qtdeNumeros)
        {
            var listaSurpresa = new List<int>();
            var sorteio = new Random();
            while (listaSurpresa.Count < qtdeNumeros)
            {
                int numero = sorteio.Next(this.MenorNumeroAposta, this.MaiorNumeroAposta);

                if (!listaSurpresa.Any(x => x.Equals(numero)))
                {
                    listaSurpresa.Add(numero);
                }
            }

            return listaSurpresa;
        }

        
    }
}
