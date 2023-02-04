using DesafioPratico.AutoGlass.Domain.Enums;
using DesafioPratico.AutoGlass.Domain.Filters;
using DesafioPratico.AutoGlass.Domain.Interfaces.Repository.Base;
using DesafioPratico.AutoGlass.Domain.Models;
using DesafioPratico.AutoGlass.Domain.Paginacao;

namespace DesafioPratico.AutoGlass.Domain.Interfaces.Repository
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        Task<PagedBaseResponse<Produto>> GetPagedAsync(ProdutoFilterDb request);
        Task InativarProduto(Produto produto);
    }
}
