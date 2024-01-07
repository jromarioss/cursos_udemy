using APICatalogo.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

[Table("Produtos")]
public class Produto : IValidatableObject
{
    [Key]//dataannotations
    public int ProdutoId { get; set; }

    //usando a validação customizada
    //[PrimeiraLetraMaiuscula]
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(80, ErrorMessage = "Tamanho máximo 80 caracteres.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatório.")]
    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public float Estoque { get; set; }

    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; }

    [JsonIgnore] //assim ignora a serialização da propriedade
    public Categoria? Categoria { get; set; } //definindo o relacionamento

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(this.Nome))
        {
            var primeiraLetra = this.Nome[0].ToString();

            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                yield return new ValidationResult("A primeira letra do nome do produto dever ser maiuscula.",
                    new[] { nameof(this.Nome) });
            }
        }

        if (this.Estoque <= 0)
        {
            yield return new ValidationResult("O estoque deve ser maior que zero.",
                   new[] { nameof(this.Nome) });
        }
    }
}
