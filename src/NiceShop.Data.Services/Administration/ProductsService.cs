using System.Linq;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories;

namespace NiceShop.Data.Services.Administration
{
    public class ProductsService : EfRepository<Product>
    {
        public ProductsService(NiceShopDbContext db) 
            : base(db)
        {
        }

        public bool IsNameValid(string name)
        {
            var result = !this.Db.Products.Any(x => x.Name == name);
            return result;
        }

        public bool IsCodeValid(string code)
        {
            if (code == null)
            {
                return true;
            }

            var result = !this.Db.Products.Any(x => x.Code == code);
            return result;
        }
    }
}