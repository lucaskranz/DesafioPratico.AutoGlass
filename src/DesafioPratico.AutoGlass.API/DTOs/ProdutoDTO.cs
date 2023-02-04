using DesafioPratico.AutoGlass.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DesafioPratico.AutoGlass.API.DTOs
{
    public class ProdutoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, 1, ErrorMessage = "O campo {0} só aceita 0 - Inativo e 1 - Ativo")]
        public SituacaoProduto Situacao { get; set; }

        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime? DataFabricacao { get; set; }

        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime? DataValidade { get; set; }
        public int? IdFornecedor { get; set; }
        public string? DescricaoFornecedor { get; set; }

        [StringLength(14, ErrorMessage = "O campo {0} precisa ter 14 caracteres", MinimumLength = 14)]
        public string? CNPJ { get; set; }
    }
}
