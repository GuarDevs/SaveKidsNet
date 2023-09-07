using Microsoft.EntityFrameworkCore;
using SaveKids.DAL.DbContexts;
using SaveKids.DAL.IRepositories;
using SaveKids.Domain.Commons;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace SaveKids.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext dbContext;
    private readonly DbSet<TEntity> dbSet;
    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        await dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        this.dbContext.Update(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        entity.IsDeleted = true;
    }

    public void Destroy(TEntity entity)
    {
        this.dbSet.Remove(entity);
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
    {
        IQueryable<TEntity> query = dbSet.Where(expression).AsQueryable();

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        var entity = await query.Where(e => !e.IsDeleted).FirstOrDefaultAsync(expression);
        return entity;
    }

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, bool isNoTracked = true, string[] includes = null)
    {
        IQueryable<TEntity> query = expression is null ? dbSet.AsQueryable() : dbSet.Where(expression).AsQueryable();

        query = isNoTracked ? query.AsNoTracking() : query;

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return query.Where(e => !e.IsDeleted);
    }

    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
