using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bangazon.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

    /*
    Class: ProductsController
    Purpose: Allows users to add a product the website, and delivers the forms necessary for doing so.
    * Author: Fletcher Watson
    * Methods:
    *   ProductsController() - creates a new instance of the MenuViewModel class and passes in the current BangazonContext as argument in order to extract existing customers from corresponding db table
    *   Index() - takes user to view of all products in the system. This is the "home" view.
    *   Create() - responds to an HTTP Get and returns the form for users to fill out info about their product to add to the site.
    *   Create(Product product) - responds to an HTTP Post when user hits "submit" button on add product form.
    *   Detail([FromRoute]int? id) - returns view based on id in route of the details of the specific product that matches the id.
    *   Type() - Returns view of all products of a specific type.
    *   Types([FromRoute]int id) - Returns view of all types available on the site.
    *   Error() - returns a boilerplate error page located in shared folder.
    */
namespace BangazonWeb.Controllers
{
    //This class is a controller that handles all of the data that deals with products on the site.
    public class ProductsController : Controller
    {
        //Here we are creating a variable 'context' that we use to access the database: BangazonContext 
        private BangazonContext context;

        //ProductsControlleris a method that accepts a parameter of type BangazonContext and internally sets that parameter to the previously defined context variable.
        public ProductsController(BangazonContext ctx)
        {
            context = ctx;
        }
        //The Index Method is an async method that is of Type Task, and returns the Index view, which in our case is a list of all of the products on the "home" page.
        //The view is returned by going to the database and converting products to a List<T> by enumerating it asynchronously.
        public async Task<IActionResult> Index()
        {
            return View(await context.Product.ToListAsync());
        }
        //Create responds to an HTTP Get and implements the IActionResult Interface.
        [HttpGet]
        public IActionResult Create()
        {
            //Set up ViewData of "ProductTypeId" which hits the database, goes through the ProductType table, orders it by label, 
            //makes it an enumerable list, and then makes each item in the list a SelectListItem.
            //In the dropdown users will see the label (name) of the ProductType, which will have a string value of ProductTypeId.
            ViewData["ProductTypeId"] = context.ProductType
                                       .OrderBy(l => l.Label)
                                       .AsEnumerable()
                                       .Select(li => new SelectListItem { 
                                           Text = li.Label,
                                           Value = li.ProductTypeId.ToString()
                                        });
            //Set up ViewData of "CustomerId" which hits the database, goes through the Customer table, orders it by last name, 
            //makes it an enumerable list, and then makes each item in the list a SelectListItem.
            //In the dropdown users will see the first and last names of the Customer, which will have a string value of CustomerId.
            ViewData["CustomerId"] = context.Customer
                                       .OrderBy(l => l.LastName)
                                       .AsEnumerable()
                                       .Select(li => new SelectListItem { 
                                           Text = $"{li.FirstName} {li.LastName}",
                                           Value = li.CustomerId.ToString()
                                        });
            //The "Create" view is returned after the ViewData is generated.
            return View(); 
        }
        //This Create method is overloading the Create method above by accepting a Product as a parameter. It responds to a post from 
        //from the submitted form. The second decoration checks to see that all required form fields have been completed.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //QUESTION: which IActionResult (contract representing the result of an action method) is represented in the async Task below? In other words, to which action method does this task respond? If it is the Create method that accepts a Product as a parameter, is it accurate to say that <IActionResult> represents the View(product) returned?
        public async Task<IActionResult> Create(Product product)
        {
            //This check is to make sure that the data being sumitted to the table in the database is of the same structure as the data submitted
            //in the form. If it is, then the form data is added to Product Table in the database and changes are saved. The user is then redirected
            //to the ProductList view. If the ModelStat is NOT valid, then the same view is returned and no product is posted to the db.
            if (ModelState.IsValid)
            {
                context.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        //The Detail method is an async method of type Task<IActionResult> that accepts a nullable int id from the route as a parameter.
        public async Task<IActionResult> Detail([FromRoute]int? id)
        {
            //The method checks first if the id is valid. If it is not, then a 404 is returned. 
            if (id == null)
            {
                return NotFound();
            }
            //If the id is not null, the method creates a variable called product, awaits the retrieval of the Product from the db, 
            //includes the foreign key of customer and assings the ProductId to the id parameter.
            var product = await context.Product
                    .Include(s => s.Customer)
                    .SingleOrDefaultAsync(m => m.ProductId == id);

            //The method makes another check on the product. If it is null, then a 404 is thrown. If it is now, then the Detail view of that product
            //is returned.
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        //Type is a method that returns IActionResult. It accepts an int id as a paramter.
        public IActionResult Type([FromRoute]int id)
        {
            //ViewData stores a message in the "Message" variable for display in the view.
            ViewData["Message"] = "Here is the type INSERT TYPE.";
            //The view that is returned is a list of products of the type that matches the id passed in as an argument.
            return View();
        }
        //Types is a method that returns IActionResult.
        public IActionResult Types()
        {
            //ViewData stores a message in the "Message" variable for display in the view.
            ViewData["Message"] = "Here are products of INSERT TYPE here";
            //The view that is returned is a list of all of the types available in the db.
            return View();
        }
        //Error is a method that returns IActionResult.
        public IActionResult Error()
        {
            //The view that is returned is the error view in shared folder.
            return View();
        }
    }
}