using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Bangazon.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bangazon.ViewModels
{
  //Class from which all other view models inherit.
  public class BaseViewModel
  {
    //This is the selectItem list that will make up the dropdown on each page. 
    public List<SelectListItem> CustomerId { get; set; }
    private BangazonContext context;

    public List<Product> CartProducts { get; set; }

        public int TotalCount { get;  private set; }

    //ActiveCustomer.instance instantiates an instance of ActiveCustomer. This instatiation has a property of Customer on it. That's what we assign to ActiveCustomer. 
    private ActiveCustomer singleton = ActiveCustomer.instance;
    public Customer ChosenCustomer 
    {
      get
      {
        //Get the current value of the customer property of our singleton
        Customer customer = singleton.Customer;

        //If no customer has been chosen yet, its value will be null
        if (customer == null)
        {
          //Return fake customer for now
          return new Customer () {
            FirstName = "Create",
            LastName = "Account",
            CustomerId = 0
          };
        }

        //If there is a customer chosen, return it
        return customer;
      }
      set
      {
        if (value != null)
        {
          singleton.Customer = value;
        }
      }
    }

    //This is a custom constructor for BaseViewModel. We need BaseViewModel to be able to access the customer dropdown on all of our pages. It takes an argument of BangazonContext which represents a session with the database.
     public BaseViewModel(BangazonContext ctx)
    {
        context = ctx;
        this.CustomerId = context.Customer
            .OrderBy(l => l.LastName)
            .AsEnumerable()
            .Select(li => new SelectListItem { 
                Text = $"{li.FirstName} {li.LastName}",
                Value = li.CustomerId.ToString()
            }).ToList();

        this.CustomerId.Insert(0, new SelectListItem { 
                Text = "Choose customer...",
                Value = "0"
            });
    }
      public string ShoppingCartItems {
      get {
        Customer customer = singleton.Customer;

        if (customer == null)
        {
          // Return null because there should not be a number next to the link if a customer has not been chosen.
          return "";
        }
        if (customer != null){
          //If there is a customer but the customer does not have an active order then the shopping cart should have 0 items in it.
           Order order = context.Order.Where(o => o.CustomerId == customer.CustomerId && o.DateCompleted == null).SingleOrDefault();
           if (order == null){
             return " (0)";
           }
           //If the user has an active order then the number of products in that order will be returned
           if (order != null){
            List<LineItem> lineItems = context.LineItem.Where(l => l.OrderId == order.OrderId).ToList();
            string shoppingCartCount = lineItems.Count.ToString();
            return " ("+shoppingCartCount+")";
           }
        }
        return "";
      }
    }
   
    public BaseViewModel() { }
  }
}