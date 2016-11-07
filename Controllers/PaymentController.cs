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
    /**
    *Class: PaymentController 
    *Purpose: To allow the logged in customer to creat a new payment method 
    *Author: Jammy Laird 
    *Methods:
    */

    public class PaymentController : Controller     
    {
        private BangazonContext  context;

        public PaymentController(BangazonContext cxt)
        {
            context = cxt;
        }

        public IActionResult Create()
        {
            var model = new PaymentTypeView(context);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (PaymentTypeView paymentType)
        {
            paymentType.NewPaymentType.CustomerId = ActiveCustomer.instance.Customer.CustomerId;
            if (ModelState.IsValid)
            {
                context.Add(paymentType.NewPaymentType);
                await context.SaveChangesAsync();
                return RedirectToAction ("Cart", new RouteValueDictionary(new {controller = "Order", action = "Cart", Id = paymentType.NewPaymentType.PaymentTypeId}));
            }
            var model = new PaymentTypeView (context);
            model.NewPaymentType = paymentType.NewPaymentType;

            return View(model);
        }

    }
    
}