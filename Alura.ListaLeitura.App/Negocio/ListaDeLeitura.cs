using System.Collections.Generic;
using System.Linq;

namespace Alura.ListaLeitura.App.Negocio
{
    public class ListaDeLeitura
    {
        private List<Livro> _livros;

        public ListaDeLeitura(string titulo, params Livro[] livros)
        {
            Titulo = titulo;
            _livros = livros.ToList();
        }

        public string Titulo { get; set; }
        public IEnumerable<Livro> Livros
        {
            get { return _livros; }
        }
    }
}
