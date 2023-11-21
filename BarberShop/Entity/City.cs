using System.ComponentModel.DataAnnotations;

namespace BarberShop.Entity
{
    public class City
    {
        [Key]
        public int cityID { get; set; }
        public string? cityName { get; set; }


        #region QH

        // ManyOne Country
        public int countryID { get; set; }
        public Country? country { get; set; } = null!;
        // OneMany
        // Address
        public ICollection<Address>? addresses { get; } = new List<Address>();
        // LocationStore
        public ICollection<LocationStore>? cities { get;}= new List<LocationStore>();
        #endregion
    }
}
