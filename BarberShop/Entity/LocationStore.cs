using System.ComponentModel.DataAnnotations;

namespace BarberShop.Entity
{
    public class LocationStore
    {
        [Key]
        public int locationID { get; set; }
        public string? currentAddress { get; set; }
        public string? subDistrict { get; set; }
        public string? district { get; set; }



        #region QH

        // ManyOne
            // City
        public int cityID { get; set; }
        public City city { get; set; } = null!;
            // Store
        public int storeID { get; set; }
        public Store Store { get; set; } = null!;
        #endregion
    }
}
