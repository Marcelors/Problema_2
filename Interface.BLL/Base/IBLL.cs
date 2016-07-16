using System;
using System.Collections.Generic;

namespace Interface.BLL.Base
{
    public interface IBLL<TModel>
    {
        List<TModel> ConsultarTodos();
        List<TModel> ConsultarTodos(int limite);
        List<TModel> ConsultarTodos(Func<TModel, bool> filtro);
        List<TModel> ConsultarTodos(Func<TModel, object> ordem);
        List<TModel> ConsultarTodos(int offset, int limite);
        List<TModel> ConsultarTodos(Func<TModel, bool> filtro, int limite);
        List<TModel> ConsultarTodos(Func<TModel, bool> filtro, Func<TModel, object> ordem);
        List<TModel> ConsultarTodos(Func<TModel, object> ordem, int limite);
        List<TModel> ConsultarTodos(Func<TModel, bool> filtro, int offset, int limite);
        List<TModel> ConsultarTodos(Func<TModel, object> ordem, int offset, int limite);
        List<TModel> ConsultarTodos(Func<TModel, bool> filtro, Func<TModel, object> ordem, int offset, int limite);
        TModel ConsultarPorId(params object[] key);
        void Atualizar(TModel obj);
        void Atualizar(List<TModel> list);
        void Salvar(TModel obj);
        void Salvar(List<TModel> list);
        void Deletar(Func<TModel, bool> filtro);
        void Deletar(List<TModel> list);
        void Deletar(TModel obj);
        int QuantidadeItens();
        int QuantidadeItens(Func<TModel, bool> filtro);
    }
}
