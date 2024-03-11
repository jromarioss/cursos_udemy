using ApiCatalago.Context;
using ApiCatalago.Model;
using ApiCatalago.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Repository;

// herda da classe repository por que assim tem acesso a toda implementação que foi feita na classe
public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext contexto) : base(contexto) // receba o dbcontexto e passe para classe base
    {}

    public async Task<PagedList<Produto>> GetProdutos(ProdutosParameters produtosParameters)
    {
        //return Get()
        //    .OrderBy(on => on.Name)
        //    .Skip((produtosParameters.PageNumber - 1) * produtosParameters.PageSize)
        //    .Take(produtosParameters.PageSize)
        //    .ToList();

        return await PagedList<Produto>.ToPagedList(
            Get().OrderBy(on => on.Name), produtosParameters.PageNumber, produtosParameters.PageSize
        );
    }

    public async Task<IEnumerable<Produto>> GetProdutosPeloPreco()
    {
        return await Get().OrderBy(c => c.Preco).ToListAsync(); //ordena pelo preço
    }
}
