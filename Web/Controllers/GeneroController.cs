using DTO;
using Interface.BLL;
using MvcPaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Web.Models;

namespace Web.Controllers
{
    public class GeneroController : Controller
    {
        private IGeneroBLL GeneroBLL { get; }

        public GeneroController(IGeneroBLL generoBLL)
        {
            GeneroBLL = generoBLL;
        }
        // GET: Genero
        public ActionResult Index(int? page, string term)
        {
            try
            {
                var quantidadeTotalItens = string.IsNullOrEmpty(term) ? GeneroBLL.QuantidadeItens() :
                                           GeneroBLL.QuantidadeItens(m => m.NomeGenero.ToLower().Trim().Contains(term.ToLower().Trim()));
                int paginaAtual = page.HasValue ? page.Value - 1 : 0;
                int quantidadeItensPagina = 10;

                ViewBag.term = term;

                List<ViewGenero> list = string.IsNullOrEmpty(term) ? GeneroBLL.ConsultarTodos(m => m.NomeGenero, paginaAtual * quantidadeTotalItens, quantidadeItensPagina).Select(m => ModelToView(m)).ToList() :
                                        GeneroBLL.ConsultarTodos(m => m.NomeGenero.ToLower().Trim().Contains(term.ToLower().Trim()),m => m.NomeGenero, paginaAtual * quantidadeTotalItens, quantidadeItensPagina).Select(m => ModelToView(m)).ToList();

                return View("Index", list.ToPagedList(paginaAtual, quantidadeItensPagina, quantidadeTotalItens));
            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return View("Index", new List<ViewGenero>().ToPagedList(1, 1, 1));
            }
        }

        public ActionResult Novo()
        {
            try
            {
                return View("Novo", new ViewGenero());
            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return View("Novo", new ViewGenero());
            }
        }

        public ActionResult Salvar(ViewGenero view)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    StringBuilder erro = new StringBuilder();

                    ModelState.Values.SelectMany(m => m.Errors).Select(m => erro.AppendLine(m.ErrorMessage));

                    TempData.Add("Erro", erro.ToString());
                    return View("Editar", view);
                }

                var temp = ViewToModel(view);
                GeneroBLL.Salvar(temp);

                TempData.Add("Sucesso", "Dados gravados com sucesso.");
                return RedirectToAction("Visualizar", "Genero", new RouteValueDictionary(new { id = temp.IdGenero }));

            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return View("Novo", view);
            }
        }

        public ActionResult Visualizar(int id)
        {
            try
            {
                return View("Visualizar", ModelToView(GeneroBLL.ConsultarPorId(id)));
            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return View("Visualizar", new ViewGenero());
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                return View("Editar", ModelToView(GeneroBLL.ConsultarPorId(id)));
            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return View("Editar", new ViewGenero());
            }
        }

        public ActionResult Deletar(int id)
        {
            try
            {
                ILivroBLL livroBll = InjecaoDependecia.InjecaoDependencia.Get<ILivroBLL>();
                if (livroBll.ConsultarTodos(m => m.IdGenero == id).Any())
                {
                    TempData.Add("Erro", "Não é possivel deletar um genero que está associado a um livro");
                    return RedirectToAction("Index", "Genero");
                }

                GeneroBLL.Deletar(m => m.IdGenero == id);
                TempData.Add("Sucesso", "Dados deletados com sucesso.");
                return RedirectToAction("Index", "Genero");
            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return RedirectToAction("Index", "Genero");
            }
        }

        public ActionResult Atualizar(ViewGenero view)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    StringBuilder erro = new StringBuilder();

                    ModelState.Values.SelectMany(m => m.Errors).Select(m => erro.AppendLine(m.ErrorMessage));

                    TempData.Add("Erro", erro.ToString());
                    return View("Editar", view);
                }

                GeneroBLL.Atualizar(ViewToModel(view));

                TempData.Add("Sucesso", "Dados gravados com sucesso.");
                return RedirectToAction("Visualizar", "Genero", new RouteValueDictionary(new { id = view.IdGenero }));
            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return View("Editar", view);
            }
        }

        public static List<Genero> Generos
        {
            get
            {
                IGeneroBLL generoBLL = InjecaoDependecia.InjecaoDependencia.Get<IGeneroBLL>();
                return generoBLL.ConsultarTodos();
            }
        }

 

        public static Genero ViewToModel(ViewGenero view)
        {
            return new Genero
            {
                IdGenero = view.IdGenero,
                NomeGenero = view.NomeGenero
            };
        }

        public static ViewGenero ModelToView(Genero genero)
        {
            return new ViewGenero
            {
                IdGenero = genero.IdGenero,
                NomeGenero = genero.NomeGenero
            };
        }
    }
}