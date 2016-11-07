using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bangazon.Data;
using Bangazon.Models;
using Bangazon.ViewModels;
using Microsoft.AspNetCore.Routing;
using Bangazon.Data;

namespace Bangazon.Controllers
{
    
    
    // Author: Jammy Laird 
 
    

// Defines the PaymentController controller class, which inherits from base class Controller
    public class PaymentController : Controller     
    {
        private BangazonContext  context;
        //Set a private property on OrderController that stores the current session with db
        public PaymentController(BangazonContext cxt)
        {
            context = cxt;
        }
         //Method: Purpose is to return a view that allows the customer to create a payment method
        public IActionResult Create()
        {
            var model = new PaymentTypeViewModel(context);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (PaymentTypeViewModel paymentType)
        {
            // New payment Type is Linked to the linked to 
            paymentType.NewPaymentType.CustomerId = ActiveCustomer.instance.Customer.CustomerId;
            if (ModelState.IsValid)
            {
                context.Add(paymentType.NewPaymentType);
                await context.SaveChangesAsync();
                return RedirectToAction ("Cart", new RouteValueDictionary(new {controller = "Order", action = "Cart", Id = paymentType.NewPaymentType.PaymentTypeId}));
            }
            var model = new PaymentTypeViewModel(context);
            model.NewPaymentType = paymentType.NewPaymentType;

            return View(model);
        }

    }
    
}