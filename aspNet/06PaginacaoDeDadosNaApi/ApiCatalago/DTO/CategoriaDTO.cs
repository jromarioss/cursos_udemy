using ApiCatalago.Model;

namespace ApiCatalago.DTO;

public class CategoriaDTO
{
    public int CategoriaId { get; set; }
    public string? Name { get; set; }
    public string? ImagemUrl { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
}
