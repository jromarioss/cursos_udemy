using ApiCatalago.Context;
using ApiCatalago.Model;
using ApiCatalago.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext contexto) : base(contexto)
    {}

    public PagedList<Categoria> GetCategorias(CategoriasParameters categoriaParameters)
    {
        return PagedList<Categoria>.ToPagedList(
            Get().OrderBy(on => on.Name), categoriaParameters.PageNumber, categoriaParameters.PageSize);
    }

    public IEnumerable<Categoria> GetCategoriasProdutos()
    {
        return Get().Include(x => x.Produtos);
    }
}
