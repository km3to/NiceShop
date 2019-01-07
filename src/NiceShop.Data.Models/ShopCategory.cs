namespace NiceShop.Data.Models
{
    public class ShopCategory : BaseModel
    {
        public string ShopId { get; set; }

        public virtual Shop Shop { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}