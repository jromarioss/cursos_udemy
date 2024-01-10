using ApiCatalago.Model;

namespace ApiCatalago.DTO;

public class ProdutoDTO
{
    public int ProdutoId { get; set; }
    public string? Name { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public string? ImagemUrl { get; set; }
    public int CategoriaId { get; set; }
}
