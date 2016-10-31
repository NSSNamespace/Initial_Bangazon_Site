using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
Author: David Yunker
*/

namespace Bangazon.Models
{
    //The Order class represents the order table in the BangazonContext db
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateCompleted { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public ICollection<LineItem> LineItems;
    }
}
