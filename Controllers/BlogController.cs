using Advocacia.Models.Business;
using Advocacia.Models.Helper;
using Advocacia.Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Advocacia.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Blog(int? page)
        {
            int tamanhoPagina = 21;
            int numeroPagina = page ?? 1;

            var categorias = new CategoriasFinalidadesBusiness().GetCategorias();

            return View(categorias.ToPagedList(numeroPagina, tamanhoPagina));
        }

        public ActionResult Finalidades(int? page, int idCategoria, string nomeCategoria)
        {
            if (string.IsNullOrEmpty(idCategoria.ToString()) || string.IsNullOrEmpty(nomeCategoria.ToString())) { return RedirectToAction("Blog","Blog"); }

            int tamanhoPagina = 21;
            int numeroPagina = page ?? 1;

            ViewBag.idCategoria = idCategoria;
            ViewBag.nomeCategoria = nomeCategoria;

            var finalidades = new CategoriasFinalidadesBusiness().GetFinalidades(idCategoria);

            return View(finalidades.ToPagedList(numeroPagina, tamanhoPagina));
        }

        public ActionResult Postagens(int? page, int idFinalidade, string nomeFinalidade)
        {
            if (string.IsNullOrEmpty(idFinalidade.ToString()) || string.IsNullOrEmpty(nomeFinalidade.ToString())) { return RedirectToAction("Blog", "Blog"); }

            int tamanhoPagina = 12;
            int numeroPagina = page ?? 1;

            ViewBag.nomeCategoria = new CategoriasFinalidadesBusiness().GetCategoriaById(idFinalidade).descricao;
            ViewBag.nomeFinalidade = nomeFinalidade;
            ViewBag.idFinalidade = idFinalidade;

            var postagens = new PostarBusiness().GetPostagens(idFinalidade);

            List<VMPostagem> listPostagens = new List<VMPostagem>();

            foreach (var postagem in postagens)
            {
                var autor = new AutoresBusiness().GetAutorById(postagem.id_autor);

                VMPostagem postagemObj = new VMPostagem();
                
                postagemObj.titulo = postagem.titulo;
                postagemObj.conteudo = postagem.conteudo;
                postagemObj.dtPublicacao = postagem.dtPublicacao.ToString("dd/MM/yyyy");
                postagemObj.nome_imagem_gerada = postagem.nome_imagem_gerada;
                postagemObj.minutos_leitura = postagem.minutos_leitura;
                postagemObj.conteudo_sem_formatacao = postagem.conteudo_sem_formatacao;
                postagemObj.nome_autor = autor.nome;

                listPostagens.Add(postagemObj);
            }

            return View(listPostagens.ToPagedList(numeroPagina, tamanhoPagina));
        }

        public ActionResult Postagem(int? page)
        {
            return View();
        }

    }
}