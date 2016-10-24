using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bangazon.Data;
using Bangazon.Models;
using Microsoft.EntityFrameworkCore;

namespace BangazonWeb.Controllers
{

     public class OrderController : Controller

    {
        private BangazonContext context;

  public OrderController(BangazonContext ctx)
        {
            context = ctx;
        }

        public async Task <IActionResult> Cart([FromRoute] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // var myOrder = await context.Order 
            //     .Include(s => s.PaymentType)
            //     .Include (order => order.LineItems).ThenInclude(LineItems => LineItems.Product)
            //     .SingleOrDefaultAsync(m => m.OrderId == id);
                // InvalidOperationException: The expression '[s].LineItems' passed to the Include operator could not be bound.

        //   var myOrder = (from order in context.Order.Include("LineItems")
        //       where order.Product.Any(x => x.Product.Equals(ProductId))
        //       select order);

        var result = (from products in context.Product.Include(product => product.LineItem)
              where products.LineItem.Any(lineitem => lineitem.OrderId.Equals(id))
              select products);
              
        
        // 'ICollection<LineItem>' does not contain a definition for 'Product' and no extension method 'Product' accepting a first argument of type 'ICollection<LineItem>' could be found (are you missing a using directive or an assembly reference?)
            // var myOrder = (from products in context.Product.Include(order => order.LineItems).ThenInclude(LineItems => LineItems.Product)
            //   select order);
            if (result == null)
            {
                return NotFound();
            }
            
            return View(result);
        }


        public IActionResult Confirm()
        {
             ViewData["Message"] = @"Order Processed! 
             Thank you for shopping at Bangazon!";

            return View();
        }

    }


}