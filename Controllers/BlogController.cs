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

            List<VMPostagemBlog> listPostagens = new List<VMPostagemBlog>();

            foreach (var postagem in postagens)
            {
                var autor = new AutoresBusiness().GetAutorById(postagem.id_autor);
                var categoria = new CategoriasFinalidadesBusiness().GetCategoriaById(idFinalidade);

                VMPostagemBlog postagemObj = new VMPostagemBlog();

                postagemObj.id = postagem.id;
                postagemObj.titulo = postagem.titulo;
                postagemObj.conteudo = postagem.conteudo;
                postagemObj.dtPublicacao = postagem.dtPublicacao.ToString("dd/MM/yyyy");
                postagemObj.nome_imagem_gerada = postagem.nome_imagem_gerada;
                postagemObj.minutos_leitura = postagem.minutos_leitura;
                postagemObj.conteudo_sem_formatacao = postagem.conteudo_sem_formatacao;
                postagemObj.nome_autor = autor.nome;
                postagemObj.nome_categoria = categoria.descricao;
                postagemObj.nome_finalidade = nomeFinalidade;

                listPostagens.Add(postagemObj);
            }

            return View(listPostagens.ToPagedList(numeroPagina, tamanhoPagina));
        }

        public ActionResult Postagem(int idPostagem,string nomeCategoria, string nomeFinalidade)
        {
            var postagem = new PostarBusiness().GetPostagensById(idPostagem);
            var autor = new AutoresBusiness().GetAutorById(postagem.id_autor);

            var postagemVM = new VMPostagemBlog();

            postagemVM.titulo = postagem.titulo;
            postagemVM.conteudo = postagem.conteudo;
            postagemVM.dtPublicacao = postagem.dtPublicacao.ToString("dd/MM/yyyy");
            postagemVM.nome_imagem_gerada = postagem.nome_imagem_gerada;
            postagemVM.minutos_leitura = postagem.minutos_leitura;
            postagemVM.conteudo_sem_formatacao = postagem.conteudo_sem_formatacao;
            postagemVM.nome_autor = autor.nome;
            postagemVM.nome_categoria = nomeCategoria;
            postagemVM.nome_finalidade = nomeFinalidade;

            return View(postagemVM);
        }

    }
}