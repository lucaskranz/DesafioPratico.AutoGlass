using AutoMapper;
using DesafioPratico.AutoGlass.API.DTOs;
using DesafioPratico.AutoGlass.Domain.Models;

namespace DesafioPratico.AutoGlass.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
