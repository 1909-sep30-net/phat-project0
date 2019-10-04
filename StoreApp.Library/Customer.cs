using System;

namespace StoreApp.Library
{
    public class Customer   
    {
        public string firstName {get; set;}
        public string lastName {get;set;}
        public Address customerAddress {get;set;}

        private int customerId;
        public int customerId {get;set;}
    }
}
