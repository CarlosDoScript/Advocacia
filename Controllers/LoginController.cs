using Advocacia.Models;
using Advocacia.Models.Helper;
using Advocacia.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Advocacia.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection formCollection)
        {
            try
            {
                string nomeLogin = formCollection["Usuario"];
                string senha = formCollection["Senha"];

                Utils.UsuarioLogado = new AdvocaciaBusiness().GetUsuarioSenha(nomeLogin, senha);

                if (!string.IsNullOrEmpty(Utils.UsuarioLogado.NomeLogin))
                {
                    FormsAuthentication.SetAuthCookie(Utils.UsuarioLogado.Id.ToString(), true);
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    return RedirectToAction("Login","Login");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("index");
            }
        }
    }
}