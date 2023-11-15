using Advocacia.Models;
using Advocacia.Models.Mapping;
using BWProtocoloWebBusiness.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Advocacia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.InformacoesPagina = new AdvocaciaBusiness().GetInformacoesPagina();
            return View();
        }     
        public ActionResult Login(bool? resultado = null)
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection formCollection)
        {
            try
            {
                Pessoas pessoas = new Pessoas();
                {
                    pessoas.Nome = ExtensionMethods.PrimeiraLetraPalavrasMaisculas(formCollection["Nome"]);
                    pessoas.Email = formCollection["Email"];
                    pessoas.Celular = formCollection["Celular"];
                    pessoas.Titulo = formCollection["Titulo"];
                    pessoas.Mensagem = formCollection["Mensagem"];
                };

                if (pessoas.Nome == "" || pessoas.Email == "" || pessoas.Celular == "")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    bool resultado = new AdvocaciaBusiness().SalvarInfoGeral(pessoas);
                    return RedirectToAction("Index", new { resultado = resultado });

                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}