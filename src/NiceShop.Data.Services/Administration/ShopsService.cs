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
            // TODO: Use automapper
            var shop = new Shop
            {
                Name = model.Name,
                Address = model.Address,
                Description = model.Description,
            };

            // TODO: Proper handling
            try
            {
                await this.db.Shops.AddAsync(shop);
                await this.db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return shop.Id;
        }

        public Shop GetById(string id)
        {
            // TODO: Use automapper
            var shop = this.db.Shops
                .FirstOrDefault(x => x.Id == id);

            return shop;
        }

        public IQueryable<Shop> GetAll()
        {
            var result = this.db.Shops;

            return result;
        }

        // TODO: Use model
        public async Task CreateAsync(string name)
        {
            var shop = new Shop
            {
                Name = name
            };

            // TODO: Proper handling
            try
            {
                await this.db.Shops.AddAsync(shop);
                await this.db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}