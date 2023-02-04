using DesafioPratico.AutoGlass.Domain.Enums;
using DesafioPratico.AutoGlass.Domain.Filters;
using DesafioPratico.AutoGlass.Domain.Interfaces.Notificacoes;
using DesafioPratico.AutoGlass.Domain.Interfaces.Repository;
using DesafioPratico.AutoGlass.Domain.Interfaces.Services;
using DesafioPratico.AutoGlass.Domain.Models;
using DesafioPratico.AutoGlass.Domain.Paginacao;
using DesafioPratico.AutoGlass.Domain.Paginacao.DTOs;

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

        public async Task<bool> Adicionar(Produto produto)
        {
            if (!ValidacoesProdutoOk(produto)) return false;

            await _produtoRepository.Adicionar(produto);
            return true;
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            if(!ValidacoesProdutoOk(produto)) return false; 

            await _produtoRepository.Atualizar(produto);
            return true;
        }

        public async Task<Produto> InativarProduto(int id)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            if (produto == null)
            {
                Notificar("Produto não encontrado.");
                return null;
            }

            if (produto.Situacao == SituacaoProduto.Inativo)
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

        private bool ValidacoesProdutoOk(Produto produto)
        {
            if (produto == null)
            {
                Notificar("Produto não encontrado.");
                return false;
            }

            if (_produtoRepository.Buscar(q => q.Descricao.Equals(produto.Descricao)).Result.Any())
            {
                Notificar("Já existe um produto com a mesma descrição.");
                return false;
            }

            if(produto.DataFabricacao >= produto.DataValidade)
            {
                Notificar("A Data de Fabricação não pode ser maior ou igual que a Data de Validade.");
                return false;
            }



            return true;
        }

        public async Task<PagedBaseResponseDTO<Produto>> GetPagedAsync(ProdutoFilterDb produtoFilterDb)
        {
            var produtoPaged = await _produtoRepository.GetPagedAsync(produtoFilterDb);
            var result = new PagedBaseResponseDTO<Produto>(produtoPaged.TotalRegisters, produtoPaged.Data);

            return result;
        }
    }
}
