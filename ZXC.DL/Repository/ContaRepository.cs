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
    public class ContaRepository : IContaRepository
    {
        string cs = @"Data Source=(localdb)\v11.0;Initial Catalog=Multi2;Integrated Security=True";

        //CREATE
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

        //READ
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

        public Conta ReadSingleConta(string id)
        {
            string sql = "Select * from Conta Where Ref = @ID";
            using (var connection = new SqlConnection(cs))
            {

                connection.Open();
                var conta = connection.QuerySingle<Conta>(sql, new
                {
                    id
                });
                return conta;
            }
        }

        //UPDATE
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

        //DELETE
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

    }
}
