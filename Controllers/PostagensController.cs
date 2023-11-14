using Advocacia.Models.Business;
using Advocacia.Models.Helper;
using Advocacia.Models.ViewModel;
using BWProtocoloWebBusiness.Helper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Advocacia.Controllers
{
    public class PostagensController : Controller
    {
        public ActionResult Postagens(int? page,int idFinalidade, string nomeFinalidade)
        {
            if (!Request.IsAuthenticated) { return RedirectToAction("Login", "Login"); }

            try
            {
                ViewBag.UsuarioAdm = Utils.UsuarioLogado.adm;
            }
            catch
            {
                return RedirectToAction("Login", "Login");
            }
            int tamanhoPagina = 12;
            int numeroPagina = page ?? 1;            

            ViewBag.nomeCategoria = new CategoriasFinalidadesBusiness().GetCategoriaById(idFinalidade).descricao;
            ViewBag.nomeFinalidade = nomeFinalidade;
            ViewBag.idFinalidade = idFinalidade;

            var postagens = new PostarBusiness().GetPostagens(idFinalidade);

            return View(postagens.ToPagedList(numeroPagina, tamanhoPagina));
        }

        public ActionResult Categorias(int? page)
        {
            if (!Request.IsAuthenticated) { return RedirectToAction("Login", "Login"); }

            try
            {
                ViewBag.UsuarioAdm = Utils.UsuarioLogado.adm;
            }
            catch
            {
                return RedirectToAction("Login", "Login");
            }
            int tamanhoPagina = 130;
            int numeroPagina = page ?? 1;

            var categorias = new CategoriasFinalidadesBusiness().GetCategorias();

            return View(categorias.ToPagedList(numeroPagina,tamanhoPagina));
        }
        
        public ActionResult Finalidades(int? page,int idCategoria,string nomeCategoria)
        {
            if (!Request.IsAuthenticated) { return RedirectToAction("Login", "Login"); }

            try
            {
                ViewBag.UsuarioAdm = Utils.UsuarioLogado.adm;
            }
            catch
            {
                return RedirectToAction("Login", "Login");
            }

            int tamanhoPagina = 130;
            int numeroPagina = page ?? 1;

            ViewBag.nomeCategoria = nomeCategoria;

            var finalidades = new CategoriasFinalidadesBusiness().GetFinalidades(idCategoria);

            return View(finalidades.ToPagedList(numeroPagina,tamanhoPagina));
        }

        public JsonResult VisualizarPostagem(int idPostagem)
        {
            var postagem = new PostarBusiness().GetPostagensById(idPostagem);
            var autor = new AutoresBusiness().GetAutorById(postagem.id_autor);
            
            var postagemVM = new VMPostagem();

            postagemVM.titulo = postagem.titulo;
            postagemVM.conteudo = postagem.conteudo;
            postagemVM.dtPublicacao = postagem.dtPublicacao.ToString("dd/MM/yyyy");
            postagemVM.nome_imagem_gerada = postagem.nome_imagem_gerada;
            postagemVM.minutos_leitura = postagem.minutos_leitura;
            postagemVM.conteudo_sem_formatacao = postagem.conteudo_sem_formatacao;
            postagemVM.nome_autor = autor.nome;

            return Json(postagemVM, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePostagem(int idPostagem,string nomeImagemGerada)
        {
            ExtensionMethods.DeletarImagemPost(nomeImagemGerada);

            var result = new PostarBusiness().DeletarPostagem(idPostagem);

            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}