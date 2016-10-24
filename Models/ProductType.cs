using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
  public class ProductType
  {
    [Key]
    public int ProductTypeId { get; set; }

    [Required]
    [StringLength(50)]
    public string Label { get; set; }
    public ICollection<Product> Products;
  }
}