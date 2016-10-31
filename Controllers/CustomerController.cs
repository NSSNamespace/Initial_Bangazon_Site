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
     * Create() - creates a new instance of the CreateCustomerViewModel and returns the Customers/Create view
     * Menu() - creates a new instance of the MenuViewModel class and passes in the current BangazonContext as argument in order to extract existing customers from corresponding db table
     * Activate() - responds to POST method from Site.js by creating a new instance of the ActiveCustomer class. This method accepts an argument of CustomerId, of type integer, and uses it to traverse the customers table in the db and attach the selected customer as the Customer property on the instance of the ActiveCustomer class. This method returns an object with key/value pair result:true
     *Create(Customer customer) - Overloaded on Create() method, this is a POST request that sends a new instance of the Customer class to the database when a new user registers with the site
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

        //Create a new instance of the CreateCustomerViewModel and return the Customer/Create view
           public IActionResult Create()
        {
            CreateCustomerViewModel model = new CreateCustomerViewModel(context);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Overload the Create() method with an async Task that sends a new customer
        public async Task<IActionResult>Create(Customer customer)
        {     
                context.Add(customer);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Products");
        }

    
        [HttpPost]
        public IActionResult Activate([FromRoute]int id)

        {
            //cycle through the existing customers table in the database and select the customerId that matches the argument
            var customer = context.Customer.SingleOrDefault(c => c.CustomerId == id);
            
            if (customer == null)
            {
                return NotFound();
            }

            //create a new instance of the ActiveCustomer class and assign the selected customer to the .Customer property on that instance
            ActiveCustomer.instance.Customer = customer;

            return Json(customer);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}