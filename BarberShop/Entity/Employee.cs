using System.ComponentModel.DataAnnotations;

namespace BarberShop.Entity
{
    public class Employee
    {
        [Key]
        public int employeID {get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? picture { get; set; }
        public string? email { get; set; }
        public string? numberphone { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime wordDay { get; set; }



        #region QH

        // OneOne User
        public int userID { get; set; }
        public User user { get; set; } = null!;
        // ManyOne 
        // Store
        public int storeID { get; set; }
        public Store Store { get; set; } = null!;
        // Address
        public int addressID { get; set; }
        public Address Address { get; set; } = null!;
        #endregion
    }
}
