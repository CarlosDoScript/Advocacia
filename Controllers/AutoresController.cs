using Advocacia.Models.Business;
using Advocacia.Models.Helper;
using Advocacia.Models.Mapping;
using Advocacia.Models.ViewModel;
using BWProtocoloWebBusiness.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Advocacia.Controllers
{
    public class AutoresController : Controller
    {
        public ActionResult Autores()
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

        public JsonResult GetAutores()
        {
            var autores = new AutoresBusiness().GetAutores();

            List<AutorVM> listAutoresFormatado = new List<AutorVM>();

            foreach (var autor in autores)
            {
                AutorVM autorVM = new AutorVM();

                autorVM.Id = autor.Id;
                autorVM.nome = autor.nome;
                autorVM.email = autor.email;
                autorVM.dtRegistro = autor.dtRegistro.ToString();
                autorVM.dtNascimento = autor.dtNascimento.ToString("yyyy-MM-dd");
                autorVM.dtNascimentoFormatado = autor.dtNascimento.ToString("dd/MM/yyyy");

                listAutoresFormatado.Add(autorVM);
            }


            return Json(listAutoresFormatado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostAutor(string nomeAutor, string email, string dtNascimento)
        {
            nomeAutor = ExtensionMethods.PrimeiraLetraPalavrasMaisculas(nomeAutor);
            var result = new AutoresBusiness().PostAutor(nomeAutor, email, Convert.ToDateTime(dtNascimento));

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditarAutor(string nomeAutor, string email, string dtNascimento, int idAutor)
        {
            nomeAutor = ExtensionMethods.PrimeiraLetraPalavrasMaisculas(nomeAutor);
            var result = new AutoresBusiness().EditarAutor(nomeAutor, email, Convert.ToDateTime(dtNascimento), idAutor);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAutor(int idAutor)
        {
            var result = new AutoresBusiness().DeleteAutor(idAutor);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}