using DTO;
using Interface.Repositorio;
using Repositorio.Base;

namespace Repositorio
{
    public class RepositorioLivro : Repositorio<Livro>, IRepositorioLivro
    {
    }
}
