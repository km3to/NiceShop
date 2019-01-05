using System;
using System.Linq;
using System.Threading.Tasks;
using NiceShop.Data.Models;

namespace NiceShop.Data.Repositories.Contracts
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : BaseModel
    {
        Task<string> CreateAsync(TEntity entity);

        IQueryable<TEntity> ReadAll();

        IQueryable<TEntity> ReadById(string id);

        Task UpdateAsync(TEntity entity);

        Task UpdateAsync(string id);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(string id);
    }
}