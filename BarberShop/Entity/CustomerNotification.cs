using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Entity
{
    public class CustomerNotification
    {
        [Key]
        public int cNotificationID { get; set; }


        #region QH

        // ManyOne 
        // Customer
        [ForeignKey("customerID")]
        public Customer Customer { get; set; } = null!;
        // Noti
        [ForeignKey("notiID")]
        public Notification Notification { get; set; } = null!;
        #endregion
    }
}
