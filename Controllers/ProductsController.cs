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
            // Create new instance of the view model
            ProductList model = new ProductList(context);

            // Set the properties of the view model
            model.Products = await context.Product.ToListAsync(); 
            return View(model);
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
            CreateProductViewModel model = new CreateProductViewModel(context);
            return View(model);
        }

        //Method: Purpose is to send the customer's product to the database
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Product product)
        {
            var customer = ActiveCustomer.instance.Customer;
            product.CustomerId = customer.CustomerId;
            
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
        public async Task<IActionResult> Types()
        {
            ProductTypesViewModel model = new ProductTypesViewModel(context);

            model.ProductTypes = await context.ProductType.ToListAsync(); 
            return View(model);
            
            // ViewData["CustomerId"] = context.Customer
            //                            .OrderBy(l => l.LastName)
            //                            .AsEnumerable()
            //                            .Select(li => new SelectListItem
            //                            {
            //                                Text = $"{li.FirstName} {li.LastName}",
            //                                Value = li.CustomerId.ToString()
            //                            });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}