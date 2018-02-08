using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Domain
{
    public class Sorteio
    {
        private readonly Jogo _jogo;
        public int Id { get; private set; }
        public List<int> NumerosSorteados { get; private set; }
        public IList<Aposta> Apostas { get; private set; }
        private IList<Ganhadores> Ganhadores { get; set; }
        public Sorteio(IList<Aposta> apostas, Jogo jogo)
        {
            this.Apostas = apostas ?? throw new ArgumentNullException("apostas", "Informe apostas para o sorteio");
            _jogo = jogo ?? throw new ArgumentNullException("jogo", "Informe um jogo para o sorteio");

            this.Ganhadores = new List<Ganhadores>();
        }

        /// <summary>
        /// Sorteia a lista as apostas ganhadoras
        /// </summary>
        /// <returns></returns>
        public void Sortear()
        {
            this.NumerosSorteados = _jogo.Sortear();


            //Cria os ganhadores.       
            foreach (var numero in this.NumerosSorteados)
            {
                var apostas = this.Apostas.Where(x => x.Numeros.Any(y => y.Equals(numero)));

                foreach (var aposta in apostas)
                {
                    if (this.Ganhadores.Any(x => x.Aposta == aposta))
                    {
                        var ganhador = this.Ganhadores.FirstOrDefault(x => x.Aposta == aposta);
                        ganhador.IncramentaAcertos();
                    }
                    else
                    {
                        this.Ganhadores.Add(new Domain.Ganhadores(aposta));
                    }
                }
            }           
        }

        public List<Ganhadores> GetGanhadoresReais()
        {
            return this.Ganhadores.Where(x => x.QuantidadeAcertos >= _jogo.QtdeAcertosIniciaGanhos).OrderByDescending(x => x.QuantidadeAcertos).ToList();
        }
    }
}
