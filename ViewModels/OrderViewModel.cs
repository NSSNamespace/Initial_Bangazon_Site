
using System.Collections.Generic;
using Bangazon.Models;
using Bangazon.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bangazon.ViewModels
{
     public class OrderViewModel : BaseViewModel
  {
    public List<SelectListItem> ListOfPaymentTypes { get; set; }
    public List<Product> Products { get; set; }
    public decimal CartTotal {get; set;}
    // private BangazonContext context;
    // private ActiveCustomer singleton = ActiveCustomer.Instance;
 
    
    //Method Name: OrderViewModel
    //Purpose of the Method: Upon construction this should take the context and send a list of select items of the type PaymentType to the View. They should be the paymentTypes of the active customer.
    //Arguments in Method: BangazonWebContext
    public OrderViewModel(BangazonContext ctx) : base (ctx)
    {
        // context = ctx;
        // this.ListOfPaymentTypes = context.PaymentType
        //     .Where(pt => pt.CustomerId == singleton.Customer.CustomerId)
        //     .AsEnumerable()
        //     .Select(pt => new SelectListItem { 
        //         Text = $"{pt.FirstName} {pt.LastName} {pt.Processor} {pt.ExpirationDate}",
        //         Value = pt.PaymentTypeId.ToString()
        //     }).ToList();
        
        // this.ListOfPaymentTypes.Insert(0, new SelectListItem {
        //   Text="Choose Payment Type"
        // });
    }
  }
}