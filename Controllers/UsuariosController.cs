using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Advocacia.Models;
using Advocacia.Models.Helper;

namespace Advocacia.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Usuarios()
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
        
        public JsonResult GetUsuarios()
        {
            var usuarios = new AdvocaciaBusiness().GetUsuarios();

            return Json(usuarios,JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostUsuarios(string nome,string nomeLogin,string email,string senha,bool adm)
        {
            var result = new AdvocaciaBusiness().PostUsuario(nome,nomeLogin,email,senha,adm);

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditarUsuarios(string nome, string nomeLogin, string email, string senha, bool adm, int idUsuario)
        {
            var result = new AdvocaciaBusiness().EditarUsuarios(nome, nomeLogin, email, senha, adm, idUsuario);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUsuario(int idUsuario)
        {
            var result = new AdvocaciaBusiness().DeleteUsuario(idUsuario);
            
            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}