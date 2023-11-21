namespace BarberShop.DTO
{
    public class BookingDto
    {
        public int bookingID { get; set; }
        public TimeSpan startTime { get; set; } = DateTime.Now - DateTime.Today;
        public int customerID { get; set; }
        public int payID { get; set; }
    }
}
