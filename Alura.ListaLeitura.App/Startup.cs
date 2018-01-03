using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

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
            //requisição está encapsulada no objeto context.Request
            var _repo = new LivroRepositorioCSV();
            //resposta está encapsulada no objeto context.Response
            return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }
    }
}
