using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models.ViewModel
{
    public class VMPostagem
    {
        public string titulo { get; set; }
        public string conteudo { get; set; }
        public string dtPublicacao { get; set; }
        public string nome_imagem_gerada { get; set; }
        public string minutos_leitura { get; set; }
        public string conteudo_sem_formatacao { get; set; }
        public string nome_autor { get; set; }
        public string nome_categoria { get; set; }
        public string nome_finalidade { get; set; }
    }
    public class VMPostagemBlog
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string conteudo { get; set; }
        public string dtPublicacao { get; set; }
        public string nome_imagem_gerada { get; set; }
        public string minutos_leitura { get; set; }
        public string conteudo_sem_formatacao { get; set; }
        public string nome_autor { get; set; }
        public string nome_categoria { get; set; }
        public string nome_finalidade { get; set; }
    }
}