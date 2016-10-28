
using Bangazon.Models;
using Bangazon.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

/*
Author: David Yunker 
Purpose: Aggregate data for display on ProductCreatelView, including customerId dropdown menu inherited from BaseViewModel class. 
Methods: CreateProductViewModel class custom constructor, which accepts BangazonContext as an argument

*/

namespace Bangazon.ViewModels
{
    //create ProductDetailViewModel class, which inherits from BaseViewModel, and therefore contains the dropdown menu with customer name selected
  public class CreateProductViewModel : BaseViewModel
  {
      //create property of type Product; this will allow us to display the fields needed to create a product. 
    public Product Product { get; set; }

    public List<SelectListItem> ProductTypeId { get; set; }
    //create custom constructor that accepts current BangazonContext as argument and passes it up inheritance chain to BaseViewModel
    public CreateProductViewModel(BangazonContext ctx) : base(ctx) 
        { 

            this.ProductTypeId = ctx.ProductType 
                .OrderBy(l => l.Label)
                .AsEnumerable()
                .Select(li => new SelectListItem
                {
                    Text = li.Label,
                    Value = li.ProductTypeId.ToString()
                }).ToList();
            
        }
    }
}