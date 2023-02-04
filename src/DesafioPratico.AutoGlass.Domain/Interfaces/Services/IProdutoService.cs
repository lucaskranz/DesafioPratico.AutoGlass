using DesafioPratico.AutoGlass.Domain.Filters;
using DesafioPratico.AutoGlass.Domain.Models;
using DesafioPratico.AutoGlass.Domain.Paginacao;
using DesafioPratico.AutoGlass.Domain.Paginacao.DTOs;

namespace DesafioPratico.AutoGlass.Domain.Interfaces.Services
{
    public interface IProdutoService : IDisposable
    {
        Task<bool> Adicionar(Produto produto);
        Task<bool> Atualizar(Produto produto);
        Task<Produto> InativarProduto(int id);
        Task<PagedBaseResponseDTO<Produto>> GetPagedAsync(ProdutoFilterDb produtoFilterDb);
    }
}
