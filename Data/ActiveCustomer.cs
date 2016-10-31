using System;
using Bangazon.Models;

/*
Author: Liz Sanger
*/
namespace Bangazon.Data
{
    //The ActiveCustomer class used to acquire the currently active customer and pass that information to any relevant controllers.
    public class ActiveCustomer
    {
        private static ActiveCustomer _instance;
        public static ActiveCustomer instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ActiveCustomer();
                }
                return _instance;
            }
        }
        public Customer Customer { get; set; }
    }
}

