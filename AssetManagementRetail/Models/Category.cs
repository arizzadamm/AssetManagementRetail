﻿using System.ComponentModel.DataAnnotations;

namespace AssetManagementRetail.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryOid { get; set; }
        public string? Name { get; set; }
    }
}
