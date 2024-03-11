using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

[Table("Categorias")]
public class Categoria
{
    //inicializando a propriedade produto
    public Categoria() 
    {
        Produtos = new Collection<Produto>();
    }

    //propriedades de gerencia a categoria
    [Key] //dataannotations
    public int CategoriaId { get; set; } //chave primaria

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public ICollection<Produto>? Produtos { get; set; } //fazendo os relacionamento com produto pode ter coleção de produtos
    //dotnet ef migrations add nome
    //dotnet ef database update
}
