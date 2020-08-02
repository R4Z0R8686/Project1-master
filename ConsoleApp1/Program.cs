using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXC.BL;
using ZXC.MODEL.ObjectModel;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {



            ClienteOperations clienteOperation = new ClienteOperations();

            var cliente = clienteOperation.ReadSingleCliente(5);
            //Cliente cliente = new Cliente
            //{
            //    Nome = "Quim toino",
            //    Mail = "tonito@gmail.com",
            //    Telefone = "918995632"
            //};
            //clienteOperation.CreateCliente(cliente);
            //var listaClientes = clienteOperation.ReadCliente();


        }
    }
}
