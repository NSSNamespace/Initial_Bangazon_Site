using System.Collections.Generic; 
using Bangazon.Models; 
using Bangazon.Data;

namespace Bangazon.ViewModels
{
    class OrderViewModel : BaseViewModel
    {
        public IEnumerable<Product> Products {get; set;}
        public IEnumerable<LineItem> LineItem {get;set;}
        public OrderViewModel(BangazonContext ctx) : base(ctx) { }
    }
}