using System;
using System.Linq;
using System.Threading.Tasks;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.ViewModels;
using NiceShop.ViewModels.Categories;
using NiceShop.ViewModels.Shops;

namespace NiceShop.Data.Services.Administration
{
    public class ShopsService : IShopsService
    {
        private readonly NiceShopDbContext db;

        public ShopsService(NiceShopDbContext db)
        {
            this.db = db;
        }

        public async Task<string> CreateAsync(CreateShopViewModel viewModel)
        {
            // TODO: Use automapper
            var shop = new Shop
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                Description = viewModel.Description,
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

        public CreateShopViewModel GetById(string id)
        {
            // TODO: Use automapper
            var shop = this.db.Shops
                .Where(x => x.Id == id)
                .Select(x => new CreateShopViewModel
                {
                    Name = x.Name,
                    Address = x.Address,
                    Description = x.Description,
                })
                .FirstOrDefault();

            return shop;
        }

        public IQueryable<IdAndNameViewModel> GetAll()
        {
            var result = this.db.Shops
                .Select(x => new IdAndNameViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

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