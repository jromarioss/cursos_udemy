using ApiCatalago.Model;

namespace ApiCatalago.Repository;

public interface IProdutoRepository : IRepository<Produto> // herda a classe padrão e define o tipo do produto
{
    IEnumerable<Produto> GetProdutosPeloPreco();
}
