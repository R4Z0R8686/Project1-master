using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXC.DL.Repository;
using ZXC.MODEL.ObjectModel;

namespace ZXC.BL
{
    public class ContaOperations : IContaRepository
    {
        readonly IContaRepository _contaRepository;

        public ContaOperations(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public ContaOperations()
        {
            _contaRepository = new ContaRepository();
        }

        public void CreateConta(Conta conta)
        {
            _contaRepository.CreateConta(conta);
        }

        public void DeleteConta(string id)
        {
            _contaRepository.DeleteConta(id);
        }

        public IEnumerable<Conta> ReadConta()
        {
            return _contaRepository.ReadConta();
        }

        public Conta ReadSingleConta(string id)
        {
            return _contaRepository.ReadSingleConta(id);
        }

        public void UpdateConta(Conta conta)
        {
            _contaRepository.UpdateConta(conta);
        }
    }
}
