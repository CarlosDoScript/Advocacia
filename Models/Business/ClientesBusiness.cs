using Advocacia.Models.Helper;
using Advocacia.Models.Mapping;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advocacia.Models.Business
{
    public class ClientesBusiness
    {
        public List<Pessoas> GetClientes()
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    var pessoas = banco.Query<Pessoas>("SELECT * FROM Pessoas").ToList();
                    return pessoas;
                }
            }
            catch (Exception)
            {
                return new List<Pessoas>();
            }
        }

        public int DeleteCliente(int idCliente)
        {
            try
            {
                using (var banco = new Connection().SQL())
                {
                    return banco.Execute("DELETE Pessoas WHERE Id = @id", new { id = idCliente});                    
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}