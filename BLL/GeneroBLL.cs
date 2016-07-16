using BLL.Base;
using DTO;
using Interface.BLL;
using Interface.Repositorio;

namespace BLL
{
    public class GeneroBLL : BLL<Genero>, IGeneroBLL
    {
        public GeneroBLL(IRepositorioGenero repositorio) : base(repositorio)
        {

        }
    }
}
