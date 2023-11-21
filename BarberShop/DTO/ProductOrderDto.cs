using BarberShop.Entity;

namespace BarberShop.DTO
{
    public class ProductOrderDto
    {
        public int proOrderID { get; set; }
        public string? proOrderQuantity { get; set; }
        public int orderID { get; set; }
        public int proID { get; set; }
    }
}
