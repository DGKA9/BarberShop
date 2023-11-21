using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Entity
{
    public class Order
    {
        [Key]
        public int orderID { get; set; }
        public DateTime orderDate { get; set; }
        public string? orderStatus { get; set; }


        #region QH

        // MO
            // Customer
        public int customerID { get; set; }
        public Customer customer { get; set; } = null!;
        // Payment
        [ForeignKey("payID")]
        public Payment Payment { get; set; } = null!;
        //OM productOrder
        public ICollection<ProductOrder> ProductOrders { get; set; } = new HashSet<ProductOrder>();
        #endregion
    }
}
