using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Interfaces.Repository;
using WebShop.Infraestructure.Data;

namespace WebShop.Infraestructure.Repository
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShopDbContext _dbContext;
        public Repository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<List<T>> AddRange(List<T> Listentity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddRangeAsync(Listentity);
            await _dbContext.SaveChangesAsync();
            return Listentity;
        }
        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }
        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);

        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>()  ;
        }
        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }
        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChangesAsync();
        }
        public async Task UpdateRange(List<T> Listentity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().UpdateRange(Listentity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
