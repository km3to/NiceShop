using System;
using System.Linq;
using System.Threading.Tasks;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.ViewModels.Products;

namespace NiceShop.Data.Services.Administration
{
    public class ProductsService : IProductsService
    {
        private readonly NiceShopDbContext db;

        public ProductsService(NiceShopDbContext db)
        {
            this.db = db;
        }

        public async Task<string> CreateAsync(CreateProductViewModel viewModel)
        {
            // TODO: Use automapper
            var product = new Product
            {
                
            };

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

        public CreateProductViewModel GetById(string id)
        {
            // TODO: Use automapper
            var product = this.db.Products
                .Where(x => x.Id == id)
                .Select(x => new CreateProductViewModel()
                {
                })
                .FirstOrDefault();

            return product;
        }
    }
}