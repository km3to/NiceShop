using System;
using System.Linq;
using System.Threading.Tasks;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.ViewModels;
using NiceShop.ViewModels.Categories;

namespace NiceShop.Data.Services.Administration
{
    public class CategoriesService : ICategoriesService
    {
        private readonly NiceShopDbContext db;

        public CategoriesService(NiceShopDbContext db)
        {
            this.db = db;
        }

        public IQueryable<IdAndNameViewModel> GetAll()
        {
            // TODO: Use automapper
            var result = this.db.Categories
                .Select(x => new IdAndNameViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

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