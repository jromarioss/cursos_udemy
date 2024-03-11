using ApiCatalago.Context;
using ApiCatalago.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext contexto) : base(contexto)
    {}

    public IEnumerable<Categoria> GetCategoriasProdutos()
    {
        return Get().Include(x => x.Produtos);
    }
}
