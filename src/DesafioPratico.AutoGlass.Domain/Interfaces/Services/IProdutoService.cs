using DesafioPratico.AutoGlass.Domain.Models;

namespace DesafioPratico.AutoGlass.Domain.Interfaces.Services
{
    public interface IProdutoService : IDisposable
    {
        Task<bool> Adicionar(Produto produto);
        Task<bool> Atualizar(Produto produto);
        Task<Produto> InativarProduto(int id);
    }
}
