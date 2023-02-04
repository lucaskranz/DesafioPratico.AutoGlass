using DesafioPratico.AutoGlass.Domain.Enums;
using DesafioPratico.AutoGlass.Domain.Interfaces.Repository;
using DesafioPratico.AutoGlass.Domain.Models;
using DesafioPratico.AutoGlass.Domain.Models.Base;
using DesafioPratico.AutoGlass.Infra.Context;
using DesafioPratico.AutoGlass.Infra.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace DesafioPratico.AutoGlass.Infra.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(int idFornecedor)
        {
            return await DbSet.AsNoTracking().Where(q => q.IdFornecedor == idFornecedor).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorSituacao(SituacaoProduto situacao)
        {
            return await DbSet.AsNoTracking().Where(q => q.Situacao == situacao).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosVencidos()
        {
            return await DbSet.AsNoTracking().Where(q => q.DataValidade < DateTime.Now.Date).ToListAsync();
        }

        public async Task InativarProduto(Produto produto)
        {           
            DbSet.Update(produto);
            await SaveChanges();
        }
    }
}
