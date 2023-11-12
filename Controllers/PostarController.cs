using Advocacia.Models.Business;
using Advocacia.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Advocacia.Controllers
{
    public class PostarController : Controller
    {        
        public ActionResult Postar()
        {
            if (!Request.IsAuthenticated) { return RedirectToAction("Login", "Login"); }

            return View();
        }

        public JsonResult GetCategorias()
        {
            var categorias = new CategoriasFinalidadesBusiness().GetCategorias();

            return Json(categorias,JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetFinalidades(int idCategoria)
        {
            var finalidades = new CategoriasFinalidadesBusiness().GetFinalidades(idCategoria);

            return Json(finalidades, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetAutores()
        {
            var autores = new AutoresBusiness().GetAutores();

            return Json(autores, JsonRequestBehavior.AllowGet);
        }
    }
}