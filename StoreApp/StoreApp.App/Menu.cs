﻿using System;
using System.Linq;
using StoreApp.Logic;
using StoreApp.Library.Handlers;
using System.Collections.Generic;
using StoreApp.Library.Entities;
using Serilog;

namespace StoreApp.App
{
    class Menu
    {

        public static void CustomerMenu(StoreAppContext context, int cust)
        {
            Logic.Customer newCust = new Logic.Customer();
            GetDataHandler getDBHandler = new GetDataHandler();
            InputDBHandler Inputhandler = new InputDBHandler();

            Logic.Customer getCustomer = new Logic.Customer();
            Logic.Store getStore = new Logic.Store();
            Logic.Order order = new Logic.Order();
            Logic.Product items = new Logic.Product();
            List<Order> orderList = new List<Order>();
            string username =null;


            string userInput;
            bool customerMenu = true;
            bool nextMenu = false;
            switch (cust)
            {
                /// <summary>
                /// Sign Up New Account
                /// </summary>

                case 1:
                    while (customerMenu)
                    {

                        if (newCust.IsCustomerNotNull() == false)
                        {
                            if (newCust.userName == null)
                            {
                                
                                Console.WriteLine("What is your username");
                                newCust.userName = Console.ReadLine();

                                /// <summary>
                                /// Check Username To Make Sure It's not Existing
                                /// </summary>

                                var check = getDBHandler.GetCustomerDataFromUsername(newCust.userName,context);
                                if(check != null)
                                {
                                    Console.WriteLine("Username Existing. Choose another one");
                                    newCust.userName = Console.ReadLine();
                                }
                            }
                            else if (newCust.firstName == null)
                            {
                                Console.WriteLine("What is your first name?");
                                newCust.firstName = Console.ReadLine();
                            }
                            else if (newCust.lastName == null)
                            {
                                Console.WriteLine("What is your last name?");
                                newCust.lastName = Console.ReadLine();
                            }
                            else if (newCust.customerAddress.IsAddressNotNull() == false)
                            {
                                Console.WriteLine("What is your address?");
                                newCust.customerAddress.street = Console.ReadLine();

                                Console.WriteLine("Please enter a city");
                                newCust.customerAddress.city = Console.ReadLine();

                                Console.WriteLine("Please enter a state");
                                newCust.customerAddress.state = Console.ReadLine();

                                Console.WriteLine("Please enter a zip");
                                newCust.customerAddress.zip = Console.ReadLine();
                            }
                        }
                        else
                        {
                            /// <summary>
                            /// Insert New Account Into DB
                            /// </summary>
                            
                            try
                            {
                                Console.WriteLine("1.Yes 2.No");
                                userInput = UserChoiceHandler.UserOptionHandler(Int32.Parse(Console.ReadLine()), 2);
                                Console.WriteLine("Added New Customer Successfully! Welcome, " + newCust.firstName + " " + newCust.lastName);
                                Inputhandler.AddNewCustomer(newCust, context);
                                Console.WriteLine("Please Login With Your Username To Continue");
                                CustomerMenu(context, 2);
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Unknown exception thrown: " + e);
                            }

                        }
                    }
                    nextMenu = true; //resets menu true to go into next menu
                    cust = 2;
                    break;

                /// <summary>
                /// Logging Int User Account
                /// </summary>
                case 2:
                    while (customerMenu)
                    {
                        Console.WriteLine("What is your username?");
                         username = Console.ReadLine();

                        if (getDBHandler.UsernameParser(username, context) == false)
                        {
                            Console.WriteLine("Your UserName is Incorrect. Please Try It Again");
                            break;

                        }
                        else 
                        { 
                            try
                            {
                                /// <summary>
                                /// Get Customer Information From Logic.Customer
                                /// </summary>
                                getCustomer = getDBHandler.GetCustomerDataFromUsername(username, context);
                                Console.WriteLine("Welcome " + getCustomer.firstName + " " + getCustomer.lastName);
                                nextMenu = true;
                            }
                            catch (NullReferenceException e)
                            {
                                Console.WriteLine("NULL Error " + username + ": " + e.Message + "\n");
                                Log.Error("Null Value");
                                
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Unknown exeption " + e);
                                Log.Error("Unknown Error");
                            }
                        }
                        customerMenu = false; //resets menu true to go into next menu                 
                    }
                    break;
               
            }


            while (nextMenu)
            {
                Console.WriteLine("1. Place order\n2. View your order history\n3. Stop");
                userInput = UserChoiceHandler.UserOptionHandler(Int32.Parse(Console.ReadLine()),3);
                switch (userInput)
                {
                    /// <summary>
                    /// Place An Order
                    /// </summary>
                    case "1":
                        Console.WriteLine("What is your favorite store?\n1.Arlington \n5.Houston");
                        string store = Console.ReadLine();
                        if (getDBHandler.CheckIDParsable(Int32.Parse(store)) == false)
                        {
                            Console.WriteLine("Please Choice Either 1 or 2");
                            break;
                        }
                        else //if the input only has numbers in it
                        {
                            int storeId = Int32.Parse(store);
                            /// <summary>
                            /// Display Store Information Retrieved From DB
                            /// </summary>
                            try
                            {
                                getStore = getDBHandler.GetStoreFromStoreId(storeId, context);
                                Console.WriteLine("Store Address {0}, {1}, {2}, {3}", getStore.address.street, getStore.address.city, getStore.address.state, getStore.address.zip);
                                Console.WriteLine("Ariel: {0}, Downie: {1}, Suavitel: {2}", getStore.storeInventory.items.NumberofAriel, getStore.storeInventory.items.NumberofDownie, getStore.storeInventory.items.NumberofSuavitel);

                                bool decided = false;
                                int ariel;
                                int downie;
                                int suavitel;

                                while (!decided)
                                {
                                    try
                                    {
                                        Console.WriteLine("Ariel:");
                                        string input = Console.ReadLine();
                                        ariel = Int32.Parse(input);
                                        Console.WriteLine("Downie:");
                                        input = Console.ReadLine();
                                        downie = Int32.Parse(input);
                                        Console.WriteLine("Suavitels");
                                        input = Console.ReadLine();
                                        suavitel = Int32.Parse(input);


                                        Console.WriteLine("You have an order of Ariel: {0} || Downie: {1} || Suavitel: {2}",
                                         ariel, downie, suavitel);
                                        Console.WriteLine("1.Yes 2.No");
                                        userInput = UserChoiceHandler.UserOptionHandler(Int32.Parse(Console.ReadLine()), 2);

                                        if (userInput == "1")
                                        {
                                            decided = true;
                                            Console.WriteLine(". . .\n");

                                            if (ariel > getStore.storeInventory.items.NumberofAriel || downie > getStore.storeInventory.items.NumberofDownie || suavitel > getStore.storeInventory.items.NumberofSuavitel)
                                            {
                                                Console.WriteLine("Not Enough--Available: ");
                                                Console.WriteLine("Ariel: {0} || Downie: {1} || Suavitel: {2}",
                                                        getStore.storeInventory.items.NumberofAriel.ToString(),
                                                        getStore.storeInventory.items.NumberofDownie.ToString(),
                                                        getStore.storeInventory.items.NumberofSuavitel.ToString());
                                                decided = false;
                                            }
                                            else
                                            {
                                                order = new Logic.Order();
                                                //uses input handler to input order into DB
                                                var entityStore = context.Store.FirstOrDefault(i => i.StoreId == Int32.Parse(store));
                                                if (entityStore != null)
                                                {
                                                    order.customer = getCustomer;
                                                    order.cartItems.NumberofAriel = ariel;
                                                    order.cartItems.NumberofDownie = downie;
                                                    order.cartItems.NumberofSuavitel = suavitel;
                                                    order.ordererAddress = getCustomer.customerAddress;
                                                    order.PlaceOrderTime();
                                                    /// <summary>
                                                    /// Update Products' Quantities
                                                    /// </summary>
                                                    entityStore.Ariel -= ariel;
                                                    entityStore.Downie -= downie;
                                                    entityStore.Suavitel -= suavitel;

                                                    order.storeLocation.address = getStore.address;
                                                    order.storeLocation.storeInventory = getStore.storeInventory;
                                                    order.storeLocation.storeId = getStore.storeId;
                                                }
                                                context.Store.Update(entityStore);
                                                context.SaveChanges();
                                                try
                                                {
                                                    /// <summary>
                                                    /// Placed Order Successfully
                                                    /// </summary>
                                                    Inputhandler.PlaceOrder(order, context);
                                                    nextMenu = false;
                                                    Console.WriteLine("Order successfully created! Thank you for your business!\nReturning back to customer menue");
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("Unable to perform the operation: \n" + e);
                                                    Log.Error("Exception Error");
                                                }
                                            }

                                        }
                                        else if (userInput == "2")
                                        {
                                            Console.WriteLine("Please make a new order again");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input, please type one of the following options.");
                                            Log.Error("Null Value");
                                        }

                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Please Enter NUMBER ONLY.");
                                        Log.Error("Non Numerical Error");
                                    }


                                }
                                nextMenu = true;
                                break;

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error finding store with input ID: \n");
                            }
                        }
                        break;
                    /// <summary>
                    /// Display Order History of The customer
                    /// </summary>
                    case "2":

                        var enityOrder = context.Orders.Where(user => user.CustomerId == getCustomer.customerId).ToList();
                        string storeInfo;
                        foreach (var row in enityOrder)
                        {
                            if (row.StoreId == 1)
                            {
                                storeInfo = "Arlington,TX";
                            }
                            else
                            {
                                storeInfo = "Houston, TX";
                            }
                            Console.WriteLine("Your Order Id: {0} Store Location:  {1}", row.OrderId, storeInfo);
                            Console.WriteLine("Ariel: {0}, \nDownie: {1} \nSuavitel: {2}", row.Ariel, row.Downie, row.Suavitel);
                            Console.WriteLine();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("See You Later");
                        Environment.Exit(0);
                        break;
                    default:
                        //error handling
                        Log.Error("Invalid Input");
                        break;
                }
            }
        }

        public static void ManagerMenu(StoreAppContext context, int manager)
        {
            Logic.Customer newCust = new Logic.Customer();
            GetDataHandler getDBHandler = new GetDataHandler();
            InputDBHandler Inputhandler = new InputDBHandler();

            Logic.Customer getCustomer = new Logic.Customer();
            Logic.Store getStore = new Logic.Store();
            Logic.Order order = new Logic.Order();
            Logic.Product items = new Logic.Product();
            List<Order> orderList = new List<Order>();

            bool managerMenu = true;
            bool nextMenu = false;
            while (managerMenu)
            {
                switch (manager)
                {
                    /// <summary>
                    /// View Orders History of A Store 
                    /// </summary>
                    
                    case 1:
                        Console.WriteLine("Please Choose A Store:");
                        Console.WriteLine("1. Arlington,TX\n5. Houston,TX\n3. Exit");
                        int storeId = Int32.Parse(Console.ReadLine());

                        if (storeId == 3)
                        {
                            Console.WriteLine("Manager's Options:");
                            Console.WriteLine("1. View Order History Of A Store\n2. Add New Items To Stores\n3. Switch To Customer Menu \n4. Stop");
                            manager = Int32.Parse(Console.ReadLine());
                        }

                        nextMenu = true;
                        while (nextMenu)
                        {
                            try
                            {
                                getStore = getDBHandler.GetStoreFromStoreId(storeId, context);
                                Console.WriteLine("Store Address {0}, {1}, {2}, {3}", getStore.address.street, getStore.address.city, getStore.address.state, getStore.address.zip);
                                Console.WriteLine("Ariel: {0}, Downie: {1}, Suavitel: {2}", getStore.storeInventory.items.NumberofAriel, getStore.storeInventory.items.NumberofDownie, getStore.storeInventory.items.NumberofSuavitel);
                                var enityOrder = context.Orders.Where(order => order.StoreId == storeId).ToList();
                                foreach (var row in enityOrder)
                                {
                                    var cust = getDBHandler.GetCustomerDataFromID(row.CustomerId,context);

                                    Console.WriteLine("------------------------------------------------------------");
                                    Console.WriteLine("Order Id: {0} \nCustomer Id: {1}", row.OrderId, row.CustomerId);
                                    Console.WriteLine("Customer Name: "+ cust.firstName +" " +cust.lastName);
                                    Console.WriteLine("Ariel: {0}, \nDownie: {1} \nSuavitel: {2}", row.Ariel, row.Downie, row.Suavitel);
                                    Console.WriteLine();
                                }

                                nextMenu = false;
                                Console.WriteLine("Manager's Options:");
                                Console.WriteLine("1. View Order History Of A Store\n2. Add New Items To Stores\n3. Search User Information By Name \n4. Exit Main Menu \n5.Stop");
                                manager = Int32.Parse(Console.ReadLine());

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error finding store with input store");
                                //error handling
                                Log.Warning("Invalid Store ID");
                                break;
                            }
                        }
                        break;

                    /// <summary>
                    /// Add new Items
                    /// </summary>

                    case 2:
                        Console.WriteLine("Please Choose A Store:");
                        Console.WriteLine("1. Arlington,TX\n5. Houston,TX\n3. Exit");
                        storeId = Int32.Parse(Console.ReadLine());
                        if (storeId == 3)
                        {
                            Console.WriteLine("Manager's Options:");
                                Console.WriteLine("1. View Order History Of A Store\n2. Add New Items To Stores\n3. Search User Information By Name \n4. Switch To Customer \n5.Stop");
                            manager = Int32.Parse(Console.ReadLine());
                        }

                        try
                        {
                            getStore = getDBHandler.GetStoreFromStoreId(storeId, context);
                            Console.WriteLine("Store Address {0}, {1}, {2}, {3}", getStore.address.street, getStore.address.city, getStore.address.state, getStore.address.zip);
                            Console.WriteLine("Inventory:\nAriel: {0}, Downie: {1}, Suavitel: {2}", getStore.storeInventory.items.NumberofAriel, getStore.storeInventory.items.NumberofDownie, getStore.storeInventory.items.NumberofSuavitel);

                            bool decided = false;
                            int ariel;
                            int downie;
                            int suavitel;

                            while (!decided)
                            {
                                try
                                {
                                    Console.WriteLine("Ariel:");
                                    string input = Console.ReadLine();
                                    ariel = Int32.Parse(input);
                                    Console.WriteLine("Downie:");
                                    input = Console.ReadLine();
                                    downie = Int32.Parse(input);
                                    Console.WriteLine("Suavitels");
                                    input = Console.ReadLine();
                                    suavitel = Int32.Parse(input);


                                    Console.WriteLine("You added number of Ariel: {0} || Downie: {1} || Suavitel: {2}",
                                     ariel, downie, suavitel);
                                    Console.WriteLine("Ready To Add New Item? \n1.Yes 2.No");
                                    string userInput = UserChoiceHandler.UserOptionHandler(Int32.Parse(Console.ReadLine()), 2);

                                    if (userInput == "1")
                                    {
                                        decided = true;
                                        Console.WriteLine(". . .\n");


                                        {
                                            order = new Logic.Order();
                                            //uses input handler to input order into DB
                                            var entityStore = context.Store.FirstOrDefault(i => i.StoreId == storeId);



                                            entityStore.Ariel += ariel;
                                            entityStore.Downie += downie;
                                            entityStore.Suavitel += suavitel;


                                            context.Store.Update(entityStore);
                                            context.SaveChanges();
                                            try
                                            {
                                                nextMenu = false;
                                                Console.WriteLine("Added New Items Successfully!!!");
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Unable to perform the operation: \n" + e);
                                                //error handling
                                                Log.Error("Unknown Error");
                                            }
                                        }

                                    }
                                    else if (userInput == "2")
                                    {
                                        Console.WriteLine("Please Enter The Amount of Items Again!!!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input, please type one of the following options.");
                                        //error handling
                                        Log.Debug("Invalid Input");
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Error! Please Try It Again");
                                }
                            }
                            nextMenu = true;
                            break;

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error finding store with input ID" + e.Message);
                            break;
                        }
                    /// <summary>
                    /// Search Customer By Name
                    /// </summary>
                    case 3:
                        Console.WriteLine("Enter First Name or Last Name To Search Information: ");
                        string name = Console.ReadLine();

                        nextMenu = true;
                        while (nextMenu)
                        {
                            try
                            {
                                getCustomer = getDBHandler.GetCustomerDataByName(name, context);

                                var entityCustomer = context.Customer.FirstOrDefault(cust => cust.LastName == name || cust.FirstName == name);
                                if(getCustomer != null)
                                {
                                    Console.WriteLine("------------------------------------------------------------");
                                    Console.WriteLine("Customer Id: {0} \nCustomer username: {1}", getCustomer.customerId, getCustomer.userName);
                                    Console.WriteLine("Name: {0} {1}", getCustomer.firstName, getCustomer.lastName);
                                    Console.WriteLine("Address");
                                    Console.WriteLine("{0}, {1}, {2}, {3}", getCustomer.customerAddress.street, getCustomer.customerAddress.city, getCustomer.customerAddress.state.ToUpper(), getCustomer.customerAddress.zip);
                                    Console.WriteLine();
                                }
                                if(getCustomer is null)
                                {
                                    Console.WriteLine("No Customer Information");
                                    
                                }
                                
                                nextMenu = false;
                                Console.WriteLine("Manager's Options:");
                                Console.WriteLine("1. View Order History Of A Store\n2. Add New Items To Stores\n3. Search User Information By Name \n4. Switch To Customer Menu \n5.Stop");
                                manager = Int32.Parse(Console.ReadLine());

                            }
                            catch (Exception e) 
                            {
                                Console.WriteLine("Error! Invalid Input. Please enter name of customer only"+ e.Message);
                                break;

                            }
                            
                        }
                            break;
                    case 4:
                        Console.Clear();
                        //Move To Customer's Menu
                        Console.WriteLine("1. Sign Up  \n2. Login \n3. Stop");
                        string userChoice = Console.ReadLine();
                        string customerChoice = UserChoiceHandler.UserOptionHandler(Int32.Parse(userChoice), 4);

                        if (userChoice == "3")
                        {
                            Console.Clear();
                            Console.WriteLine("See You Later");
                            Environment.Exit(0);
                        }
                        else if (userChoice == "1" || userChoice == "2")
                        {
                            Menu.CustomerMenu(context, Int32.Parse(userChoice));
                        }
                        else //Invalid input
                        {
                            Console.WriteLine("Invalid input, please type one of the following options");
                            //error handling
                            Log.Error("Invalid Input");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Bye");
                        Environment.Exit(0);
                        break;
                    default:
                        //error handling
                        Log.Error("Invalid Input");
                        break;
                }

            }
        }
    }
}

