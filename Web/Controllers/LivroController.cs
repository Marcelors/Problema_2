using DTO;
using Interface.BLL;
using MvcPaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Web.Models;

namespace Web.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro
        private ILivroBLL LivroBLL { get; }

        public LivroController(ILivroBLL livroBLL)
        {
            LivroBLL = livroBLL;
        }
        // GET: Genero
        public ActionResult Index(int? page, string term)
        {
            try
            {
                var quantidadeTotalItens = string.IsNullOrEmpty(term) ? LivroBLL.QuantidadeItens() :
                                           LivroBLL.QuantidadeItens(m => m.NomeLivro.ToLower().Trim().Contains(term.ToLower().Trim()));
                int paginaAtual = page.HasValue ? page.Value - 1 : 0;
                int quantidadeItensPagina = 10;

                List<ViewLivro> list = string.IsNullOrEmpty(term) ? LivroBLL.ConsultarTodos(m => m.NomeLivro, paginaAtual * quantidadeTotalItens, quantidadeItensPagina).Select(m => ModelToView(m)).ToList() :
                                        LivroBLL.ConsultarTodos(m => m.NomeLivro.ToLower().Trim().Contains(term.ToLower().Trim()),m => m.NomeLivro, paginaAtual * quantidadeTotalItens, quantidadeItensPagina).Select(m => ModelToView(m)).ToList();

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
                return View("Novo", new ViewLivro());
            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return View("Novo", new ViewLivro());
            }
        }

        public ActionResult Salvar(ViewLivro view)
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
                LivroBLL.Salvar(temp);

                TempData.Add("Sucesso", "Dados gravados com sucesso.");
                return RedirectToAction("Visualizar", "Livro", new RouteValueDictionary(new { id = temp.IdGenero }));

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
                return View("Visualizar", ModelToView(LivroBLL.ConsultarPorId(id)));
            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return View("Visualizar", new ViewLivro());
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                return View("Editar", ModelToView(LivroBLL.ConsultarPorId(id)));
            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return View("Editar", new ViewLivro());
            }
        }

        public ActionResult Deletar(int id)
        {
            try
            {
                LivroBLL.Deletar(m => m.IdGenero == id);
                TempData.Add("Sucesso", "Dados deletados com sucesso.");
                return RedirectToAction("Index", "Livro");
            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return RedirectToAction("Index", "Livro");
            }
        }

        public ActionResult Atualizar(ViewLivro view)
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

                LivroBLL.Atualizar(ViewToModel(view));

                TempData.Add("Sucesso", "Dados gravados com sucesso.");
                return RedirectToAction("Visualizar", "Livro", new RouteValueDictionary(new { id = view.IdGenero }));
            }
            catch (Exception ex)
            {
                TempData.Add("Erro", ex.Message);
                return View("Editar", view);
            }
        }

        public static Livro ViewToModel(ViewLivro view)
        {
            return new Livro
            {
                IdGenero = view.IdGenero,
                DescricaoLivro = view.DescricaoLivro,
                IdLivro = view.IdLivro,
                NomeLivro = view.NomeLivro,
                QtdExemplares = view.QtdExemplares
            };
        }

        public static ViewLivro ModelToView(Livro livro)
        {
            return new ViewLivro
            {
                IdGenero = livro.IdGenero,
                DescricaoLivro = livro.DescricaoLivro,
                IdLivro = livro.IdLivro,
                NomeLivro = livro.NomeLivro,
                QtdExemplares = livro.QtdExemplares,
                Genero = livro.Genero
            };
        }
    }
}