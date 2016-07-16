using Interface.BLL.Base;
using Interface.Repositorio.Base;
using System;
using System.Collections.Generic;

namespace BLL.Base
{
    public abstract class BLL<TModel> : IBLL<TModel> where TModel : class
    {
        protected readonly IRepositorio<TModel> repositorio;

        protected BLL(IRepositorio<TModel> repositorio)
        {
            this.repositorio = repositorio;
        }
        public void Atualizar(List<TModel> list)
        {
            try
            {
                repositorio.Atualizar(list);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(TModel obj)
        {
            try
            {
                repositorio.Atualizar(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TModel ConsultarPorId(params object[] key)
        {
            try
            {
                return repositorio.ConsultarPorId(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TModel> ConsultarTodos()
        {
            try
            {
                return repositorio.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, object> ordem)
        {
            try
            {
                return repositorio.ConsultarTodos(ordem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, bool> filtro)
        {
            try
            {
                return repositorio.ConsultarTodos(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TModel> ConsultarTodos(int limite)
        {
            try
            {
                return repositorio.ConsultarTodos(limite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, object> ordem, int limite)
        {
            try
            {
                return repositorio.ConsultarTodos(ordem,limite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, bool> filtro, Func<TModel, object> ordem)
        {
            try
            {
                return repositorio.ConsultarTodos(filtro, ordem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, bool> filtro, int limite)
        {
            try
            {
                return repositorio.ConsultarTodos(filtro, limite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TModel> ConsultarTodos(int offset, int limite)
        {
            try
            {
                return repositorio.ConsultarTodos(offset, limite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, object> ordem, int offset, int limite)
        {
            try
            {
                return repositorio.ConsultarTodos(ordem,offset, limite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, bool> filtro, int offset, int limite)
        {
            try
            {
                return repositorio.ConsultarTodos(filtro,offset,limite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, bool> filtro, Func<TModel, object> ordem, int offset, int limite)
        {
            try
            {
                return repositorio.ConsultarTodos(filtro,ordem, offset, limite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Deletar(TModel obj)
        {
            try
            {
                repositorio.Deletar(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Deletar(List<TModel> list)
        {
            try
            {
                repositorio.Deletar(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Deletar(Func<TModel, bool> filtro)
        {
            try
            {
                repositorio.Deletar(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int QuantidadeItens()
        {
            try
            {
               return repositorio.QuantidadeItens();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int QuantidadeItens(Func<TModel, bool> filtro)
        {
            try
            {
               return repositorio.QuantidadeItens(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Salvar(List<TModel> list)
        {
            try
            {
                repositorio.Salvar(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Salvar(TModel obj)
        {
            try
            {
                repositorio.Salvar(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
