using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library.Handlers
{
    public class UserChoiceHandler
    {
        public static string UserOptionHandler(int input, int opt)
        {
            bool flag = false;
            int userInput = input;

            while (flag == false)
            {
                if (input.ToString() == null)
                {
                    Console.WriteLine("Invalid Input. Your Input cannot Be NULL");
                    return null;
                }
                else
                {
                    foreach (char c in input.ToString())
                    {
                        if (c < '0' || c > '9')
                        {
                            Console.WriteLine("Invalid input. Only insert a number option\n");
                            return null;
                        }
                        else
                        {

                            if (userInput > opt)
                            {
                                Console.WriteLine("Invalid input. Insert correct number from the following list\n");
                                return null;
                            }
                            else
                            {
                                return input.ToString();
                            }
                        }
                    }
                }
            }

            return input.ToString();
        }

    }
}
