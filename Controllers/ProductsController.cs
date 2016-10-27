using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BangazonWeb.Controllers
{
    public class ProductsController : Controller
    {
        private BangazonContext context;

        public ProductsController(BangazonContext ctx)
        {
            context = ctx;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.Product.ToListAsync());
        }
        [HttpGet]

        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = context.ProductType
                                       .OrderBy(l => l.Label)
                                       .AsEnumerable()
                                       .Select(li => new SelectListItem { 
                                           Text = li.Label,
                                           Value = li.ProductTypeId.ToString()
                                        });

            ViewData["CustomerId"] = context.Customer
                                       .OrderBy(l => l.LastName)
                                       .AsEnumerable()
                                       .Select(li => new SelectListItem { 
                                           Text = $"{li.FirstName} {li.LastName}",
                                           Value = li.CustomerId.ToString()
                                        });
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        //QUESTION: which IActionResult (contract representing the result of an action method) is represented in the async Task below? In other words, to which action method does this task respond? If it is the Create method that accepts a Product as a parameter, is it accurate to say that <IActionResult> represents the View(product) returned?
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public async Task<IActionResult> Detail([FromRoute]int? id)
        {
            // If no id was in the route, return 404
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Product
                    .Include(s => s.Customer)
                    .SingleOrDefaultAsync(m => m.ProductId == id);

            // If product not found, return 404
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Type([FromRoute]int id)
        {
            ViewData["Message"] = "Here is the type INSERT TYPE.";

            return View();
        }
        public IActionResult Types()
        {
            ViewData["Message"] = "Here are products of INSERT TYPE here";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}