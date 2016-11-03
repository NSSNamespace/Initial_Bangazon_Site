using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BangazonWeb.Data;
using Bangazon.Models;
using Bangazon.ViewModels;
using Microsoft.AspNetCore.Routing;




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

        public PaymentController(BangazonContext)
        {
            context = ctx;
        }

        public IActionResult Create()
        {
            var model = new PaymentTypeView(context);
            return View(model);
        }
        [HttpPost]
        [validateAntiForgeyToken]
        public async Task<IActionresult> Create (PaymentTypeView paymentType)
        {
            paymentType.NewPaymentType.CustomerId = ActiveCustomer.Instance.customer.c=CustomerId;
            if (ModelState )
        }

    }
    
}