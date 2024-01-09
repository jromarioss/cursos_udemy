using ApiCatalago.Model;
using ApiCatalago.Pagination;

namespace ApiCatalago.Repository;

public interface ICategoriaRepository : IRepository<Categoria>
{
    PagedList<Categoria> GetCategorias(CategoriasParameters categoriaParameters);
    IEnumerable<Categoria> GetCategoriasProdutos();
}
