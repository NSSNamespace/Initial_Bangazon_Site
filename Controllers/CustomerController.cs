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

        public async Task<IActionResult> Index()
        {
            return View(await context.Product.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                context.Add(customer);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
