namespace NiceShop.Data.Models
{
    public class Item : BaseModel
    {
        public decimal BoughtFor { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}