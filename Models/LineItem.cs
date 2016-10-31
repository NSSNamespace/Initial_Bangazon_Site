using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
Author: David Yunker
*/

namespace Bangazon.Models
{
    //The LineItem class represents an order/product relationship table in the BangazonContext db.
    public class LineItem
    {
        [Key]
        public int LineItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}