using Advocacia.Models.Business;
using Advocacia.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Advocacia.Controllers
{
    public class CategoriasFinalidadesController : Controller
    {
        public ActionResult CategoriasFinalidades()
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

            return View();
        }

        public JsonResult GetCategorias()
        {
            var categorias = new CategoriasFinalidadesBusiness().GetCategorias();

            return Json(categorias,JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostCategoria(string descricao)
        {
            var result = new CategoriasFinalidadesBusiness().PostCategoria(descricao);

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditarCategoria(int id, string descricao)
        {
            var result = new CategoriasFinalidadesBusiness().EditarCategoria(id,descricao);

            return Json(result,JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult DeleteCategoria(int id)
        {
            var result = new CategoriasFinalidadesBusiness().DeleteCategoria(id);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetFinalidades(int idCategoria)
        {
            var result = new CategoriasFinalidadesBusiness().GetFinalidades(idCategoria);
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult PostFinalidade(int idCategoria,string descricao)
        {
            var result = new CategoriasFinalidadesBusiness().PostFinalidades(idCategoria,descricao);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult EditarFinalidade(int id, string descricao)
        {
            var result = new CategoriasFinalidadesBusiness().EditarFinalidade(id, descricao);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult DeletarFinalidade(int id)
        {
            var result = new CategoriasFinalidadesBusiness().DeletarFinalidade(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult VerificaCategoriaPost(int idCategoria)
        {
            int existeCategoriaPostagem = new CategoriasFinalidadesBusiness().VerificaCategoriaPostagens(idCategoria);
            return Json(existeCategoriaPostagem, JsonRequestBehavior.AllowGet);            
        }

        [HttpGet]
        public JsonResult VerificaFinalidadePost(int idFinalidade)
        {
            int existeFinalidadePostagem = new CategoriasFinalidadesBusiness().VerificaFinalidadePostagens(idFinalidade);
            return Json(existeFinalidadePostagem, JsonRequestBehavior.AllowGet);
        }
    }
}