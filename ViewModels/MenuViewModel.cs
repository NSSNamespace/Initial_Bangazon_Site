using Bangazon.Models;
using Bangazon.Data;

namespace Bangazon.ViewModels
{
  /*
  Author: David Yunker   
  Purpose: To have a MenuViewModel that will display the Active Customer's first and last name
  in the navbar. This viewmodel inherits from the BaseViewModel. 
  */    

  public class MenuViewModel : BaseViewModel
  {
    //Purpose: The MenuViewModel constructor method below instantiates an instance of a MenuViewModel. 
    //Argument list: The only argument for this constructor method is the BangazonContext, which gives us access to the database.  
    public MenuViewModel(BangazonContext ctx) : base(ctx) { }
  }
}