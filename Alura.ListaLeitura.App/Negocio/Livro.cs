namespace Alura.ListaLeitura.App.Negocio
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public override string ToString()
        {
            return $"{Titulo} - {Autor}";
        }
    }
}
