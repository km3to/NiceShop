using System;
using System.Linq;
using System.Threading.Tasks;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;

namespace NiceShop.Data.Services.Administration
{
    public class ProductsService : IProductsService
    {
        private readonly NiceShopDbContext db;

        public ProductsService(NiceShopDbContext db)
        {
            this.db = db;
        }

        public async Task<string> CreateAsync(Product product)
        {
            // TODO: Proper handling
            try
            {
                await this.db.Products.AddAsync(product);
                await this.db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return product.Id;
        }

        public IQueryable<Product> GetById(string id)
        {
            var product = this.db.Products
                .Where(x => x.Id == id);

            return product;
        }

        public bool IsNameValid(string name)
        {
            var result = !this.db.Products.Any(x => x.Name == name);
            return result;
        }

        public bool IsCodeValid(string code)
        {
            if (code == null)
            {
                return true;
            }

            var result = !this.db.Products.Any(x => x.Code == code);
            return result;
        }
    }
}