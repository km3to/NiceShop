using System.Linq;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data.Models;

namespace NiceShop.Data.Services
{
    public class BaseService<TEntity>
        where TEntity : BaseModel
    {
        private readonly DbSet<TEntity> dbSet;

        protected NiceShopDbContext Db { get; }

        public BaseService(NiceShopDbContext db)
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

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
            this.Db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
            this.Db.SaveChanges();
        }

        public void Edit(TEntity entity)
        {
            this.Db.Entry(entity).State = EntityState.Modified;
            this.Db.SaveChanges();
        }
    }
}