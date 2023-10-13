using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Realtor.Data.Contexts;
using Realtor.Data.Contracts;
using Realtor.Domain.Commons;

namespace Realtor.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly RealtorDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(RealtorDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async ValueTask CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        entity.CreatedAt = DateTime.UtcNow;
    }

    public void Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        entity.IsDeleted = true;
    }
    
    public void Destroy(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
    {
        IQueryable<TEntity> entities = _dbSet.Where(expression).AsQueryable();

        if(includes!=null)
            foreach (var include in includes)
                entities = entities.Include(include);
            
        
        return await entities.Where(entity => !entity.IsDeleted).FirstOrDefaultAsync();
    }
    
    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null, bool isTracking = true)
    {
        IQueryable<TEntity> entities = expression == null 
            ? _dbSet.AsQueryable() 
            : _dbSet.Where(expression).AsQueryable();

        entities = isTracking ? entities.AsNoTracking() : entities;

        if(includes!=null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return entities.Where(entity=> !entity.IsDeleted);
    }
}