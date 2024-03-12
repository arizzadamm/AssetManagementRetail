using System.ComponentModel.DataAnnotations;

namespace AssetManagementRetail.Models
{
    public class Customers
    {
        [Key]
        public Guid CustomersOid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int City { get; set; }
        public DateTime Birthday { get; set;}

    }
}
