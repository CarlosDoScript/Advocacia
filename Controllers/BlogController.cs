using Advocacia.Models.Business;
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
            int tamanhoPagina = 21;
            int numeroPagina = page ?? 1;

            ViewBag.idCategoria = idCategoria;
            ViewBag.nomeCategoria = nomeCategoria;

            var finalidades = new CategoriasFinalidadesBusiness().GetFinalidades(idCategoria);

            return View(finalidades.ToPagedList(numeroPagina, tamanhoPagina));
        }
    }
}