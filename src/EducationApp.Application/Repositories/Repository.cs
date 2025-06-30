using System;
using EducationApp.Application.Repositories.Interfaces;
using EducationApp.DataAccess.Database;

namespace EducationApp.Application.Repositories;

public abstract class Repository<TEntity>(EduDbContext context) : IRepository<TEntity> where TEntity : class
{
    public void Add(TEntity entity)
        => context.Set<TEntity>().Add(entity);

    public async Task AddAsync(TEntity entity)
        => await context.Set<TEntity>().AddAsync(entity);

    public void Update(TEntity entity)
        => context.Set<TEntity>().Update(entity);

    public IEnumerable<TEntity> GetAll()
        => context.Set<TEntity>().AsQueryable();

    public TEntity GetById(int id)
        => context.Set<TEntity>().Find(id);

    public async Task<TEntity> GetByIdAsync(int id)
        => await context.Set<TEntity>().FindAsync(id);

    public void Delete(TEntity entity)
        => context.Set<TEntity>().Remove(entity);

    public int SaveChanges()
        => context.SaveChanges();

    public async Task<int> SaveChangesAsync()
        => await context.SaveChangesAsync();
}
