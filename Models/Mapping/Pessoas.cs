using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Advocacia.Models.Mapping
{
    public class Pessoas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }

    public class Login
    {
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}