using ApiCatalago.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiCatalago.Repository;

public class Repository<T> : IRepository<T> where T : class// classe genérica, o só poder ser classe
{
    protected AppDbContext _context;

    public Repository(AppDbContext context) // injeta o contexto
    {
        _context = context;
    }

    public IQueryable<T> Get() // lista de entidade
    {
        // o set do contexto retorna uma instância do dbset para acesso a entidades de determinado tipo no contexto
        return _context.Set<T>().AsNoTracking();
    }

    public T GetById(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().SingleOrDefault(predicate);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        // define o estado como modificado, e informe ao contexto que ele foi modificado
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}
