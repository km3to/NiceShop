using System;
using System.Linq;
using System.Threading.Tasks;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;

namespace NiceShop.Data.Services.Administration
{
    public class ShopsService : IShopsService
    {
        private readonly NiceShopDbContext db;

        public ShopsService(NiceShopDbContext db)
        {
            this.db = db;
        }

        public async Task<string> CreateAsync(Shop model)
        {
            // TODO: Proper handling
            try
            {
                await this.db.Shops.AddAsync(model);
                await this.db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return model.Id;
        }

        public IQueryable<Shop> GetById(string id)
        {
            var result = this.db.Shops
                .Where(x => x.Id == id);

            return result;
        }

        public IQueryable<Shop> GetAll()
        {
            var result = this.db.Shops;

            return result;
        }
    }
}