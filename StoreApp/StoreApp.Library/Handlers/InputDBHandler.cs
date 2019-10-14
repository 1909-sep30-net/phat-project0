using StoreApp.Library.Entities;
using StoreApp.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library.Handlers
{
    public class InputDBHandler
    {
        private Parser parser = new Parser();

        public void AddNewCustomer(Logic.Customer LogicCustomer, StoreAppContext context)
        {
            //Some code to input customer data to the DB

            try
            {
                //SaveChanges is needed to persist the data
                context.Customer.Add(parser.LogicCustomerToContextCustomer(LogicCustomer));
                context.SaveChanges();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to put the customer into the database: " + e.Message);
            }
        }
        public void PlaceOrder(Order LogicOrder, StoreAppContext context)
        {
            try
            {
                context.Orders.Add(parser.LogicOrderToContextOrder(LogicOrder));
                context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Console.WriteLine("Something went wrong inputting order: " + e);
            }
        }

       
    }
}
