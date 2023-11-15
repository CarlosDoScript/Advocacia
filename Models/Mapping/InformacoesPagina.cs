using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models.Mapping
{
    public class InformacoesPagina
    {
        public int casosProcessos { get; set; }
        public int casosEncerrados { get; set; }
        public int clientesConfiaveis { get; set; }
        public int equipeEspecialistas { get; set; }
    }
}