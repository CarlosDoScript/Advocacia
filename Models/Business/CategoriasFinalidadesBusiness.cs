using Advocacia.Models.Helper;
using Advocacia.Models.Mapping;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models.Business
{
    public class CategoriasFinalidadesBusiness
    {
        public List<Categorias> GetCategorias()
        {
            try
            {
                using (var db = new Connection().SQL())
                {
                    var categorias = db.Query<Categorias>("SELECT * FROM Categorias").ToList();

                    return categorias;
                }
            }
            catch (Exception ex)
            {
                return new List<Categorias>();
            }
        }

        public Categorias GetCategoria(int idCategoria)
        {
            try
            {
                using (var db = new Connection().SQL())
                {
                    var categorias = db.Query<Categorias>("SELECT * FROM Categorias WHERE id = @id",new {id = idCategoria}).FirstOrDefault();

                    return categorias;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int PostCategoria(string descricao)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var result = banco.Execute("INSERT INTO Categorias (descricao) VALUES(@descricao)", new { descricao });
                    return result;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int DeleteCategoria(int id)
        {
            try
            {
                using (var db = new Connection().SQL())
                {
                    var result = db.Execute("DELETE Categorias WHERE id = @id", new { id });
                    return result;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int EditarCategoria(int id, string descricao)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var result = banco.Execute("UPDATE Categorias SET descricao = @descricao WHERE id = @id", new { id = id, descricao = descricao });
                    return result;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int PostFinalidades(int idCategoria, string descricao)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var result = banco.Execute("INSERT INTO Finalidades (id_categoria,descricao) VALUES(@id_categoria,@descricao)", new { id_categoria = idCategoria, descricao = descricao });
                    return result;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int EditarFinalidade(int id, string descricao)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var result = banco.Execute("UPDATE Finalidades SET descricao = @descricao WHERE id = @id", new { id = id, descricao = descricao });
                    return result;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int DeletarFinalidade(int id)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var result = banco.Execute("DELETE Finalidades WHERE id = @id", new { id = id });
                    return result;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<Finalidades> GetFinalidades(int idCategoria)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var finalidades = banco.Query<Finalidades>("SELECT * FROM Finalidades WHERE id_categoria = @idCategoria", new { idCategoria = idCategoria }).ToList();
                    return finalidades;
                }
            }
            catch (Exception ex)
            {
                return new List<Finalidades>();
            }
        }

        public Categorias GetCategoriaById(int id)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    int idCategoria = banco.Query<VMFinalidades>("SELECT * FROM Finalidades WHERE id = @id", new { id = id }).FirstOrDefault().id_categoria;
                    var categoria = banco.Query<Categorias>("SELECT * FROM Categorias WHERE id = @id",new {id = idCategoria}).FirstOrDefault();                    
                    return categoria;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int VerificaFinalidadePostagens(int idFinalidade)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    int existeFinalidade = banco.Query<int>("SELECT COUNT (*) FROM Postagens P LEFT JOIN Finalidades F ON F.id_categoria = P.id_categoria WHERE P.id_finalidade = @idFinalidade", new { idFinalidade = idFinalidade }).FirstOrDefault();
                    return existeFinalidade;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        
        public int VerificaCategoriaPostagens(int idCategoria)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    int existeFinalidade = banco.Query<int>("SELECT COUNT (*) FROM Postagens P LEFT JOIN Categorias C ON C.id = P.id_categoria WHERE P.id_categoria = @idCategoria", new { idCategoria = idCategoria }).FirstOrDefault();
                    return existeFinalidade;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}