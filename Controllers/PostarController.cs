using Advocacia.Models.Business;
using Advocacia.Models.Helper;
using BWProtocoloWebBusiness.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

            return Json(categorias, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public JsonResult CriaPublicacao(string titulo, int categoria, int finalidade, int autor, string conteudo,string conteudoOriginal)
        {
            string conteudoFormatado = HttpUtility.UrlDecode(conteudo);
            HttpPostedFileBase arquivoImagem = Request.Files["arquivoImagem"];
            string nomeImagemGerado =  ExtensionMethods.SalvarImagemPost(arquivoImagem);
            int numeroPalavras = ExtensionMethods.ContarPalavras(conteudoOriginal);
            string tempoLeitura = ExtensionMethods.CalcularTempoLeituraEstimado(numeroPalavras);            
            
            var result = new PostarBusiness().CriarPost(titulo,categoria,finalidade,autor, conteudoFormatado,nomeImagemGerado,tempoLeitura);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}