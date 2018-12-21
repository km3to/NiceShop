using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data.Models;

namespace NiceShop.Data.Services
{
    public abstract class BaseService<TEntity>
        where TEntity : BaseModel
    {
        private readonly DbSet<TEntity> dbSet;

        protected NiceShopDbContext Db { get; }

        protected BaseService(NiceShopDbContext db)
        {
            this.Db = db;
            this.dbSet = this.Db.Set<TEntity>();
        }

        public TEntity GetById(string id)
        {
            return this.dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.dbSet;
        }

        public async Task AddAsync(TEntity entity)
        {
            this.dbSet.Add(entity);
            await this.Db.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
            await this.Db.SaveChangesAsync();
        }

        public async Task Edit(TEntity entity)
        {
            this.Db.Entry(entity).State = EntityState.Modified;
            await this.Db.SaveChangesAsync();
        }
    }
}