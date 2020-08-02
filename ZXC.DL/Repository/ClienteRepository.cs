using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXC.MODEL.ObjectModel;

namespace ZXC.DL.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        string cs = @"Data Source=(localdb)\v11.0;Initial Catalog=Multi2;Integrated Security=True";

        //CREATE
        public void CreateCliente(Cliente cliente)
        {

            using (var connection = new SqlConnection(cs))
            {
                string sql = @"Insert INTO Cliente  ([Nome],[Telefone],[Mail]) VALUES (@Nome,@Telefone,@Mail)";
                connection.Open();

                var result = connection.Execute(sql, new
                {
                    cliente.Nome,
                    cliente.Telefone,
                    cliente.Mail

                });

            }
        }

        //READ
        public IEnumerable<Cliente> ReadCliente()
        {
            string sql = "Select * from Cliente";
            using (var connection = new SqlConnection(cs))
            {

                connection.Open();
                var lista = connection.Query<Cliente>(sql).ToList();
                return lista;
            }
        }

        public Cliente ReadSingleCliente(int id)
        {
            string sql = "Select * from Cliente Where ID = @ID";
            using (var connection = new SqlConnection(cs))
            {

                connection.Open();
                var cliente = connection.QuerySingle<Cliente>(sql, new
                {
                    id
                });
                return cliente;
            }
        }

        
        //UPDATE
        public void UpdateCliente(Cliente cliente)
        {
            using (var connection = new SqlConnection(cs))
            {
                string sql = @"Update Cliente SET Nome = @Nome, Telefone = @Telefone, Mail = @Mail WHERE ID = @ID";
                var result = connection.Execute(sql, new
                {
                    cliente.Nome,
                    cliente.Telefone,
                    cliente.Mail,
                    cliente.ID
                });
            }
        }

        //DELETE
        public void DeleteCliente(int id)
        {
          
            using (var connection = new SqlConnection(cs))
            {
                string sql = @"DELETE FROM Cliente Where ID = @ID";
                connection.Execute(sql, new
                {
                    id
                });
            }
          

        }

    }
}
