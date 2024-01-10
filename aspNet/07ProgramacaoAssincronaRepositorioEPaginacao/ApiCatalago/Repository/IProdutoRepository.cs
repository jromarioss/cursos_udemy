using ApiCatalago.Model;
using ApiCatalago.Pagination;

namespace ApiCatalago.Repository;

public interface IProdutoRepository : IRepository<Produto> // herda a classe padrão e define o tipo do produto
{
    Task<PagedList<Produto>> GetProdutos(ProdutosParameters produtosParameters);
    Task<IEnumerable<Produto>> GetProdutosPeloPreco();
}
