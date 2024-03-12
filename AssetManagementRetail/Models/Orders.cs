using System.ComponentModel.DataAnnotations;

namespace AssetManagementRetail.Models
{
    public class Orders
    {
        [Key]
        public Guid OrderOid { get; set; } 
        public Guid CustomerOid { get; set; }    
        public DateTime OrderDate { get; set; } 
    }
}
