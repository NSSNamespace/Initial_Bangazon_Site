
using Bangazon.Models;
using Bangazon.Data;

/*
Author: Liz Sanger
Purpose: Aggregate data for display on ProductDetailViewModel, including customerId dropdown menu inherited from BaseViewModel class. 
Methods: ProductDetailViewModel class custom constructor, which accepts BangazonContext as an argument
*/

namespace Bangazon.ViewModels
{
    //Create ProductDetailViewModel class, which inherits from BaseViewModel, and therefore contains the dropdown menu with customer name selected
    public class ProductDetailViewModel : BaseViewModel
    {
        public Product Product { get; set; }
        //Create custom constructor that accepts current BangazonContext as argument and passes it up inheritance chain to BaseViewModel
        public ProductDetailViewModel(BangazonContext ctx) : base(ctx) { }
    }
}