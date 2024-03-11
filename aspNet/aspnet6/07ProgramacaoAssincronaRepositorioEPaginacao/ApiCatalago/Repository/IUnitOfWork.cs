namespace ApiCatalago.Repository;

public interface IUnitOfWork
{
    // implementa as 2 classes
    IProdutoRepository ProdutoRepository { get; }
    ICategoriaRepository CategoriaRepository { get; }
    // método para salvar
    Task Commit();
}
