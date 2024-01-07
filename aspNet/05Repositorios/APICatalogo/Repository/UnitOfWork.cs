using APICatalogo.Context;

namespace APICatalogo.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProdutoRepository _produtoRepo;
        private CategoriaRepository _categoriaRepo;
        public AppDbContext _context;
        public UnitOfWork(AppDbContext contexto)//injeção do contexto
        {
            _context = contexto;
        }

        public IProdutoRepository ProdutoRepository //implementa as propriedades
        {
            get
            {
                return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context);
            }
        }

        public ICategoriaRepository CategoriaRepository  //implementa as propriedades
        {
            get
            {
                return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context);
            }
        }

        public void Commit() //salva
        {
            _context.SaveChanges();
        }

        public void Dispose() //liberar recursos
        {
            _context.Dispose();
        }

    }
}
