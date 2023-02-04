using DesafioPratico.AutoGlass.Domain.Filters;
using DesafioPratico.AutoGlass.Domain.Interfaces.Repository;
using DesafioPratico.AutoGlass.Domain.Models;
using DesafioPratico.AutoGlass.Domain.Paginacao;
using DesafioPratico.AutoGlass.Domain.Paginacao.Helper;
using DesafioPratico.AutoGlass.Infra.Context;
using DesafioPratico.AutoGlass.Infra.Repository.Base;

namespace DesafioPratico.AutoGlass.Infra.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context) { }

        public async Task InativarProduto(Produto produto)
        {           
            DbSet.Update(produto);
            await SaveChanges();
        }

        public async Task<PagedBaseResponse<Produto>> GetPagedAsync(ProdutoFilterDb request)
        {
            var produto = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(request.Descricao))
            {
                produto = produto.Where(x => x.Descricao.Contains(request.Descricao));
            }

            if (request.Situacao != null)
            {
                produto = produto.Where(x => x.Situacao == request.Situacao);

            }

            if (!string.IsNullOrEmpty(request.CNPJ))
            {
                produto = produto.Where(x => x.CNPJ.Contains(request.CNPJ));
            }

            if (request.ProdutosVencidos != null ? (bool)request.ProdutosVencidos : false)
            {
                produto = produto.Where(x => x.DataValidade < DateTime.Now.Date);
            }

            if (request.IdFornecedor != null)
            {
                produto = produto.Where(x => x.IdFornecedor == request.IdFornecedor);

            }

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Produto>, Produto>(produto, request);
        }
    }
}
