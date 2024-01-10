using ApiCatalago.Model;
using ApiCatalago.Pagination;

namespace ApiCatalago.Repository;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<PagedList<Categoria>> GetCategorias(CategoriasParameters categoriaParameters);
    Task<IEnumerable<Categoria>> GetCategoriasProdutos();
}
