using System.ComponentModel.DataAnnotations;

namespace BarberShop.Entity
{
    public class Warehouse
    {
        [Key]
        public int warehouseID { get; set; }
        public string? warehouseName { get; set; }
        public float totalAsset { get; set; }
        public int capacity { get; set; }

        #region QH

        // OO address
        public int addressID { get; set; }
        public Address Address { get; set; } = null!;
        // MO srore
        public int storeID { get; set; }
        public Store Store { get; set; } = null!;
        // OM product
        public ICollection<Product> products { get; set; } = new HashSet<Product>();
        #endregion 
    }
}
