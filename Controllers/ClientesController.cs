using Advocacia.Models.Business;
using Advocacia.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Advocacia.Controllers
{
    public class ClientesController : Controller
    {
        public ActionResult Clientes()
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

          
        public JsonResult GetClientes()
        {
            var clientes = new ClientesBusiness().GetClientes();

            return Json(clientes,JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult DeleteCliente(int idCliente)
        {
            var clientes = new ClientesBusiness().DeleteCliente(idCliente);

            return Json(clientes,JsonRequestBehavior.AllowGet);
        }


    }
}