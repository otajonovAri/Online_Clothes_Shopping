using System.Linq.Expressions;

namespace EducationApp.Application.Repositories.Interfaces;

public interface IRepository<TEntity>
{
    void Add(TEntity entity);

    Task AddAsync(TEntity entity);

    void Update(TEntity entity);

    IEnumerable<TEntity> GetAll();

    TEntity GetById(int id);

    Task<TEntity> GetByIdAsync(int id);

    void Delete(TEntity entity);

    int SaveChanges();

    Task<int> SaveChangesAsync();

    // Query search : Gender , Name , Region , email , 

    IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> predicate);
}
