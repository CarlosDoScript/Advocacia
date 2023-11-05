using Advocacia.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models.Helper
{
    public class Utils
    {
        private static Usuario _usuarioLogado;
        public static Usuario UsuarioLogado
        {
            get
            {
                try
                {
                    _usuarioLogado = (Usuario)HttpContext.Current.Session["usuarioLogado"];
                }
                catch
                {
                    _usuarioLogado = null;
                }
                return _usuarioLogado;
            }
            set
            {
                _usuarioLogado = value;
                HttpContext.Current.Session["usuarioLogado"] = _usuarioLogado;
            }
        }
    }
}