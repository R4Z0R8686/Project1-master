using System.Collections.Generic;
using ZXC.MODEL.ObjectModel;

namespace ZXC.DL.Repository
{
    public interface IContaRepository
    {
        void CreateConta(Conta conta);
        void DeleteConta(string id);
        IEnumerable<Conta> ReadConta();
        Conta ReadSingleConta(string id);
        void UpdateConta(Conta conta);
    }
}