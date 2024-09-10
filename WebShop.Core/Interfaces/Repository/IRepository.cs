using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task<List<T>> AddRange(List<T> Listentity, CancellationToken cancellationToken = default);
        Task UpdateRange(List<T> Listentity, CancellationToken cancellationToken = default);
        T GetById(int id);
        IQueryable<T> ListAsync();
    }
}
