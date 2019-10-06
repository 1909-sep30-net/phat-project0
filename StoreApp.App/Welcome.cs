using System;
using StoreApp.Library;
namespace StoreApp.App
{
    class Welcome
    {
        internal static void welcomePage()
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

        }


        internal static void requestHandler(int opt)
        {
            Console.Clear();
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

        static void CustomerDisplayMenu()
        {
            
            int customerChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Create A New Account");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("4. Choose Store");
                customerChoice = Int32.Parse(Console.ReadLine());
                if(customerChoice == 2)
                {
                   User.CustomerLogin();
                    
                }

            }
            while (customerChoice != 4);
        }

        static void ManagerDisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("1. View All Orders");
            Console.WriteLine("2. Display Stories");
            Console.WriteLine("3. Display Order History of a Store Location");
            Console.WriteLine("4. Display Order History of a Customer");
        }
    }
}
