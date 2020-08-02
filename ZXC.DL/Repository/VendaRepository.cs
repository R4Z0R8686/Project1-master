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
    public class VendaRepository : IVendaRepository
    {
        string cs = @"Data Source=(localdb)\v11.0;Initial Catalog=Multi2;Integrated Security=True";

        //CREATE
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

        public Venda ReadVendaSingle(int id)
        {
            string sql = "Select * from Venda Where ID=@ID";
            using (var connection = new SqlConnection(cs))
            {
                connection.Open();
                var venda = connection.QuerySingle<Venda>(sql, new
                {
                    id
                });
                return venda;
            }


        }

        //UPDATE
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
