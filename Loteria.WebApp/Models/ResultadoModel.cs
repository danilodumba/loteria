using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.WebApp.Models
{
    public class ResultadoMegaSenaModel
    {
        public int Concurso { get; set; }
        public List<int> Numeros { get; set; }
        public List<JogoModel> GanhadoresSena { get; set; }
        public List<JogoModel> GanhadoresQuina { get; set; }
        public List<JogoModel> GanhadoresQuadra { get; set; }

        public ResultadoMegaSenaModel()
        {
            Numeros = new List<int>();
            GanhadoresSena = new List<JogoModel>();
            GanhadoresQuina = new List<JogoModel>();
            GanhadoresQuadra = new List<JogoModel>();
        }
    }
}