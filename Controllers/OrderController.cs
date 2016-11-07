using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bangazon.Data;
using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using Bangazon.ViewModels;

//Author: David Yunker

namespace Bangazon.Controllers
{

    //Defines the OrderController controller class, which inherits from base class Controller
    public class OrderController : Controller

    {

        //Set a private property on OrderController that stores the current session with db
        private BangazonContext context;

        //Method: Purpose is make existing session with db (BangazonContext) available to other methods throughout the controller via this custom constructor, which accepts existing session as argument
        public OrderController(BangazonContext ctx)
        {
            context = ctx;
        }

        //Method: Purpose is to return a view that tells the customer his/her order has been processed
        public IActionResult Confirm()
        {
            BaseViewModel model = new BaseViewModel(context);

            ViewData["Message"] = @"Order Processed! 
        Thank you for shopping at Bangazon!";

            //  something that fills out Date Completed On Order .... 

            return View(model);
        }

        // Author: Elliott Williams
        // Method: Purpose is to route the user to cart associated with the active customer
    


 [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var customer = ActiveCustomer.instance.Customer;

            var activeOrder = await context.Order.Where(o => o.DateCompleted == null && o.CustomerId==customer.CustomerId).SingleOrDefaultAsync();
            Console.WriteLine(activeOrder);

            OrderViewModel model = new OrderViewModel(context);

            if (activeOrder == null)
            {
               var product = new Product(){Description="You have no products in your cart!", Title=""};
                model.Products = new List<Product>();
                model.Products.Add(product);
                return View(model);
            }

            List<LineItem> LineItemsOnActiveOrder = context.LineItem.Where(li => li.OrderId == activeOrder.OrderId).ToList();
            
            List<Product> ListOfProducts = new List<Product>();

            decimal CartTotal = 0;

            for(var i = 0; i < LineItemsOnActiveOrder.Count(); i++)
            {
                ListOfProducts.Add(context.Product.Where(p => p.ProductId == LineItemsOnActiveOrder[i].ProductId).SingleOrDefault());
                CartTotal += context.Product.Where(p => p.ProductId == LineItemsOnActiveOrder[i].ProductId).SingleOrDefault().Price;
            }

            model.CartTotal = CartTotal;
            model.Products = ListOfProducts;

            return View(model);
            
        }
    }
}