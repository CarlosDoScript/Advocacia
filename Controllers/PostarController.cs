using Advocacia.Models.Helper;
using System;
using System.Collections.Generic;
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
    }
}