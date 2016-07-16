using DTO;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ViewLivro
    {
        public int IdLivro { get; set; }
        [Required(ErrorMessage = "O campo genero do livro e Obrigatório")]
        public int IdGenero { get; set; }
        [Required(ErrorMessage = "O campo nome livro e Obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo nome livro deve ter no maximo {1} caracteres")]
        public string NomeLivro { get; set; }
        [MaxLength(800, ErrorMessage = "O campo descrição do livro deve ter no maximo {1} caracteres")]
        public string DescricaoLivro { get; set; }
        [Required(ErrorMessage = "O campo quantidade de Exemplares do livro e Obrigatório")]
        public int QtdExemplares { get; set; }
        public Genero Genero { get; set; }
    }
}
