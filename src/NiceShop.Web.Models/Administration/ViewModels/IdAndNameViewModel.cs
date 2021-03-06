﻿using NiceShop.AutoMapping;
using NiceShop.Data.Models;

namespace NiceShop.Web.Models.Administration.ViewModels
{
    public class IdAndNameViewModel : IMapFrom<Shop>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}