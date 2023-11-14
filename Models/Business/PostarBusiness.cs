using Advocacia.Models.Helper;
using Advocacia.Models.Mapping;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models.Business
{
    public class PostarBusiness
    {
        public int CriarPost(string titulo, int idCategoria, int idFinalidade, int idAutor, string conteudo, string nomeGeradoImagem, string minutosLeitura, string conteudoOriginal)
        {
            try
            {
                using (var db = new Connection().SQL())
                {
                    var result = db.Execute("INSERT INTO Postagens (conteudo,dtPublicacao,titulo,id_autor,nome_imagem_gerada,id_categoria,id_finalidade,minutos_leitura,conteudo_sem_formatacao) VALUES(@conteudo,@dtPublicacao,@titulo,@id_autor,@nome_imagem_gerada,@id_categoria,@id_finalidade,@minutos_leitura,@conteudo_sem_formatacao)", new { conteudo = conteudo, dtPublicacao = DateTime.Now.Date,titulo = titulo, id_autor = idAutor, nome_imagem_gerada = nomeGeradoImagem, id_categoria = idCategoria, id_finalidade = idFinalidade, minutos_leitura = minutosLeitura, conteudo_sem_formatacao = conteudoOriginal });
                    return result;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<Postagens> GetPostagens(int idFinalidade)
        {
            try
            {
                using (var db = new Connection().SQL())
                {
                    var postagens = db.Query<Postagens>("SELECT * FROM Postagens WHERE id_finalidade = @idFinalidade", new { idFinalidade = idFinalidade }).ToList();
                    return postagens;
                }
            }
            catch (Exception ex)
            {
                return new List<Postagens>();
            }
        }
        
        public Postagens GetPostagensById(int id)
        {
            try
            {
                using (var db = new Connection().SQL())
                {
                    var postagens = db.Query<Postagens>("SELECT * FROM Postagens WHERE id = @id", new { id = id }).FirstOrDefault();
                    return postagens;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int DeletarPostagem(int idPostagem)
        {
            try
            {
                using (var db = new Connection().SQL())
                {
                    var result = db.Execute("DELETE Postagens WHERE id = @id",new {id = idPostagem});
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