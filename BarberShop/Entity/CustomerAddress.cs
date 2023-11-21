using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Entity
{
    public class CustomerAddress
    {
        [Key]
        public int cusAddressId { get; set; }

        [ForeignKey("customerID")]
        public Customer Customer { get; set; } = null!;
        // product
        [ForeignKey("addressID")]
        public Address Address { get; set; } = null!;
    }
}
