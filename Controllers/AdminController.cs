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
    public class AdminController : Controller
    {
        public ActionResult Admin()
        {
            if (!Request.IsAuthenticated) { return RedirectToAction("Login", "Login"); }

            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Utils.UsuarioLogado = null;
            FormsAuthentication.SignOut();
            Session.Remove("usuarioLogado");

            return RedirectToAction("Login","Login");
        }
    }

}