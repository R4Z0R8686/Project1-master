using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXC.DL;
using ZXC.DL.Repository;
using ZXC.MODEL.ObjectModel;

namespace ZXC.BL
{
    public class ClienteOperations : IClienteRepository
    {
        //CONSTRUCTOR INJECTION
        readonly IClienteRepository _clienteRepository;

        public ClienteOperations(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ClienteOperations()
        {
            _clienteRepository = new ClienteRepository();
        }

        //CREATE
        public void CreateCliente(Cliente cliente)
        {
            _clienteRepository.CreateCliente(cliente);
        }
   
        //READ
        public IEnumerable<Cliente> ReadCliente()
        {
            return _clienteRepository.ReadCliente();
        }

        public Cliente ReadSingleCliente(int id)
        {
            return _clienteRepository.ReadSingleCliente(id);
        }

        //UPDATE
        public void UpdateCliente(Cliente cliente)
        {
            _clienteRepository.UpdateCliente(cliente);
        }

        public void DeleteCliente(int id)
        {
                    
            _clienteRepository.DeleteCliente(id);
            
        }

       
    }
}
