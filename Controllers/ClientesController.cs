using Advocacia.Models.Business;
using Advocacia.Models.Helper;
using Advocacia.Models.Mapping;
using BWProtocoloWebBusiness.Helper;
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

            var clientesFormatados = clientes.Select(cliente => new Pessoas
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Celular = ExtensionMethods.FormatarTelefone(cliente.Celular),
                Titulo = cliente.Titulo,
                Mensagem = cliente.Mensagem
            });

            return Json(clientesFormatados, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCliente(int idCliente)
        {
            var clientes = new ClientesBusiness().DeleteCliente(idCliente);

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }


    }
}