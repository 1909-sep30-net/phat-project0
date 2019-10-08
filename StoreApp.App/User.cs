using System;
using StoreApp.Library;
using System.Collections.Generic;

namespace StoreApp.App
{
    public class User
    {
        public static void AddNewCustomer()
        {
            Console.Clear();

            string firstName,lastName, address;
             List<Customer> addCustomer = new List<Customer>();

            Console.WriteLine("Please Enter Your First Name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Please Enter Your Last Name");
            lastName = Console.ReadLine();
            Console.WriteLine("Please Enter Your Address");
            address = Console.ReadLine();

            Customer newCustomer = new Customer();
            newCustomer.FirstName = firstName;
            newCustomer.LastName = lastName;
            //newCustomer.CustomerAddress = (string)address;

            addCustomer.Add(newCustomer);
            

            Console.WriteLine("New Customer {0} {1}",firstName,lastName +" Has Been Added");

            
        }

        public static void DisplayCustomers()
        {
            List<Customer> data = new List<Customer>();
            if (data != null)
            {
            
                Console.Clear();
                Console.WriteLine("Customer--------First Name-------Last Name");

                for (int i = 0; i < data.Count; i++)
                {
                    Console.WriteLine(" {0}   {1}    {2}", i + 1, data[i].FirstName, data[i].LastName);
                }

            }
          
        }
    }
}