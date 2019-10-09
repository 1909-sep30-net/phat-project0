using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using StoreApp.Library;
using Newtonsoft.Json;

namespace StoreApp.App
{
    
    public class User
    {
        //Customer's Menu
        public static void AddNewCustomer(string jsonFilePath)
        {
            Console.Clear();
            Customer newCustomer = new Customer();
            string firstName; 
            string lastName;
            string storeNum;
          
            Console.WriteLine("Please Choose A Store: 1.Arlington,TX   2. Houston,TX");
            storeNum = Console.ReadLine();
            Console.WriteLine("Please Enter Your First Name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Please Enter Your Last Name");
            lastName = Console.ReadLine();

            if(Int32.Parse(storeNum) == 1)
            {
                newCustomer.Store = "Arlington,TX";
            }
            else if(Int32.Parse(storeNum) == 2)
            {
                newCustomer.Store = "Houston,TX";
            }
            else 
            {
                newCustomer.Store = "Arlington,TX";
            }
        
            newCustomer.FirstName = firstName;
            newCustomer.LastName = lastName;
            newCustomer.Id += 1; 


            SaveCustomer(newCustomer, jsonFilePath);

            Console.WriteLine("New Customer {0} {1}", newCustomer.FirstName, newCustomer.LastName + " Has Been Added");
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();            
        }

       
        public static void PlaceAnOrder()
        {

        }

        public static void DisplayCustomers(string jsonFilePath)
        {
            List<Customer> data = new List<Customer>();
            if (File.Exists(jsonFilePath))
            {
                Console.Clear();
                string store;
                data = DeserializeJsonFromFile(jsonFilePath);

                Console.WriteLine("Please Choose A Store: Arlington,TX   Houston,TX");
                store = Console.ReadLine();
                Console.WriteLine("List Of Customer:");

                foreach (Customer v in data)
                {
  
                    if (v.Store == store)
                    {
                        Console.WriteLine(" {0} {1}", v.FirstName, v.LastName);
                    }

                }
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No Customer Added");
                Console.ReadKey();
            }

        }

        public static void SearchCustomerByName(string jsonFilePath)
        {
            List<Customer> data = new List<Customer>();
            if (File.Exists(jsonFilePath))
            {
                data = DeserializeJsonFromFile(jsonFilePath);

                Console.Clear();
                string store;

                Console.WriteLine("Please Choose A Store: Arlington,TX   Houston,TX");
                store = Console.ReadLine();
                Console.WriteLine("Please Enter Any First Name or Last Name To Search: ");
                string name = Console.ReadLine();
               

                
                foreach (Customer v in data)
                {
  
                    if (v.Store == store)
                    {
                        if (v.FirstName.ToLower() == name.ToLower() || v.LastName.ToLower() == name.ToLower())
                        {
                            Console.WriteLine("Customer Found: ");
                            Console.WriteLine(" {0} {1}", v.FirstName, v.LastName);
                        }

                        else
                        {
                            Console.WriteLine("Not Found");
                        }
                            
                    }

                }
                Console.WriteLine("Press Any Key To Continue");
                Console.ReadKey();
            }
           
        }
        public static List<Customer> DeserializeJsonFromFile(string jsonFilePath)
        {
            string json = File.ReadAllText(jsonFilePath);

            var data = JsonConvert.DeserializeObject<List<Customer>>(json);

            return data;
        }

        public static void SaveCustomer(Customer customerToSave, string jsonFilePath)
        {
            List<Customer> data = new List<Customer>();

            if (!File.Exists(jsonFilePath))
            {
                data.Add(customerToSave);

            }
            else
            {
                data.AddRange(DeserializeJsonFromFile(jsonFilePath));
                data.Add(customerToSave);
            }
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(jsonFilePath,json);
        }
    }
}
