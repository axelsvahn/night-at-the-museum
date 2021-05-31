using System;

namespace museet
{   
   public static class ParseInput
    {
        ///<summary>
        ///Handles integer input from user using Int.TryParse()
        ///</summary>
        public static int ParseIntegerInput()
        {
            int input = 0;
            bool inputSuccess = false;
            while (!inputSuccess)
            {
                Console.Write("Var god skriv in ett heltal och tryck på enter:");
                inputSuccess = int.TryParse(Console.ReadLine(), out input);
                if (!inputSuccess)
                    System.Console.WriteLine("Du skrev inte ett heltal!");
            }
            return input;
        }
    }     
}
