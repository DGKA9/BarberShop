using System.ComponentModel.DataAnnotations;

namespace BarberShop.Entity
{
    public class BookingService
    {
        [Key]
        public int bookingServiceID { get; set; }


        #region QH

        // ManytoOne
            // Booking
            public int bookingID { get; set; }
            public Booking booking { get; set; } = null!;
            // Service
            public int serviceID { get; set; }
            public Services Service { get; set; } = null!;
        #endregion
    }
}
