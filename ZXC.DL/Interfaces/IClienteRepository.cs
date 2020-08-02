using System.Collections.Generic;
using ZXC.MODEL.ObjectModel;

namespace ZXC.DL.Repository
{
    public interface IClienteRepository
    {
        void CreateCliente(Cliente cliente);
        void DeleteCliente(int id);
        IEnumerable<Cliente> ReadCliente();
        Cliente ReadSingleCliente(int id);
        void UpdateCliente(Cliente cliente);
       
    }
}