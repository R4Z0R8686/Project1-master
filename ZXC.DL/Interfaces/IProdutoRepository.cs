using System.Collections.Generic;
using ZXC.MODEL.ObjectModel;

namespace ZXC.DL.Repository
{
    public interface IProdutoRepository
    {
        void CreateProduto(Produto produto);
        void DeleteProduto(string id);
        IEnumerable<Produto> ReadProduto();
        void UpdateProduto(Produto produto);
    }
}