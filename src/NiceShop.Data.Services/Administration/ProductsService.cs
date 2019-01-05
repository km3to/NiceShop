using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NiceShop.AutoMapping;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Models.Administration.InputModels;
using NiceShop.Web.Models.Administration.ViewModels;

namespace NiceShop.Data.Services.Administration
{
    // TODO: !!! Use IConfiguration to setup destination path for files upload
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> productsRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper mapper;

        public ProductsService(
            IRepository<Product> productsRepository,
            IHostingEnvironment hostingEnvironment, 
            IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.mapper = mapper;
        }

        public async Task<string> CreateAsync(ProductCreateInputModel inputModel)
        {
            // TODO: !!! Save product images paths to db
            var product = this.mapper.Map<Product>(inputModel);
            var id = await this.productsRepository.CreateAsync(product);

            return id;
        }

        public ProductDetailsViewModel DetailsFor(string id)
        {
            var viewModel = this.productsRepository
                .ReadById(id)
                .To<ProductDetailsViewModel>()
                .FirstOrDefault();

            return viewModel;
        }

        public async Task SaveImages(string productId, IEnumerable<IFormFile> images)
        {
            foreach (var image in images)
            {
                if (image.FileName.EndsWith(".jpeg") || image.FileName.EndsWith(".jpg") || image.FileName.EndsWith(".png"))
                {
                    var destinationPath =
                        $"{this.hostingEnvironment.WebRootPath}\\users-files\\{productId}";

                    // TODO: Some real exception handling
                    try
                    {
                        if (!Directory.Exists(destinationPath))
                        {
                            var _ = Directory.CreateDirectory(destinationPath);
                        }

                        var destinationFileName = $"{destinationPath}\\{image.FileName}";
                        using (var fs = new FileStream(destinationFileName, FileMode.Create))
                        {
                            await image.CopyToAsync(fs);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}