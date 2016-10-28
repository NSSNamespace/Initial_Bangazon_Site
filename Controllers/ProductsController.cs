using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bangazon.ViewModels;

//Authors: Jammy Laird, Liz Sanger, Elliott Williams, David Yunker, Fletcher Watson

namespace Bangazon.Controllers
{
    //Creates ProductsController
    public class ProductsController : Controller
    {
        //Sets private property of BangazonContext;
        private BangazonContext context;

        //Method: creates custom constructor method with argument of context, therefore rendering context public 
        public ProductsController(BangazonContext ctx)
        {
            context = ctx;
        }

        //Method: creates async method for two purposes: extract the Customer table from current context for extraction into the dropdown menu and return the Index view of complete product list
        public async Task<IActionResult> Index()
        {

            ViewData["CustomerId"] = context.Customer
                                       .OrderBy(l => l.LastName)
                                       .AsEnumerable()
                                       .Select(li => new SelectListItem
                                       {
                                           Text = $"{li.FirstName} {li.LastName}",
                                           Value = li.CustomerId.ToString()
                                       });

            return View(await context.Product.ToListAsync());

        }

        //Method: purpose is to create new instance of MenuViewModel, taking the current context as an argument and returning the PartialView for injection as in ActiveCustomerComponent

        public ActionResult Menu()
        {
            MenuViewModel model = new MenuViewModel(context);

            return PartialView(model);
        }

        //Method: purpose is to create Products/Create view that renders both product type dropdown (will need adjustment when creating subcategories) and customer dropdown on navbar

        [HttpGet]

        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = context.ProductType
                                       .OrderBy(l => l.Label)
                                       .AsEnumerable()
                                       .Select(li => new SelectListItem
                                       {
                                           Text = li.Label,
                                           Value = li.ProductTypeId.ToString()
                                       });

            ViewData["CustomerId"] = context.Customer
                                       .OrderBy(l => l.LastName)
                                       .AsEnumerable()
                                       .Select(li => new SelectListItem
                                       {
                                           Text = $"{li.FirstName} {li.LastName}",
                                           Value = li.CustomerId.ToString()
                                       });
            return View();
        }

        //Method: Purpose is to send the customer's product to the database
        [HttpPost]
        [ValidateAntiForgeryToken]

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

        //QUESTION: which IActionResult (contract representing the result of an action method) is represented in the async Task below? In other words, to which action method does this task respond? If it is the Create method that accepts a Product as a parameter, is it accurate to say that <IActionResult> represents the View(product) returned?

        // public async Task<IActionResult> Detail([FromRoute]int? id)
        // {
        //     // If no id was in the route, return 404
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var product = await context.Product
        //             .Include(s => s.Customer)
        //             .SingleOrDefaultAsync(m => m.ProductId == id);

        //     // If product not found, return 404
        //     if (product == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(product);
        // }

        //Creates an async method called Detail that returns a value via Task<IActionResult> and accepts an argument of type int (the customerId)

        public async Task<IActionResult> Detail([FromRoute]int? id)
        {
            //throw a 404(NotFound) error if method is called w/o id in route
            if (id == null)
            {
                return NotFound();
            }

            // Create a new instance of the ProductDetail ViewModel and pass it the existing BangazonContext (current db session) as an argument in order to extract the product whose id matches the argument passed in¸
            ProductDetail model = new ProductDetail(context);

            // Set the `Product` property of the view model and include the product's seller (i.e., its .Customer property, accessed via Include, which traverses Product table and selects the Customer FK)
            model.Product = await context.Product
                    .Include(prod => prod.Customer)
                    .SingleOrDefaultAsync(prod => prod.ProductId == id);

            // If no matching product found, return 404 error
            if (model.Product == null)
            {
                return NotFound();
            }

            //Otherwise, return the ProductDetail view with the ProductDetailViewModel passed in as argument for rendering that specific product on the page

            return View(model);
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