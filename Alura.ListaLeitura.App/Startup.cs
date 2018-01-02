using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            RequestDelegate function = AtendeRequisicao; //evento: requisição chegou!
            app.Run(function);
        }

        public async Task AtendeRequisicao(HttpContext context)
        {
            //requisição está encapsulada no objeto context.Request
            var _repo = new LivroRepositorioCSV();
            //resposta está encapsulada no objeto context.Response
            await context.Response.WriteAsync(_repo.ParaLer.ToString());
        }
    }
}
