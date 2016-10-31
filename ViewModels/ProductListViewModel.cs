using System.Collections.Generic;
using Bangazon.Models;
using Bangazon.Data;

/* Authors: Liz Sanger, Elliott Williams, David Yunker, Jammy Laird, Fletcher Watson*/

namespace Bangazon.ViewModels
{

  //Create ProductListViewModel that inherits from BaseViewModel
  public class ProductListViewModel : BaseViewModel
  {
    public IEnumerable<Product> Products { get; set; }

    //Create a custom constructor that accepts BangazonContext as an argument and passes that context (session with db) up to the methods on BaseViewModel
    public ProductListViewModel(BangazonContext ctx) : base(ctx) { }
  }
}

