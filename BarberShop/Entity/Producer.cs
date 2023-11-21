using System.ComponentModel.DataAnnotations;

namespace BarberShop.Entity
{
    public class Producer
    {
        [Key]
        public int producerID { get; set; }
        public string? producerName { get; set; }
        public string? numberphone { get; set; }


        #region QH

        // OO
        // address
        public int addressID { get; set; }
        public Address Address { get; set; } = null!;
        // OM
        // product
        public ICollection<Product> Product { get; } = new HashSet<Product>();
        #endregion
    }
}
