using BLL;
using Interface.BLL;
using Interface.Repositorio;
using Repositorio;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace InjecaoDependecia
{
    public static class InjecaoDependencia
    {
        private readonly static Container container = new Container();

        public static SimpleInjectorDependencyResolver Injetar()
        {
            //var container = new Container();
           
            container.Register<IGeneroBLL, GeneroBLL>();
            container.Register<ILivroBLL, LivroBLL>();
            container.Register<IRepositorioGenero, RepositorioGenero>();
            container.Register<IRepositorioLivro, RepositorioLivro>();

            return new SimpleInjectorDependencyResolver(container);
        }

        public static T Get<T>()
        {
            return (T) container.GetInstance(typeof(T));
        }
    }
}
