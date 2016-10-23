using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon.Models;
using Bangazon.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BangazonWeb.Controllers
{
    public class CustomersController : Controller
    {
        private BangazonContext context;

        public CustomersController (BangazonContext ctx)
        {
            context = ctx;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Add(customer);
                await context.SaveChangesAsync();
                //redirect the user view to the home page by passing in 2 arguments: action("index"), controller("products")
                return RedirectToAction("Index", "Products");
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}