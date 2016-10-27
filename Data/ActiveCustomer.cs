using System;
using Bangazon.Models;

namespace Bangazon.Data
{

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

