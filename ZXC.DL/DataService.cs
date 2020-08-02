using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using ZXC.MODEL;
using ZXC.MODEL.ObjectModel;

namespace ZXC.DL
{
    public class DataService
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
        public void CreateConta(Conta conta)
        {

            using (var connection = new SqlConnection(cs))
            {
                string sql = @"Insert INTO Conta  ([Ref],[Cliente_ID],[Marca],[Modelo],[Obs]) VALUES (@Ref,@Cliente_ID,@Marca,@Modelo,@Obs)";
                connection.Open();

                var result = connection.Execute(sql, new
                {
                    conta.Ref,
                    conta.Cliente_ID,
                    conta.Marca,
                    conta.Modelo,
                    conta.Obs

                });
            }

        }
        public void CreateProduto(Produto produto)
        {

            using (var connection = new SqlConnection(cs))
            {
                string sql = @"Insert INTO Produto  ([Ref],[Num_Meses],[Valor]) VALUES (@Ref,@Num_Meses,@Valor)";
                connection.Open();

                var result = connection.Execute(sql, new
                {
                    produto.Ref,
                    produto.Num_Meses,
                    produto.Valor

                });
            }

        }
        public void CreateVenda(Venda venda)
        {

            using (var connection = new SqlConnection(cs))
            {
                string sql = @"Insert INTO Venda ([Conta],[Produto],[Meses],[Valor],[Validade_Anterior],[Validade_Atual]) VALUES  (@Conta,@Produto,@Meses,@Valor,@Validade_Anterior,@Validade_Atual)";
                connection.Open();

                var result = connection.Execute(sql, new
                {
                    venda.Conta,
                    venda.Produto,
                    venda.Meses,
                    venda.Valor,
                    venda.Validade_Anterior,
                    venda.Validade_Atual
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
        public IEnumerable<Conta> ReadConta()
        {
            string sql = "Select * from Conta";
            using (var connection = new SqlConnection(cs))
            {
                connection.Open();
                var lista = connection.Query<Conta>(sql).ToList();
                return lista;
            }
        }
        public IEnumerable<Venda> ReadVenda()
        {
            string sql = "Select * from Venda";
            using (var connection = new SqlConnection(cs))
            {
                connection.Open();
                var lista = connection.Query<Venda>(sql).ToList();
                return lista;
            }
        }
        public IEnumerable<Produto> ReadProduto()
        {
            string sql = "Select * from Produto";
            using (var connection = new SqlConnection(cs))
            {
                connection.Open();
                var lista = connection.Query<Produto>(sql).ToList();
                return lista;
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
        public void UpdateConta(Conta conta)
        {
            using (var connection = new SqlConnection(cs))
            {
                string sql = @"Update Conta SET Cliente_ID = @Cliente_ID, Marca = @Marca, Modelo = @Modelo, Obs = @Obs WHERE Ref = @Ref";
                var result = connection.Execute(sql, new
                {
                    conta.Cliente_ID,
                    conta.Marca,
                    conta.Modelo,
                    conta.Obs,
                    conta.Ref
                });
            }
        }
        public void UpdateProduto(Produto produto)
        {
            using (var connection = new SqlConnection(cs))
            {
                string sql = @"Update Produto SET Num_Meses = @Num_Meses, Valor = @Valor WHERE Ref = @Ref";
                var result = connection.Execute(sql, new
                {
                    produto.Num_Meses,
                    produto.Valor,
                    produto.Ref
                });
            }
        }
        public void UpdateVenda(Venda venda)
        {
            using (var connection = new SqlConnection(cs))
            {
                string sql = @"Update Venda SET Conta = @Conta, Produto = @Produto, Meses = @Meses, Valor = @Valor, Validade_Anterior = @Validade_Anterior, Validade_Atual = @Validade_Atual WHERE ID = @ID";
                var result = connection.Execute(sql, new
                {
                    venda.Conta,
                    venda.Produto,
                    venda.Meses,
                    venda.Valor,
                    venda.Validade_Anterior,
                    venda.Validade_Atual,
                    venda.ID
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
        public void DeleteConta(string id)
        {
            using (var connection = new SqlConnection(cs))
            {
                string sql = @"DELETE FROM Conta Where Ref = @ID";
                connection.Execute(sql, new
                {
                    id
                });
            }
        }
        public void DeleteProduto(string id)
        {
            using (var connection = new SqlConnection(cs))
            {
                string sql = @"DELETE FROM Produto Where Ref = @ID";
                connection.Execute(sql, new
                {
                    id
                });
            }
        }
        public void DeleteVenda(int id)
        {
            using (var connection = new SqlConnection(cs))
            {
                string sql = @"DELETE FROM Venda Where ID = @ID";
                connection.Execute(sql, new
                {
                    id
                });
            }
        }




    }
}
