using ApiCatalago.Context;
using ApiCatalago.Model;
using ApiCatalago.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext contexto) : base(contexto)
    {}

    public async Task<PagedList<Categoria>> GetCategorias(CategoriasParameters categoriaParameters)
    {
        return await PagedList<Categoria>.ToPagedList(
            Get().OrderBy(on => on.Name), categoriaParameters.PageNumber, categoriaParameters.PageSize);
    }

    public async Task<IEnumerable<Categoria>> GetCategoriasProdutos()
    {
        return await Get().Include(x => x.Produtos).ToListAsync();
    }
}
