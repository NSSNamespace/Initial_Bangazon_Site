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
            var order = await context.Order 
                .Include(s => s.PaymentType)
                .SingleOrDefaultAsync(m => m.OrderId == id);

            
            if (order == null)
            {
                return NotFound();
            }
            
            return View(order);
        }


        public IActionResult Confirm()
        {
             ViewData["Message"] = "Order Processed Thank you for shopping at Bangazon!";

            return View();
        }

    }


}