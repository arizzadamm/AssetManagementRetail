using System.ComponentModel.DataAnnotations;

namespace AssetManagementRetail.Models
{
    public class OrderDetails
    {
        [Key]
        public Guid OrderDetailOid { get; set; }
        public Guid OrderOid { get; set; }
        public Guid ProductOid { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
    }
}
