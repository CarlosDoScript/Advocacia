using Advocacia.Models;
using Advocacia.Models.Mapping;
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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(bool? resultado = null)
        {
            return View();
        }

        public ActionResult PracticeArea()
        {
            return View();
        }
        [Authorize]
        public ActionResult AreaRestrita()
        {
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
                    pessoas.Nome = formCollection["Nome"];
                    pessoas.Email = formCollection["Email"];
                    pessoas.Celular = formCollection["Celular"];
                    pessoas.Titulo = formCollection["Titulo"];
                    pessoas.Mensagem = formCollection["Mensagem"];
                };

                if (pessoas.Nome == "" || pessoas.Email == "" || pessoas.Celular == "" || pessoas.Titulo == "" || pessoas.Mensagem == "")
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

                if (pessoas.Nome == "" || pessoas.Email == "" || pessoas.Celular == "" || pessoas.Titulo == "" || pessoas.Mensagem == "")
                {
                    return RedirectToAction("Index");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AreaRestrita(FormCollection formCollection)
        {
            try
            {
                Login login = new Login();
                {
                    login.Usuario = formCollection["Usuario"];
                    login.Senha = formCollection["Senha"];
                    
                };

                string usuario = login.Usuario;
                string senha = login.Senha;

                var resultado = new AdvocaciaBusiness().GetUsuarioSenha(usuario,senha);

                if(resultado.Count == 1)
                {
                    FormsAuthentication.SetAuthCookie(senha,true);
                    return RedirectToAction("AreaRestrita");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("index");
            }
        }
        public JsonResult getPessoas()
        {
            List<Pessoas> pessoas = new AdvocaciaBusiness().getPessoas();
            return Json(pessoas,JsonRequestBehavior.AllowGet);
        }

        public JsonResult deletePessoa(int idPessoa)
        {
            var result = new AdvocaciaBusiness().deletePessoa(idPessoa);
            var b = result;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}