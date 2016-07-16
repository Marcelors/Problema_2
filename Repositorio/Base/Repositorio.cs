using Interface.Repositorio.Base;
using Repositorio.Conexao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repositorio.Base
{
    public abstract class Repositorio<TModel> : IDisposable, IRepositorio<TModel> where TModel : class
    {
        Context ctx = new Context();
        public void Atualizar(List<TModel> list)
        {
            try
            {
                list.ForEach(m => ctx.Entry(m).State = EntityState.Modified);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar dados: " + ex.Message);
            }
        }

        public void Atualizar(TModel obj)
        {
            try
            {
                ctx.Entry(obj).State = EntityState.Modified;
                ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar dados: " + ex.Message);
            }
        }

        public TModel ConsultarPorId(params object[] key)
        {
            try
            {
                return ctx.Set<TModel>().Find(key);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar por Id: " + ex.Message);
            }
        }

        public List<TModel> ConsultarTodos()
        {
            try
            {                
                return ctx.Set<TModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar todos: " + ex.Message);
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, object> ordem)
        {
            try
            {
                return ctx.Set<TModel>().OrderBy(ordem).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar todos: " + ex.Message);
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, bool> filtro)
        {
            try
            {
                return ctx.Set<TModel>().Where(filtro).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar todos: " + ex.Message);
            }
        }

        public List<TModel> ConsultarTodos(int limite)
        {
            try
            {
                return ctx.Set<TModel>().Take(limite).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar todos: " + ex.Message);
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, bool> filtro, int limite)
        {
            try
            {
                return ctx.Set<TModel>().Where(filtro).Take(limite).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar todos: " + ex.Message);
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, object> ordem, int limite)
        {
            try
            {
                return ctx.Set<TModel>().OrderBy(ordem).Take(limite).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar todos: " + ex.Message);
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, bool> filtro, Func<TModel, object> ordem)
        {
            try
            {
                return ctx.Set<TModel>().Where(filtro).OrderBy(ordem).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar todos: " + ex.Message);
            }
        }

        public List<TModel> ConsultarTodos(int offset, int limite)
        {
            try
            {
                return ctx.Set<TModel>().ToList().Skip(offset).Take(limite).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar todos: " + ex.Message);
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, object> ordem, int offset, int limite)
        {
            try
            {
                return ctx.Set<TModel>().OrderBy(ordem).Skip(offset).Take(limite).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar todos: " + ex.Message);
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, bool> filtro, int offset, int limite)
        {
            try
            {
                return ctx.Set<TModel>().Where(filtro).Skip(offset).Take(limite).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar todos: " + ex.Message);
            }
        }

        public List<TModel> ConsultarTodos(Func<TModel, bool> filtro, Func<TModel, object> ordem, int offset, int limite)
        {
            try
            {
                return ctx.Set<TModel>().Where(filtro).OrderBy(ordem).Skip(offset).Take(limite).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar todos: " + ex.Message);
            }
        }

        public void Deletar(TModel obj)
        {
            try
            {
                ctx.Set<TModel>().Remove(obj);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar dados: " + ex.Message);
            }
        }

        public void Deletar(List<TModel> list)
        {
            try
            {
                list.ForEach(m => ctx.Set<TModel>().Remove(m));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar dados: " + ex.Message);
            }
        }

        public void Deletar(Func<TModel, bool> filtro)
        {
            try
            {
                ctx.Set<TModel>().Where(filtro).ToList().ForEach(m => ctx.Set<TModel>().Remove(m));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar dados: " + ex.Message);
            }
        }

        public void Dispose()
        {
            try
            {
                ctx.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar dispose: " + ex.Message);
            }
        }

        public int QuantidadeItens()
        {
            try
            {
                return ctx.Set<TModel>().Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar quantidade de itens: " + ex.Message);
            }
        }

        public int QuantidadeItens(Func<TModel, bool> filtro)
        {
            try
            {
                return ctx.Set<TModel>().Where(filtro).Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar quantidade de itens: " + ex.Message);
            }
        }

        public void Salvar(List<TModel> list)
        {
            try
            {
                list.ForEach(m => ctx.Set<TModel>().Add(m));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar dados: " + ex.Message);
            }
        }

        public void Salvar(TModel obj)
        {
            try
            {
                ctx.Set<TModel>().Add(obj);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar dados: " + ex.Message);
            }
        }
    }
}
