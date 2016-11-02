using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/*
Author: Liz Sanger 
*/

namespace Bangazon.Models
{
    //The ProductTypeSubCategory class represents the ProductTypeSubCategory table in the BangazonContext db
    public class ProductTypeSubCategory
    {
        [Key]
        public int ProductTypeSubCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]

        public int ProductTypeId { get; set; }
        public ProductType ProductType {get;set;}
    }
}