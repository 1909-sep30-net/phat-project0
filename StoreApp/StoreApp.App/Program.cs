using System;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"C:\revature\phat-project0\Project0-Log\Log.txt").CreateLogger();
            Log.Information("Begin Program");

            bool menu = true, flag = true;
            StoreApp.Logic.Customer getCustomer = new Logic.Customer();
            StoreApp.Logic.Store getStore = new Logic.Store();
            StoreApp.Logic.Order inputOrder = new Logic.Order();

            using var context = new StoreAppContext();


            Console.WriteLine("Hello Welcome To The ABC's Grocery Store");
            string userInput;
            string userChoice;

            Console.WriteLine("Are you:\n1. Manager\n2. Customer");
            userInput = Console.ReadLine();
            userChoice = UserChoiceHandler.UserOptionHandler(Int32.Parse(userInput), 2);

            while (flag == true)
            {
                if (userChoice == null)
                {
                    Console.WriteLine("Are you:\n1. Manager\n2. Customer");
                    userInput = Console.ReadLine();
                    userChoice = UserChoiceHandler.UserOptionHandler(Int32.Parse(userInput), 2);
                    flag = true;
                    menu = false;
                }
                else
                {
                    flag = false;
                    menu = true;
                }
            }

            while (menu == true)
            {
                userChoice = UserChoiceHandler.UserOptionHandler(Int32.Parse(userInput), 2);

                if (userChoice == "1") //Manager
                {
                    string managerID;
                    Console.WriteLine("Enter Your ID: ");
                    managerID = Console.ReadLine();
                    StoreApp.Logic.Manager getManagerInfo = getDB.GetManagerDataFromId(Int32.Parse(managerID), context);

                    if (getManagerInfo == null)
                    {
                        Console.WriteLine("Invalid ID. Please Try It Again");
                        userChoice = "1";
                    }

                    else 
                    {
                        if (getDB.CheckIDParsable(getManagerInfo.managerID))
                        {
                            Console.Clear();
                            try
                            {
                                Console.WriteLine("Welcome back, " + getManagerInfo.firstName + " " + getManagerInfo.lastName);
                                Console.WriteLine("Manager's Options:");
                                Console.WriteLine("1. View Order History Of A Store\n2. Add New Items To Stores\n3. Switch To Customer Menu \n4. Stop");
                                int manOpt = Int32.Parse(Console.ReadLine());
                                string managerChoice = UserChoiceHandler.UserOptionHandler(manOpt, 4);
                                if (managerChoice == null)
                                {
                                    Console.WriteLine("1. View Order History Of A Store\n2. Add New Items To Stores\n3. Exit to start menu \n4. Stop");
                                    manOpt = Int32.Parse(Console.ReadLine());
                                    managerChoice = UserChoiceHandler.UserOptionHandler(manOpt, 4);
                                }
                                if (manOpt == 1 || manOpt == 2)
                                {
                                    Menu.ManagerMenu(context, manOpt);
                                }
                                else if (manOpt == 3)
                                {
                                    Console.WriteLine("Are you:\n1. Manager\n2. Customer");
                                    userInput = Console.ReadLine();
                                    userChoice = UserChoiceHandler.UserOptionHandler(Int32.Parse(userInput), 2);
                                }
                                else if (manOpt == 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("See You Later. Please Press Any Key To Stop");
                                    menu = false;
                                }


                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("There Is An Error. Please Try It Again");
                            }
                        }
                    }

                   
                }
                else if (userChoice == "2") //Customer
                {
                    Console.Clear();
                    //Will run code to make new customer, list of customer info, and place orders
                    Console.WriteLine("1. Sign Up  \n2. Login \n3. Exit to start menu \n4. Stop");
                    userChoice = Console.ReadLine();
                    string customerChoice = UserChoiceHandler.UserOptionHandler(Int32.Parse(userChoice), 4);
                    


                    if (userChoice == "3")
                    {
                        Console.WriteLine("Are you:\n1. Manager\n2. Customer");
                        userInput = Console.ReadLine();
                        userChoice = UserChoiceHandler.UserOptionHandler(Int32.Parse(userInput), 2);

                    }
                    else if (userChoice == "4")
                    {
                        Console.Clear();
                        Console.WriteLine("See You Later. Please Press Any Key To Stop");
                        menu = false;
                    }
                    else if(userChoice == "1" || userChoice == "2")
                    {
                        Menu.CustomerMenu(context, Int32.Parse(userChoice));
                    }
                    else //Invalid input
                    {
                        Console.WriteLine("Invalid input, please type one of the following options");
                    }
                }
                else //Invalid input
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please type one of the following options");
                    Console.WriteLine("1. Sign Up  \n2. Login \n3. Exit to start menu \n4. Stop");
                    userChoice = Console.ReadLine();
                }
            }
        }

    }



}
