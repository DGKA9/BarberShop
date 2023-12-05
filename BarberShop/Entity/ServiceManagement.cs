using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Entity
{
    public class ServiceManagement
    {
        [Key]
        public int serManagerID {get; set;}

        #region QH

        // MO 
            // Store
        public int storeID { get; set;}
        public Store Store { get; set; } = null!;
        // Service
        [ForeignKey("serID")]
        public Services Service { get; set; } = null!;
        #endregion
    }
}
