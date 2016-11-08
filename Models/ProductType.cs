using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
Author: Fletcher Watson
*/

namespace Bangazon.Models
{
    //The ProductType class represents the ProductType table in the BangazonContext db
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }

        [NotMappedAttribute]
        public int Quantity {get;set;}

        [Required]
        [StringLength(50)]
        public string Label { get; set; }
        public ICollection<Product> Products;
    }
}