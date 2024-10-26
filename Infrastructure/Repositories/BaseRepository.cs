
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _appDbContext;
        public BaseRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public virtual async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _appDbContext.Set<T>().Add(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
        public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _appDbContext.Set<T>().Update(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await _appDbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }
        public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Set<T>().ToListAsync(cancellationToken);
        }
        public virtual async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
