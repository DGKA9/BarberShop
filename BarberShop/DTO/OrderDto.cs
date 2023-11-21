namespace BarberShop.DTO
{
    public class OrderDto
    {
        public int orderID { get; set; }
        public DateTime orderDate { get; set; }
        public string? orderStatus { get; set; }
        public int customerID { get; set; }
        public int payID { get; set; }
    }
}
