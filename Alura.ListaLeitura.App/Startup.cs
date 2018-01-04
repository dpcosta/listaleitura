using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            //RequestDelegate metodo = null;
            //delegate é um ponteiro fortemente tipado para um método com uma assinatura específica
            //RequestDelegate function = AtendeRequisicao; //evento: requisição chegou!
            app.Run(AtendeRequisicao);
        }

        public Task AtendeRequisicao(HttpContext context)
        {
            var caminhosAtendidos = new Dictionary<string, RequestDelegate> 
            {
                { "/livros/para-ler", ListaLivrosParaLer },
                { "/livros/lendo", ListaLivrosLendo },
                { "/livros/lidos", ListaLivrosLidos },
            };

            //requisição está encapsulada no objeto context.Request
            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                return caminhosAtendidos[context.Request.Path].Invoke(context);
            }

            context.Response.StatusCode = 404;
            return context.Response.WriteAsync($"O servidor não atende o caminho {context.Request.Path}");
        }

        public Task ListaLivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }

        public Task ListaLivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public Task ListaLivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }
    }
}
