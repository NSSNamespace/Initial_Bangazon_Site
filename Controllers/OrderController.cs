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
            ViewData["Message"] = @"Order Processed! 
        Thank you for shopping at Bangazon!";

            //  something that fills out Date Completed On Order .... 

            return View();
        }
        public async Task<IActionResult> Cart()
        {
            // Create new instance of the view model
            OrderViewModel model = new OrderViewModel(context);

            // Set the properties of the view model
            return View(model);
        }

    }
}