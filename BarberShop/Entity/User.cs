using System.ComponentModel.DataAnnotations;

namespace BarberShop.Entity
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }


        #region QH

        // MO role
        public int roleID { get; set; }
        public Role Role { get; set; } = null!;
        // OO
        // customer
        public Customer? Customer { get; set; }
        // employee
        public Employee? Employee { get; set; }

        #endregion
    }
}
