using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models.Mapping
{
    public class Postagens
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string conteudo { get; set; }
        public DateTime dtPublicacao { get; set; }
        public int id_autor { get; set; }
        public string nome_imagem_gerada { get; set; }
        public int id_categoria { get; set; }
        public int id_finalidade { get; set; }
        public string minutos_leitura { get; set; }
        public string conteudo_sem_formatacao { get; set; }
    }
    public class Postar
    {
        public int Id { get; set; }
        public string titulo { get; set; }
        public string conteudo { get; set; }
        public DateTime dtPublicacao { get; set; }
        public int id_autor { get; set; }
        public string nome_imagem_gerada { get; set; }
    }

    public class Categorias
    {
        public int id { get; set; }
        public string descricao { get; set; }
    }
    
    public class Finalidades
    {
        public int id { get; set; }
        public string descricao { get; set; }
    }

    public class VMFinalidades
    {
        public int id { get; set; }
        public int id_categoria { get; set; }
        public string descricao { get; set; }
    }
}