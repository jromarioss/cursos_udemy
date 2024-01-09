using ApiCatalago.Context;
using ApiCatalago.Model;

namespace ApiCatalago.Repository;

// herda da classe repository por que assim tem acesso a toda implementação que foi feita na classe
public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext contexto) : base(contexto) // receba o dbcontexto e passe para classe base
    {}

    public IEnumerable<Produto> GetProdutosPeloPreco()
    {
        return Get().OrderBy(c => c.Preco).ToList(); //ordena pelo preço
    }
}
