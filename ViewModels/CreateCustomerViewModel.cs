
using Bangazon.Models;
using Bangazon.Data;

/*
Author: Liz Sanger
Purpose: Aggregate data for display on CreateCustomerViewModel, including customerId dropdown menu inherited from BaseViewModel class. 
*/

namespace Bangazon.ViewModels
{
    //Create CreateCustomerViewModel class, which inherits from BaseViewModel, and therefore contains the dropdown menu with customer name selected
  public class CreateCustomerViewModel : BaseViewModel
  {
    public Customer Customer { get; set; }

    //Create custom constructor that accepts current BangazonContext as argument and passes it up inheritance chain to BaseViewModel
    public CreateCustomerViewModel(BangazonContext ctx) : base(ctx) { }
    }
}