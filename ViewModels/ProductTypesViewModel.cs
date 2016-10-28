using System.Collections.Generic;
using Bangazon.Models;
using Bangazon.Data;

namespace Bangazon.ViewModels
{
  public class ProductTypesViewModel : BaseViewModel
  {
    public IEnumerable<ProductType> ProductTypes { get; set; }
    
    public ProductTypesViewModel(BangazonContext ctx) : base(ctx) { }
  }
}