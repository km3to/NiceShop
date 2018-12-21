using System.Threading.Tasks;
using NiceShop.Data.Models;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.ViewModels.Shops;

namespace NiceShop.Data.Services.Administration
{
    public class ShopsService : BaseService<Shop>, IShopsService
    {
        public ShopsService(NiceShopDbContext db) 
            : base(db)
        {
        }

        public async Task CreateAsync(CreateShopViewModel viewModel)
        {
            var shop = new Shop
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                Description = viewModel.Description,
            };

            await this.AddAsync(shop);
        }
    }
}