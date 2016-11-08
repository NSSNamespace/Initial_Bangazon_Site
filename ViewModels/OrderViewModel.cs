
using System.Collections.Generic;
using Bangazon.Models;
using Bangazon.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bangazon.ViewModels
{
     public class OrderViewModel : BaseViewModel
  {
    public List<SelectListItem> PaymentTypeId { get; set; }
    public List<Product> Products { get; set; }
    public decimal CartTotal {get; set;}
    private BangazonContext context;
    private ActiveCustomer singleton = ActiveCustomer.instance;
 
    
    //Method Name: OrderViewModel
    //Purpose of the Method: Upon construction this should take the context and send a list of select items of the type PaymentType to the View. They should be the paymentTypes of the active customer.
    //Arguments in Method: BangazonWebContext
    public OrderViewModel(BangazonContext ctx) : base (ctx)
    {
        var customer = ActiveCustomer.instance.Customer;
         var context = ctx;
        this.PaymentTypeId = context.PaymentType
            .Where(pt => pt.CustomerId == customer.CustomerId)
            .AsEnumerable()
            .Select(li => new SelectListItem { 
                Text = li.Description,
                Value = li.PaymentTypeId.ToString()
            }).ToList();
        
        this.PaymentTypeId.Insert(0, new SelectListItem {
          Text="Choose Payment Type",
          Value = ""
        });
    }
  }
}