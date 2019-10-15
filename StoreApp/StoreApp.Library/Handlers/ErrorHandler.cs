using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Library.Handlers
{
    public class ErrorHandler
    {
        public static bool ThrowAnError(int input, int maxNum)
        {
            try
            {
                string userChoice = UserChoiceHandler.UserOptionHandler(input, maxNum);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
