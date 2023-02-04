namespace DesafioPratico.AutoGlass.Domain.Paginacao.DTOs
{
    public class PagedBaseResponseDTO<T>
    {
        public PagedBaseResponseDTO(int totalRegisters, List<T> data)
        {
            TotalRegisters = totalRegisters;
            Data = data;
        }

        public int TotalRegisters { get; set; }
        public List<T> Data { get; set; }
    }
}
