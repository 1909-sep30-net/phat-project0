using StoreApp.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using StoreApp.Logic;
namespace StoreApp.Library.Handlers
{
    public class GetDataHandler
    {
        private Parser parser = new Parser();
        public bool CheckIDParsable(int IDString)
        {
            //Checks if the Id string input is parsable to an int and returns true or false

            if (IDString.ToString().Any(x => !char.IsLetter(x)) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UsernameParser(string username, StoreAppContext context)
        {

            foreach(StoreApp.Library.Entities.Customer cust in context.Customer)
            {
                if (cust.Username == username)
                {
                    return true;
                }
            }
            return false;
        }

 
        public Logic.Customer CustomerData(string username, StoreAppContext context)
        {
            //List All Customer Info If ManagerId is Correct
            try
            {
                foreach (StoreApp.Library.Entities.Customer cust in context.Customer)
                {
                    if (cust.Username == username)
                    {
                        return parser.ContextCustomerToLogicCustomer(cust);
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot Connect To Database" + e.Message);
                return null;
            }
        }

        
        
        public Logic.Customer GetCustomerDataFromUsername(string username, StoreAppContext context)
        {
            //Some code to retrieve a list of customer data

            try
            {
                foreach (StoreApp.Library.Entities.Customer cust in context.Customer)
                {
                    if (cust.Username == username)
                    {
                        StoreApp.Logic.Customer matched = parser.ContextCustomerToLogicCustomer(cust);
                        return matched;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Operation failed: " + e.Message);
                return null;
            }
        }


        public Logic.Manager GetManagerDataFromId(int managerID, StoreAppContext context)
        {

            try
            {
                foreach (StoreApp.Library.Entities.Manager man in context.Manager)
                {
                    if (man.ManagerId == managerID)
                    {
                        return parser.ContextManagerToLogicManager(man);
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot Connect To Database" + e.Message);
                return null;
            }
        }

        public Logic.Store GetStoreFromStoreId(int storeId, StoreAppContext context)
        {
            try
            {
                foreach (Entities.Store store in context.Store)
                {
                    if (store.StoreId == storeId)
                    {
                        return parser.ContextStoreToLogicStore(store);
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Operation failed: " + e.Message);
                return null;
            }
        }
    }
}