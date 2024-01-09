using System.Linq.Expressions;

namespace ApiCatalago.Repository;

public interface IRepository<T> // o tipo T é qualquer tipo
{
    IQueryable<T> Get(); // método para consultar
    T GetById(Expression<Func<T, bool>> predicate); // consultar por id
    void Add (T entity); // adicionar
    void Update (T entity);
    void Delete (T entity);
}
