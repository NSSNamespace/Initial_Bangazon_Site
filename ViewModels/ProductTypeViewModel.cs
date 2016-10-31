using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Bangazon.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

/*
Author: Jammy Laird
*/

namespace Bangazon.ViewModels
{
    //Create ProductTypeViewModel that inherits from BaseViewModel
    public class ProductTypeViewModel : BaseViewModel
    {
    public IEnumerable<Product> ProductTypes {get;set;}
    //Create a custom constructor that accepts BangazonContext as an argument and passes that context (session with db) up to the methods on BaseViewModel
    public ProductTypeViewModel(BangazonContext ctx) : base(ctx) { }
    }
}