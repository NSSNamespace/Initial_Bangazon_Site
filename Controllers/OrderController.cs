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

        
        private BangazonContext context;

        //Method: Purpose is make existing session with db (BangazonContext) available to other methods throughout the controller via this custom constructor, which accepts existing session as argument
        public OrderController(BangazonContext ctx)
        {
            context = ctx;
        }

        //Method: Purpose is to return a view that tells the customer his/her order has been processed
        public IActionResult Confirm()
        {
            ViewData["Message"] = @"Order Processed! 
        Thank you for shopping at Bangazon!";

            //  something that fills out Date Completed On Order .... 

            return View();
        }

        // Author: Elliott Williams
        // Method: Purpose is to route the user to cart associated with the active customer
        [HttpGet]
        public IActionResult Cart()
        {
            // Create new instance of the view model
            OrderViewModel model = new OrderViewModel(context);
            // variable to hold the instance of the active customer
            var customer = ActiveCustomer.instance.Customer;

            // Set the properties of the view model
            return View(model);
        }


    }
}

//get current user
//get order associated with user
//show products (line items?) in order