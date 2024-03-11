using ApiCatalago.Model;
using AutoMapper;

namespace ApiCatalago.DTO.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
    }
}
