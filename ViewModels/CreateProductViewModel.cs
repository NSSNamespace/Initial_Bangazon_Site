using Bangazon.Models;
using Bangazon.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

/*
Author: David Yunker 
Purpose: Aggregate data for display on CreateProductViewModel, including customerId dropdown menu inherited from BaseViewModel class. 
Methods: CreateProductViewModel class custom constructor, which accepts BangazonContext as an argument

*/

namespace Bangazon.ViewModels
{
    //Create CreateProductViewModel class, which inherits from BaseViewModel, and therefore contains the dropdown menu with customer name selected
    public class CreateProductViewModel : BaseViewModel
    {
        public Product Product { get; set; }
        public List<SelectListItem> ProductTypeId { get; set; }
        public List<SelectListItem> ProductTypeSubCategoryId { get; set; }
        //Create custom constructor that accepts current BangazonContext as argument and passes it up inheritance chain to BaseViewModel. Includes the logic necessary to populate the product type (aka category) and product type subcategory drop down menus
        public CreateProductViewModel(BangazonContext ctx) : base(ctx)
        {
            var context = ctx;
            this.ProductTypeId = context.ProductType
                .OrderBy(l => l.Label)
                .AsEnumerable()
                .Select(li => new SelectListItem
                {
                    Text = li.Label,
                    Value = li.ProductTypeId.ToString()
                }).ToList();

            this.ProductTypeId.Insert(0, new SelectListItem
            {
                Text = "Please Select a Category",
                Value = "0"
            });

            this.ProductTypeSubCategoryId = new List<SelectListItem>();

            this.ProductTypeSubCategoryId.Insert(0, new SelectListItem
            {
                Text = "Choose a Product Category to See Sub-Categories",
                Value = ""
            });

        }
    }
}