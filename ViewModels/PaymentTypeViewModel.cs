
using Bangazon.Models;
using Bangazon.Data;
/*
Author: jammy Laird
Purpose: Aggregate data for display on PaymentTypeViewModel, including active customer inherited from BaseViewModel class. 
*/

namespace Bangazon.ViewModels
{
    public class PaymentTypeViewModel: BaseViewModel
    {
        //Create PayemntTypeViewModel class, which inherits from BaseViewModel, and therefore contains the active customer 

        public PaymentType NewPaymentType{get; set;}
        //Create custom constructor that accepts current BangazonContext as argument and passes it up inheritance chain to BaseViewModel
        public PaymentTypeViewModel(BangazonContext ctx) : base(ctx){}
       
    }
}


