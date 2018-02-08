using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.WebApp.Models
{
    public class ApiResult
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }

        public ApiResult(object dados)
        {
            this.Sucesso = true;
            this.Dados = dados;
        }

        public ApiResult(string mensagem, bool sucesso = true)
        {
            this.Mensagem = mensagem;
            this.Sucesso = sucesso;
        }
    }
}