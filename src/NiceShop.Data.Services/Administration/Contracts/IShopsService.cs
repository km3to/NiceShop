﻿using System.Threading.Tasks;
using NiceShop.ViewModels.Shops;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IShopsService
    {
        CreateShopViewModel GetById(string id);

        Task<string> CreateAsync(CreateShopViewModel viewModel);
    }
}