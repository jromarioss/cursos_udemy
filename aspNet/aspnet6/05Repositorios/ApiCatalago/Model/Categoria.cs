using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalago.Model;

[Table("Categorias")]
public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>(); //inicializa a propriedade produto
    }

    [Key]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Informe o nome.")] //tamanho da string e texto de error
    public string? Name { get; set; } //? define como nullo a propriedade

    [Required]
    [StringLength(300, ErrorMessage = "Informe a imagem.")]
    public string? ImagemUrl { get; set; }

    //definindo relacionamento
    public ICollection<Produto>? Produtos { get; set; } //cada categoria pode ter um coleção de produtos
}
