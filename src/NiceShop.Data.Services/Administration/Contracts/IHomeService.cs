﻿using NiceShop.Web.Models.Administration.Home;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration.Contracts
{
    public interface IHomeService
    {
        HomeIndexViewModel GetIndexModel();

        HomeManageViewModel GetManageModel(string id);
    }
}