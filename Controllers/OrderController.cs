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
            var myOrder = await context.Order 
                .Include(s => s.PaymentType)
                .Include (order => order.LineItems).ThenInclude(LineItems => LineItems.Product)
                .SingleOrDefaultAsync(m => m.OrderId == id);

        //   var myOrder = (from order in Context.Order.Include("LineItems")
        //       where order.Product.Any(x => x.Product.Equals(productId))
        //       select order);
            
            // var myOrder = (from order in context.Order.Include(order => order.LineItems).ThenInclude(LineItems => LineItems.Product)
            //   select order);
            if (myOrder == null)
            {
                return NotFound();
            }
            
            return View(myOrder);
        }


        public IActionResult Confirm()
        {
             ViewData["Message"] = @"Order Processed! 
             Thank you for shopping at Bangazon!";

            return View();
        }

    }


}