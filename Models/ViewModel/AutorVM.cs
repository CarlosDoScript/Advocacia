using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models.ViewModel
{
    public class AutorVM
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string dtRegistro { get; set; }
        public string dtNascimento { get; set; }
        public string dtNascimentoFormatado { get; set; }
    }
}