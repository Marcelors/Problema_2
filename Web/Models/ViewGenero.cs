using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ViewGenero
    {
        public int IdGenero { get; set; }
        [Required(ErrorMessage = "O campo nome genero e Obrigatório")]
        [MaxLength(100,ErrorMessage = "O campo nome genero deve ter no maximo {1} caracteres")]
        public string NomeGenero { get; set; }
    }
}
