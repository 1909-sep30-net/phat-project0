using System;
using StoreApp.Library;

namespace StoreApp.App
{
    class User
    {
        internal static void CustomerLogin()
        {
            Console.Clear();
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            // Customer user = new Customer
            // {
            //     firstName = username,
            //     lastName = password    
            // };

        }
    }
}