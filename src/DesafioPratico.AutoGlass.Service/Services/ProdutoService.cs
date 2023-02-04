using DesafioPratico.AutoGlass.Domain.Enums;
using DesafioPratico.AutoGlass.Domain.Interfaces.Notificacoes;
using DesafioPratico.AutoGlass.Domain.Interfaces.Repository;
using DesafioPratico.AutoGlass.Domain.Interfaces.Services;
using DesafioPratico.AutoGlass.Domain.Models;

namespace DesafioPratico.AutoGlass.Service.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Produto produto)
        {
            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (produto == null)
            {
                Notificar("Produto não encontrado.");
                return;
            }

            await _produtoRepository.Atualizar(produto);
        }

        public async Task<Produto> InativarProduto(int id)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            if (produto == null)
            {
                Notificar("Produto não encontrado.");
                return null;
            }

            if(produto.Situacao == SituacaoProduto.Inativo)
            {
                Notificar("Produto já está inativado.");
                return null;
            }

            produto.Situacao = SituacaoProduto.Inativo;

            await _produtoRepository.InativarProduto(produto);
            return produto;
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

    }
}
