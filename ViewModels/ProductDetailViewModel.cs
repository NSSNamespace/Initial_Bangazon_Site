
using Bangazon.Models;
using Bangazon.Data;

/*
Author: Liz Sanger
Purpose: Aggregate data for display on ProductDetailView, including customerId dropdown menu inherited from BaseViewModel class. 
Methods: ProductDetail class custom constructor, which accepts BangazonContext as an argument


*/

namespace Bangazon.ViewModels
{
    //create ProductDetailViewModel class, which inherits from BaseViewModel, and therefore contains the dropdown menu with customer name selected
  public class ProductDetail : BaseViewModel
  {
      //create property of type Product; this will be the product whose details are displayed
    public Product Product { get; set; }
    //create custom constructor that accepts current BangazonContext as argument and passes it up inheritance chain to BaseViewModel
    public ProductDetail(BangazonContext ctx) : base(ctx) { }
    }
}