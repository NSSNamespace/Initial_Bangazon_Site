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

namespace BangazonWeb.Controllers
{
    public class CustomersController : Controller
    {
       
        private BangazonContext context;

        public CustomersController(BangazonContext ctx)
        {
            context = ctx;
        }

        public ActionResult Menu()
        {
            MenuViewModel model = new MenuViewModel(context);

            return PartialView(model);
        }

        //Annotation on Line 31 indicates that the following code contains the logic for explicitly responding to a post SENT from the front-end 
        [HttpPost]
        public IActionResult Activate([FromBody]int CustomerId)
        {
            var customer = context.Customer.SingleOrDefault(c => c.CustomerId == CustomerId);

            if (customer == null)
            {
                return NotFound();
            }

            //Line 36 sets the property of customer on the current instance of the ActiveCustomer class. 
            //INSTANCE RETURNS AN **OBJECT** IN MEMORY, RATHER THAN A PROPERTY ON THE CLASS OF ACTIVE CUSTOMER
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