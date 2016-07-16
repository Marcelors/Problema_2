namespace DTO
{
    public class Livro
    {
        public int IdLivro { get; set; }
        public int IdGenero { get; set; }
        public string NomeLivro { get; set; }
        public string DescricaoLivro { get; set; }
        public int QtdExemplares { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
