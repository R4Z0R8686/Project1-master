using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXC.DL.Repository;
using ZXC.MODEL.ObjectModel;

namespace ZXC.BL
{
    public class ProdutoOperations : IProdutoRepository
    {

        readonly IProdutoRepository _produtoRepository;

        public ProdutoOperations(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ProdutoOperations()
        {
            _produtoRepository = new ProdutoRepository();
        }

        public void CreateProduto(Produto produto)
        {
            _produtoRepository.CreateProduto(produto);
        }

        public void DeleteProduto(string id)
        {
            _produtoRepository.DeleteProduto(id);
        }

        public IEnumerable<Produto> ReadProduto()
        {
            return _produtoRepository.ReadProduto();
        }

        public void UpdateProduto(Produto produto)
        {
            _produtoRepository.UpdateProduto(produto);
        }
    }
}
