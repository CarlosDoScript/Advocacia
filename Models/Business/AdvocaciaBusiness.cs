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
        public List<Login> GetUsuarioSenha(string usuario, string senha)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var resultado = banco.Query<Login>("SELECT Usuario,Senha FROM Login WHERE Usuario = @Usuario AND Senha = @Senha", new { Usuario = usuario, Senha = senha }).ToList();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                return new List<Login>();
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
    }
}