using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon.Models;
using Bangazon.ViewModels;
using Bangazon.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

    /*
     Class: CustomerController
     Purpose: Allows users to create an account on the website, as well as select the active user from a dropdown menu in the navbar
     * Author: Liz Sanger
     * Methods and Arguments:
     *   Menu() - creates a new instance of the MenuViewModel class and passes in the current BangazonContext as argument in order to extract existing customers from corresponding db table
     *   Activate() - responds to POST method from Site.js by creating a new instance of the ActiveCustomer class. This method accepts an argument of CustomerId, of type integer, and uses it to traverse the customers table in the db and attach the selected customer as the Customer property on the instance of the ActiveCustomer class. This method returns an object with key/value pair result:true
     *Error() - returns the Error View
     */

namespace Bangazon.Controllers
{
    public class CustomersController : Controller
    {
       
        private BangazonContext context;

        public CustomersController(BangazonContext ctx)
        {
            context = ctx;
        }

        //Create a new instance of the MenuViewModel class and pass it db context, which is then used to return the partial view of the dropdown file
        public ActionResult Menu()
        {
            MenuViewModel model = new MenuViewModel(context);

            return PartialView(model);
        }

           public IActionResult Create()
        {
            CreateCustomerViewModel model = new CreateCustomerViewModel(context);

            return View(model);
        }

    
        [HttpPost]
        public IActionResult Activate([FromBody]int CustomerId)

        {
            //cycle through the existing customers table in the database and select the customerId that matches the argument
            var customer = context.Customer.SingleOrDefault(c => c.CustomerId == CustomerId);

            if (customer == null)
            {
                return NotFound();
            }

            //create a new instance of the ActiveCustomer class and assign the selected customer to the .Customer property on that instance
            ActiveCustomer.instance.Customer = customer;
            string json = "{'result': 'true'}";
            return new ContentResult { Content = json, ContentType = "application/json" };
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}