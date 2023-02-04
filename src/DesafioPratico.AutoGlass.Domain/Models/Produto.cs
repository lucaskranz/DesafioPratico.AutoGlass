using DesafioPratico.AutoGlass.Domain.Enums;
using DesafioPratico.AutoGlass.Domain.Models.Base;

namespace DesafioPratico.AutoGlass.Domain.Models
{
    public class Produto: Entity
    {
        public string Descricao { get; set; }
        public SituacaoProduto Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int IdFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJ { get; set; }
    }
}
