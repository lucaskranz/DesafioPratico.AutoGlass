using DesafioPratico.AutoGlass.Domain.Models;

namespace DesafioPratico.AutoGlass.Domain.Interfaces.Services
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(int id);
    }
}
