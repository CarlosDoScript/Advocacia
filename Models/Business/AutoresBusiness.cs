using Advocacia.Models.Helper;
using Advocacia.Models.Mapping;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models.Business
{
    public class AutoresBusiness
    {
        public List<Autor> GetAutores()
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var autores = banco.Query<Autor>("SELECT * FROM Autores").ToList();
                    return autores;
                }
            }
            catch (Exception)
            {
                return new List<Autor>();
            }
        }
        
        public Autor GetAutorById(int idAutor)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var autores = banco.Query<Autor>("SELECT * FROM Autores WHERE Id = @id",new {id = idAutor}).FirstOrDefault();
                    return autores;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int DeleteAutor(int Id)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    return banco.Execute("DELETE Autores WHERE Id = @Id", new { Id });
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int PostAutor(string nome, string email,DateTime dtNascimento)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    return banco.Execute("INSERT INTO Autores (nome,email,dtRegistro,dtNascimento) VALUES(@nome,@email,@dtRegistro,@dtNascimento)", new { nome = nome, email = email, dtRegistro = DateTime.Now, dtNascimento = dtNascimento });
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int EditarAutor(string nome, string email, DateTime dtNascimento, int id)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    return banco.Execute("UPDATE Autores SET nome = @nome ,email = @email ,dtNascimento = @dtNascimento WHERE id = @id ", new { nome = nome,email = email,dtNascimento = dtNascimento, id = id });
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}