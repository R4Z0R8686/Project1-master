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
    public class ProdutoRepository : IProdutoRepository
    {
        string cs = @"Data Source=(localdb)\v11.0;Initial Catalog=Multi2;Integrated Security=True";

        //CREATE
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

        //READ
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

        //DELETE
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

    }
}
