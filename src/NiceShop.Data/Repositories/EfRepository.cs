using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;

namespace NiceShop.Data.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseModel
    {
        public EfRepository(NiceShopDbContext db)
        {
            this.Db = db ?? throw new ArgumentNullException(nameof(db));
            this.DbSet = this.Db.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected NiceShopDbContext Db { get; set; }

        public virtual async Task<string> CreateAsync(TEntity entity)
        {
            this.DbSet.Add(entity);

            await this.Db.SaveChangesAsync();

            return entity.Id;
        }

        public virtual IQueryable<TEntity> ReadAll()
        {
            return this.DbSet;
        }

        public virtual IQueryable<TEntity> ReadById(string id)
        {
            return this.DbSet.Where(x => x.Id == id);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var entry = this.Db.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;

            await this.Db.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(string id)
        {
            var entity = this.ReadById(id).FirstOrDefault();
            var entry = this.Db.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;

            await this.Db.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            this.DbSet.Remove(entity);
            await this.Db.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(string id)
        {
            var entity = this.ReadById(id).FirstOrDefault();
            this.DbSet.Remove(entity);
            await this.Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.Db.Dispose();
        }
    }
}