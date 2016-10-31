using System.Collections.Generic;
using Bangazon.Models;
using Bangazon.Data;

/*
Author: Fletcher Watson
*/


namespace Bangazon.ViewModels
{
  //Create ProductTypesViewModel that inherits from BaseViewModel 
  public class ProductTypesViewModel : BaseViewModel
  {
    public IEnumerable<ProductType> ProductTypes { get; set; }
    
    //Create a custom constructor that accepts BangazonContext as an argument and passes that context (session with db) up to the methods on BaseViewModel
    public ProductTypesViewModel(BangazonContext ctx) : base(ctx) { }
  }
}