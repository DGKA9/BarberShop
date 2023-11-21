using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Entity
{
    public class Booking
    {
        [Key]
        public int bookingID { get; set; }
        public TimeSpan startTime { get; set; } = DateTime.Now - DateTime.Today;


        #region QH

        // ManytoOne
        // Customer
        [ForeignKey("customerID")]
        public Customer customer { get; set; } = null!;
        // Payment
        [ForeignKey("payID")]
        public Payment payment { get; set; } = null!;
        // OnetoMany BookingService
        public ICollection<BookingService>? bookingServices { get; } = new HashSet<BookingService>();
        // OnetoOne BookingSateDescription
        public BookingStateDescription? BookingSateDescription { get; set; }
        #endregion

    }

}
