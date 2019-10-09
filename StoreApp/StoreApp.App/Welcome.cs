using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Library;

namespace StoreApp.App
{
    public class Welcome
    {
        static string customerJSONFilePath = @"C:\revature\phat-project0\Data\Customer.json";
        static string productJSONFilePath = @"C:\revature\phat-project0\Data\Product.json";
        static string OrderJSONFilePath = @"C:\revature\phat-project0\Data\Order.json";
        public void welcomePage()
        {
            int choice = 0;
            Console.WriteLine("Welcome To The ABC Grocery Store");
            Console.WriteLine("Your Are: 1-Customer 2-Manager");
            choice = Int32.Parse(Console.ReadLine());

            while (choice != 1 && choice != 2)
            {
                Console.WriteLine("Please Tell Me Who You Are:");
                Console.WriteLine("1-Customer 2-Manager");
                choice = Int32.Parse(Console.ReadLine());
            }
            requestHandler(choice);
            Console.Clear();
        }
        public void requestHandler(int opt)
        {
            switch (opt)
            {

                case 1:
                    CustomerDisplayMenu();
                    break;

                case 2:
                    ManagerDisplayMenu();
                    break;
            }

        }

        public void CustomerDisplayMenu()
        {
            int customerChoice;

            Console.WriteLine("1. Create A New Account");
            Console.WriteLine("2. List All Users");
            Console.WriteLine("3. Place An Order");
            Console.WriteLine("4. Search Another Stores");

            customerChoice = Int32.Parse(Console.ReadLine());

            switch (customerChoice)
            {
                case 1:
                    User.AddNewCustomer(customerJSONFilePath);
                    break;
                case 2:
                    User.DisplayCustomers(customerJSONFilePath);
                    break;
                default:
                    Console.WriteLine("Thank You");
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                    break;
            }
            //go back function later
        }

        static void ManagerDisplayMenu()
        {
            Console.Clear();
            int managerChoice = 0;
            Console.WriteLine("1. Search Customer By Stores");
            Console.WriteLine("2. Display Store");
            Console.WriteLine("3. Display Order History of a Store Location");
            Console.WriteLine("4. Display Order History of a Customer");
            managerChoice = Int32.Parse(Console.ReadLine());
            switch (managerChoice)
            {
                case 1:
                    User.SearchCustomerByName(customerJSONFilePath);
                    break;
              
                default:
                    Console.WriteLine("Thank You");
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

