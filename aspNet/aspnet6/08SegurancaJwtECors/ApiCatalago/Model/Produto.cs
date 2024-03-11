using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalago.Model;

[Table("Produtos")]
public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required] //obrigatório
    [StringLength(100, ErrorMessage = "Informe o nome.")]
    public string? Name { get; set; } //? define como nullo a propriedade

    [Required]
    [StringLength(300, ErrorMessage = "Informe a descrição.")]
    public string? Descricao { get; set; }

    [Required]
    [DataType(DataType.Currency)] // para o banco saber que é dinheiro
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300, ErrorMessage = "Informe a imagem.")]
    public string? ImagemUrl { get; set; }

    [Required]
    public int Estoque { get; set; }
    public DateTime DataCadastro { get; set; }

    //definindo o relacionamento
    public int CategoriaId { get; set; }

    [JsonIgnore]
    public Categoria? Categoria { get; set; } //cada produto está mapeado de um categoria
}
