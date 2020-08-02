using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXC.DL.Repository;
using ZXC.MODEL.ObjectModel;

namespace ZXC.BL
{
    public class VendaOperations : IVendaRepository
    {
        readonly IVendaRepository _vendaRepository;

        public VendaOperations(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public VendaOperations()
        {
            _vendaRepository = new VendaRepository();
        }

        public void CreateVenda(Venda venda)
        {
            _vendaRepository.CreateVenda(venda);
        }

        public void DeleteVenda(int id)
        {
            _vendaRepository.DeleteVenda(id);
        }

        public IEnumerable<Venda> ReadVenda()
        {
            return _vendaRepository.ReadVenda();
        }

        public Venda ReadVendaSingle(int id)
        {
            return _vendaRepository.ReadVendaSingle(id);
        }

        public void UpdateVenda(Venda venda)
        {
            _vendaRepository.UpdateVenda(venda);
        }


    }
}
