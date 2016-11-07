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
      Author: Liz Sanger */

namespace Bangazon.Controllers
{
    //Create a new class called CustomersController, purpose is to allow users to create an account on the website, as well as select the active user from a dropdown menu in the navbar
    public class CustomersController : Controller
    {

        //Set a new private property on the controller to hold current session with db (Bangazon context)
       
        private BangazonContext context;

  //Method: Purpose is make existing session with db (BangazonContext) available to other methods throughout the controller via this custom constructor, which accepts existing session as argument
        public CustomersController(BangazonContext ctx)
        {
            context = ctx;
        }

        //Create a new instance of the CreateCustomerViewModel and return the Customer/Create view
           public IActionResult Create()
        {
            CreateCustomerViewModel model = new CreateCustomerViewModel(context);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Overload the Create() method with an async Task that sends a new customer. Also adds new customer's information to dropdown

        public async Task<IActionResult> Create(Customer customer)
        {
            CreateCustomerViewModel model = new CreateCustomerViewModel(context); 

             if (ModelState.IsValid)
            {
            context.Add(customer);
            await context.SaveChangesAsync();
            Activate(customer.CustomerId);
            return RedirectToAction("Index", "Products");
            }
            return View(model);

        }
        //Method: Purpose is to create a new instance of the ActiveCustomer class based on the customerId selected in the dropdown method. Accepts an argument, passed in through route/URL of an integer (the selected customer's primary key/id)
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
        //Method: Purpose is to return the Error view
        public IActionResult Error()
        {
            return View();
        }

    }
}