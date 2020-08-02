using System.Collections.Generic;
using ZXC.MODEL.ObjectModel;

namespace ZXC.DL.Repository
{
    public interface IVendaRepository
    {
        void CreateVenda(Venda venda);
        void DeleteVenda(int id);
        IEnumerable<Venda> ReadVenda();
        Venda ReadVendaSingle(int id);
        void UpdateVenda(Venda venda);
    }
}