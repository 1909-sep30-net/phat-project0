using System;
using Microsoft.EntityFrameworkCore;
using StoreApp.Library.Entities;
using StoreApp.Library.Handlers;

namespace StoreApp.App
{
    class Program
    {
        public static GetDataHandler getDB = new GetDataHandler();
        public static InputDBHandler inputDB = new InputDBHandler();
        static void Main(string[] args)
        {


            bool menu = true;
            StoreApp.Logic.Customer getCustomer = new Logic.Customer();
            StoreApp.Logic.Store getStore = new Logic.Store();
            StoreApp.Logic.Order inputOrder = new Logic.Order();

            using var context = new StoreAppContext();
            

            Console.WriteLine("Hello Welcome To The ABC's Grocery Store");
            int userInput = 0;
            int secondInput = 0;
            string userChoice;
            

            while (menu == true)
            {
                Console.WriteLine("Are you:\n1. Manager\n2. Customer");
                userInput = Int32.Parse(Console.ReadLine());
                userChoice = UserChoiceHandler.UserOptionHandler(userInput);

                if (userChoice == "1") //Manager
                {
                    Console.Clear();
                    string managerID;


                    Console.WriteLine("Enter Your ID: ");
                    managerID = Console.ReadLine();
                    if (getDB.CheckIDParsable(Int32.Parse(managerID)))
                    {

                        try
                        {
                            StoreApp.Logic.Manager getManagerInfo = getDB.GetManagerDataFromId(Int32.Parse(managerID), context);
                            Console.WriteLine("Welcome back, " + getManagerInfo.firstName + " " + getManagerInfo.lastName);
                            Console.WriteLine("Manager's Options:");
                            Console.WriteLine("1. View Order History Of A Store\n2. Add New Items To Stores\n3. Exit to start menu");
                            int manOpt = Int32.Parse(Console.ReadLine());
                            Menu.ManagerMenu(context, manOpt);
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine("NULL Error " + managerID + ": " + e.Message + "\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid ID");
                    }
                }

                else if (userChoice == "2") //Customer
                {
                    Console.Clear();
                    //Will run code to make new customer, list of customer info, and place orders
                    Console.WriteLine(" 1. Sign Up \n 2. Login");
                    secondInput = Int32.Parse(Console.ReadLine());
                    string customerChoice = UserChoiceHandler.UserOptionHandler(secondInput);

                    Menu.CustomerMenu(context, secondInput);


                }
                else //Invalid input
                {
                    Console.WriteLine("Invalid input, please type one of the following options");
                }
            }

        }


    }
}
