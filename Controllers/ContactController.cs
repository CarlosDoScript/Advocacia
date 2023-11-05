using Advocacia.Models;
using Advocacia.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Advocacia.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Contact(bool? resultado = null)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(FormCollection formCollection)
        {
            try
            {
                Pessoas pessoas = new Pessoas();
                {
                    pessoas.Nome = formCollection["Nome"];
                    pessoas.Email = formCollection["Email"];
                    pessoas.Celular = formCollection["Celular"];
                    pessoas.Titulo = formCollection["Titulo"];
                    pessoas.Mensagem = formCollection["Mensagem"];
                };

                if (pessoas.Nome == "" || pessoas.Email == "" || pessoas.Celular == "")
                {
                    return RedirectToAction("Contact", "Contact");
                }
                else
                {
                    bool resultado = new AdvocaciaBusiness().SalvarInfoGeral(pessoas);
                    return RedirectToAction("Contact", new { resultado = resultado });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Contact");
            }
        }
    }
}