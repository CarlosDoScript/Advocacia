using Advocacia.Models.Helper;
using Advocacia.Models.Mapping;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models
{
    public class AdvocaciaBusiness
    {
        public Usuario GetUsuarioSenha(string usuario, string senha)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var resultado = banco.Query<Usuario>("SELECT * FROM Usuarios WHERE NomeLogin = @Usuario AND Senha = @Senha", new { Usuario = usuario, Senha = senha }).FirstOrDefault();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SalvarInfoGeral(Pessoas pessoas)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    return banco.Execute("INSERT INTO Pessoas (Nome,Email,Celular,Titulo,Mensagem) VALUES(@Nome, @Email, @Celular, @Titulo, @Mensagem)", pessoas) == 1;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Pessoas> getPessoas()
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var pessoas =  banco.Query<Pessoas>("SELECT * FROM Pessoas").ToList();
                    return pessoas;
                }
            }
            catch (Exception)
            {
                return new List<Pessoas>();
            }
        }

        public List<Usuario> GetUsuarios()
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var pessoas = banco.Query<Usuario>("SELECT * FROM Usuarios").ToList();
                    return pessoas;
                }
            }
            catch (Exception)
            {
                return new List<Usuario>();
            }
        }

        public int deletePessoa(int Id)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    return banco.Execute("DELETE Pessoas WHERE Id = @Id", new { Id });
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int PostUsuario(string nome, string nomeLogin, string email, string senha, bool adm)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    return banco.Execute("INSERT INTO Usuarios (NomeLogin,Senha,Email,adm,Nome) VALUES(@NomeLogin,@Senha,@Email,@adm,@Nome)", new {NomeLogin = nomeLogin,Senha = senha, Email = email,adm = adm,Nome=nome });
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
        public int EditarUsuarios(string nome, string nomeLogin, string email, string senha, bool adm,int idUsuario)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    return banco.Execute("UPDATE Usuarios SET NomeLogin = @NomeLogin ,Senha = @Senha ,Email = @Email ,adm = @adm ,Nome = @Nome WHERE id = @id ", new {NomeLogin = nomeLogin,Senha = senha, Email = email,adm = adm,Nome=nome,id = idUsuario });
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
        public int DeleteUsuario(int idUsuario)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    return banco.Execute("DELETE Usuarios WHERE id = @id", new {id = idUsuario});
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}