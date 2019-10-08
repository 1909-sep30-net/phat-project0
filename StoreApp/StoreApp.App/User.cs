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
        
        public static void AddNewCustomer(string jsonFilePath)
        {
            Console.Clear();

            string firstName; 
            string lastName;

            Console.WriteLine("Please Enter Your First Name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Please Enter Your Last Name");
            lastName = Console.ReadLine();


            Customer newCustomer = new Customer();
            newCustomer.FirstName = firstName;
            newCustomer.LastName = lastName;
            newCustomer.Id += 1; 


            SaveCustomer(newCustomer, jsonFilePath);

            Console.WriteLine("New Customer {0} {1}", newCustomer.FirstName, newCustomer.LastName + " Has Been Added");
            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
            


            
        }

        public static void DisplayCustomers(string jsonFilePath)
        {
            List<Customer> data = new List<Customer>();
            if (File.Exists(jsonFilePath))
            {
                data = DeserializeJsonFromFile(jsonFilePath);
                Console.Clear();

                Console.WriteLine("List Of Customer:");

                for (int i = 0; i < data.Count; i++)
                {
                    Console.WriteLine(" {0} {1} {2}",data[i].Id, data[i].FirstName, data[i].LastName);
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
        public static void PlaceAnOrder()
        {

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
