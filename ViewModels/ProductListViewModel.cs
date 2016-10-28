using System.Collections.Generic;
using Bangazon.Models;
using Bangazon.Data;

/* Authors: Liz Sanger, Elliott Williams, David Yunker, Jammy Laird, Fletcher Watson*/

namespace Bangazon.ViewModels
{

  //Create ProductList view model that inherits from BaseViewModel
  public class ProductList : BaseViewModel
  {
    //set a property of Type IEnumerable, named products, that accepts items of typeProduct for display on the home view via the Index model on Products controller
    public IEnumerable<Product> Products { get; set; }

    //create a custom constructor that accepts BangazonContext as an argument and passes that context (session with db) up to the methods on BaseViewModel
    public ProductList(BangazonContext ctx) : base(ctx) { }
  }
}

