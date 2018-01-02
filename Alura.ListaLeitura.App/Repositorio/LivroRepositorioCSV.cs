using System;
using System.Collections.Generic;
using System.Text;
using Alura.ListaLeitura.App.Negocio;
using System.IO;

namespace Alura.ListaLeitura.App.Repositorio
{
    public class LivroRepositorioCSV : ILivroRepositorio
    {
        private ListaDeLeitura _paraLer;
        private ListaDeLeitura _lendo;
        private ListaDeLeitura _lidos;

        public LivroRepositorioCSV()
        {
            var arrayParaLer = new List<Livro>();
            var arrayLendo = new List<Livro>();
            var arrayLidos = new List<Livro>();

            var file = File.OpenText("Repositorio\\livros.csv");
            while (!file.EndOfStream)
            {
                var textoLivro = file.ReadLine();
                var infoLivro = textoLivro.Split(';');
                var livro = new Livro { Titulo = infoLivro[1], Autor = infoLivro[2] };
                switch (infoLivro[0])
                {
                    case "para-ler":
                        arrayParaLer.Add(livro);
                        break;
                    case "lendo":
                        arrayLendo.Add(livro);
                        break;
                    case "lidos":
                        arrayLidos.Add(livro);
                        break;
                    default:
                        break;
                }
            }

            _paraLer = new ListaDeLeitura("Para Ler", arrayParaLer.ToArray());
            _lendo = new ListaDeLeitura("Lendo", arrayLendo.ToArray());
            _lidos = new ListaDeLeitura("Lidos", arrayLidos.ToArray());
        }

        public ListaDeLeitura ParaLer => _paraLer;
        public ListaDeLeitura Lendo => _lendo;
        public ListaDeLeitura Lidos => _lidos;
    }
}
