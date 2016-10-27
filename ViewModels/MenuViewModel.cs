using Bangazon.Models;
using Bangazon.Data;
using Bangazon.ViewModels;

namespace Bangazon.ViewModels
{
//    Purpose: To have a MenuViewModel that will display the Active Customer's First and last name
//             in the navbar. This viewmodel inherits from the BaseViewModel. 
//    Author: David Yunker 
//    

  public class MenuViewModel : BaseViewModel
  {
    //   Purpose: The MenuViewModel constructor method below instantiates an instance of a 
    //            MenuViewModel. 
    //   Argument list: The only argument for this constructor method is the BangazonContext, 
    //                  which gives us access to the database.  
    public MenuViewModel(BangazonContext ctx) : base(ctx) { }
  }
}