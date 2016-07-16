using BLL.Base;
using DTO;
using Interface.BLL;
using Interface.Repositorio;

namespace BLL
{
    public class LivroBLL : BLL<Livro>, ILivroBLL
    {
        public LivroBLL(IRepositorioLivro repositorio) : base(repositorio)
        {
        }
    }
}
