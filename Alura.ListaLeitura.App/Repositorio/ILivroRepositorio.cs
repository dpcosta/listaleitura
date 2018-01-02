using Alura.ListaLeitura.App.Negocio;

namespace Alura.ListaLeitura.App.Repositorio
{
    interface ILivroRepositorio
    {
        ListaDeLeitura ParaLer { get; }
        ListaDeLeitura Lendo { get; }
        ListaDeLeitura Lidos { get; }
    }
}
