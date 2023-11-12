using Advocacia.Models.Helper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models.Business
{
    public class PostarBusiness
    {
        public int CriarPost(string titulo, int idCategoria, int idFinalidade, int idAutor, string conteudo,string nomeGeradoImagem,string minutosLeitura)
        {
            try
            {
                using (var db = new Connection().SQL())
                {
                    var result = db.Execute("INSERT INTO Postagens (conteudo,dtPublicacao,id_autor,nome_imagem_gerada,id_categoria,id_finalidade,minutos_leitura) VALUES(@conteudo,@dtPublicacao,@id_autor,@nome_imagem_gerada,@id_categoria,@id_finalidade,@minutos_leitura)",new { conteudo = conteudo, dtPublicacao = DateTime.Now.Date, id_autor = idAutor, nome_imagem_gerada = nomeGeradoImagem, id_categoria = idCategoria, id_finalidade = idFinalidade, minutos_leitura = minutosLeitura });
                    return result;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}