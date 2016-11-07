
using Bangazon.Models;
using Bangazon.Data;

namespace Bangazon.ViewModels
{
    public class PaymentTypeView: BaseViewModel
    {
        public PaymentType NewPaymentType{get; set;}
        public PaymentTypeView(BangazonContext ctx) : base(ctx){}
        public PaymentTypeView(){}
    }
}


