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
            ProductListViewModel model = new ProductListViewModel(context);

            // Set the properties of the view model
           model.Products = await context.Product.OrderBy(s => s.Title.ToUpper()).ToListAsync(); 
            

            
            
            return View(model);
        }
        
            

        //Method: purpose is to create Products/Create view that delivers the form to create a new product, including the product type dropdown (will need adjustment when creating subcategories) and customer dropdown on navbar

        [HttpGet]
        public IActionResult Create()
        {
            CreateProductViewModel model = new CreateProductViewModel(context);
            return View(model);
        }

        //Method: Purpose is to send the customer's product to the database and then redirects the user to the homepage (AllProductsView)
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Product product)
        {
            //This creates a new variable to hold our current instance of the ActiveCustomer class and then sets the active customer's id to the CustomerId property on the product being created so that a valid model is sent to the database
            var customer = ActiveCustomer.instance.Customer;
            product.CustomerId = customer.CustomerId;

            //This creates a new instance of the CreateProductViewModel so that we can return the same view (i.e., the existing product info user has entered into the form) if the model state is invalid when user tries to create product
            CreateProductViewModel model = new CreateProductViewModel(context); 
            
            if (ModelState.IsValid)
            {
                context.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //Method: Purpose is to route user to the detail view on a selected product. Accepts an argument (passed in through the route) of the product's primary key (id)

        public async Task<IActionResult> Detail([FromRoute]int? id)
        {
            //throw a 404(NotFound) error if method is called w/o id in route
            if (id == null)
            {
                return NotFound();
            }

            // Create a new instance of the ProductDetailViewModel and pass it the existing BangazonContext (current db session) as an argument in order to extract the product whose id matches the argument passed in¸
            ProductDetailViewModel model = new ProductDetailViewModel(context);

            // Set the `Product` property of the view model and include the product's seller (i.e., its .Customer property, accessed via Include, which traverses Product table and selects the Customer FK)
            model.Product = await context.Product
                    .Include(prod => prod.Customer)
                    .SingleOrDefaultAsync(prod => prod.ProductId == id);

            // If no matching product found, return 404 error
            if (model.Product == null)
            {
                return NotFound();
            }

            //Otherwise, return the ProductDetailViewModel view with the ProductDetailViewModel passed in as argument for rendering that specific product on the page

            return View(model);
        }

        //Method: Purpose is to return a view that displays all the products of one category. Accepts one argument, passed in through route, of ProductTypeId.
        public async Task<IActionResult> Type([FromRoute]int id)
        {
            ProductListViewModel model = new ProductListViewModel(context);
            model.Products = await context.Product.OrderBy(s => s.Title.ToUpper()).Where(p => p.ProductTypeId == id).ToListAsync();
            return View(model);
        }
        
        //Method: Purpose is to render the ProductTypes view, which displays all product categories
        public async Task<IActionResult> Types()
        {
            //This creates a new instance of the ProductTypesViewModel and passes in the current session with the database (context) as an argument

            ProductTypesViewModel model = new ProductTypesViewModel(context);
            model.ProductTypes = await context.ProductType.OrderBy(s => s.Label).ToListAsync(); 
            return View(model);
        }
        //Method: Purpose is to return the Error view
        public IActionResult Error()
        {
            return View();
        }
    }
}