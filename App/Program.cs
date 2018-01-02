using App.Negocio;
using App.Repositorio;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var _repo = new LivroRepositorioFake();
            ImprimeLista(_repo.ParaLer);
            ImprimeLista(_repo.Lendo);
            ImprimeLista(_repo.Lidos);
        }

        static void ImprimeLista(ListaDeLeitura lista)
        {
            Console.WriteLine(lista.Titulo);
            Console.WriteLine("==========");
            foreach (var livro in lista.Livros)
            {
                Console.WriteLine(livro);
            }
            Console.WriteLine("");
        }
    }
}
