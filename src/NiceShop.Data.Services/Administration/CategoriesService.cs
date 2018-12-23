using System;
using System.Linq;
using System.Threading.Tasks;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;

namespace NiceShop.Data.Services.Administration
{
    public class CategoriesService : ICategoriesService
    {
        private readonly NiceShopDbContext db;

        public CategoriesService(NiceShopDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Category> GetAll()
        {
            // TODO: Use automapper
            var result = this.db.Categories;

            return result;
        }

        // TODO: May  be use model
        public async Task CreateAsync(string name)
        {
            var category = new Category
            {
                Name = name
            };

            // TODO: Proper handling
            try
            {
                await this.db.Categories.AddAsync(category);
                await this.db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}