using DesafioPratico.AutoGlass.Domain.Enums;
using DesafioPratico.AutoGlass.Domain.Interfaces.Repository.Base;
using DesafioPratico.AutoGlass.Domain.Models;

namespace DesafioPratico.AutoGlass.Domain.Interfaces.Repository
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosVencidos(DateTime dataBase);
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(int idFornecedor);
        Task<IEnumerable<Produto>> ObterProdutosPorSituacao(SituacaoProduto situacao);
    }
}
