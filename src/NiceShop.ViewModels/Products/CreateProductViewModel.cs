namespace NiceShop.ViewModels.Products
{
    public class CreateProductViewModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryId { get; set; }

        public string ShopId { get; set; }

        public string ImageUrl { get; set; }

        public decimal BoughtFor { get; set; }

        public decimal Price { get; set; }
    }
}