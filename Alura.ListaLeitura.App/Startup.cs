using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Alura.ListaLeitura.App.Negocio;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapRoute("livros/para-ler", ListaLivrosParaLer);
            routeBuilder.MapRoute("livros/lendo", ListaLivrosLendo);
            routeBuilder.MapRoute("livros/lidos", ListaLivrosLidos);
            routeBuilder.MapRoute("novo-livro/{nome}/{autor}", IncluiLivroParaLer);
            routeBuilder.MapRoute("livros", ExibeDetalhesLivro);

            var rotas = routeBuilder.Build();
            app.UseRouter(rotas);

        }

        private Task ExibeDetalhesLivro(HttpContext context)
        {
            var queryValue = context.Request.Query["id"];
            var id = Convert.ToInt32(queryValue.First());
            var _repo = new LivroRepositorioCSV();
            var livro = _repo.Todos.First(l => l.Id == id);
            return context.Response.WriteAsync(livro.Detalhes());
        }

        private Task IncluiLivroParaLer(HttpContext context)
        {
            var livro = new Livro
            {
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("autor").ToString(),
            };
            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return context.Response.WriteAsync("Livro adicionado com sucesso!");
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
