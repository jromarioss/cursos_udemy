using ApiCatalago.Model;

namespace ApiCatalago.Repository;

public interface ICategoriaRepository : IRepository<Categoria>
{
    IEnumerable<Categoria> GetCategoriasProdutos();
}
