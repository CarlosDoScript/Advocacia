using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models.Mapping
{
    public class Autor
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime dtRegistro { get; set; }
        public DateTime dtNascimento { get; set; }
    }
}