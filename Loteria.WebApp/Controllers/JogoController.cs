using Loteria.Domain;
using Loteria.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Loteria.WebApp.Controllers
{
    
    public class JogoController : ApiController
    {       
        public List<int> GetSurpresinha(int qtdeNumeros)
        {
            var megaSena = new MegaSena();
            return megaSena.Surpresinha(qtdeNumeros).OrderBy(a => a).ToList();
        }

        [HttpPost]
        public ApiResult Sortear(List<JogoModel> apostasModel)
        {
            var apostasList = new List<Aposta>();
            int contador = 0;
            try
            {
                foreach (var item in apostasModel)
                {
                    apostasList.Add(new Aposta(contador++, item.Data, new MegaSena(), item.Nome, item.Numeros));
                }

                var sorteio = new Sorteio(apostasList, new MegaSena());

                sorteio.Sortear();

                var ganhadores = sorteio.GetGanhadoresReais();

                var resultado = new ResultadoMegaSenaModel();
                resultado.Concurso = sorteio.Id;
                resultado.Numeros = sorteio.NumerosSorteados.OrderBy(a => a).ToList();
                resultado.GanhadoresSena = ganhadores.Where(x => x.QuantidadeAcertos == 6).Select(d => new JogoModel()
                {
                    Nome = d.Aposta.Nome,
                    Numeros = d.Aposta.Numeros.OrderBy(a => a).ToList()
                }).ToList();

                resultado.GanhadoresQuina = ganhadores.Where(x => x.QuantidadeAcertos == 5).Select(d => new JogoModel()
                {
                    Nome = d.Aposta.Nome,
                    Numeros = d.Aposta.Numeros.OrderBy(a => a).ToList()
                }).ToList();

                resultado.GanhadoresQuadra = ganhadores.Where(x => x.QuantidadeAcertos == 4).Select(d => new JogoModel()
                {
                    Nome = d.Aposta.Nome,
                    Numeros = d.Aposta.Numeros.OrderBy(a => a).ToList()
                }).ToList();


                return new ApiResult(resultado);
            }
            catch (Exception ex)
            {
                return new ApiResult(ex.Message, false);
            }
        }

    }
}
