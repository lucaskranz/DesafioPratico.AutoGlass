using DesafioPratico.AutoGlass.Domain.Enums;
using DesafioPratico.AutoGlass.Domain.Paginacao;

namespace DesafioPratico.AutoGlass.Domain.Filters
{
    public class ProdutoFilterDb: PagedBaseRequest
    {
        public string? Descricao { get; set; }
        public SituacaoProduto? Situacao { get; set; }
        public int? IdFornecedor { get; set; }
        public string? CNPJ { get; set; }
        public bool? ProdutosVencidos { get; set; }
    }
}
