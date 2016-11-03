using System.Collections.Generic; 
using Bangazon.Models; 
using Bangazon.Data;

namespace Bangazon.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public double TotalCost { get; set; }
        public Order Order { get; set; }
        public PaymentType PaymentType { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<LineItem> LineItem { get;set; }
        public OrderViewModel(BangazonContext ctx) : base(ctx) { }
    }
}