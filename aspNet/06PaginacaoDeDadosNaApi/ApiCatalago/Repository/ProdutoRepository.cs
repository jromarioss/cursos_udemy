using ApiCatalago.Context;
using ApiCatalago.Model;
using ApiCatalago.Pagination;

namespace ApiCatalago.Repository;

// herda da classe repository por que assim tem acesso a toda implementação que foi feita na classe
public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext contexto) : base(contexto) // receba o dbcontexto e passe para classe base
    {}

    public PagedList<Produto> GetProdutos(ProdutosParameters produtosParameters)
    {
        //return Get()
        //    .OrderBy(on => on.Name)
        //    .Skip((produtosParameters.PageNumber - 1) * produtosParameters.PageSize)
        //    .Take(produtosParameters.PageSize)
        //    .ToList();

        return PagedList<Produto>.ToPagedList(
            Get().OrderBy(on => on.Name), produtosParameters.PageNumber, produtosParameters.PageSize
        );
    }

    public IEnumerable<Produto> GetProdutosPeloPreco()
    {
        return Get().OrderBy(c => c.Preco).ToList(); //ordena pelo preço
    }
}
