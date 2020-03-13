using System;

namespace InputExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int GetInputWithCheckingBeforehand()
        {
            int number;
            bool gotNumber = false;
            while (!gotNumber)
            {
                Console.Write("Enter a number: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    return number;
                }
            }
        }

        static int GetInputWithExceptions()
        {
            int number;
            bool gotNumber = false;
            while (!gotNumber)
            {
                Console.Write("Enter a number: ");
                string input = Console.ReadLine();
                try
                {
                    number = int.Parse(input);
                    gotNumber = true;
                }
                catch (FormatException)
                {
                }
            }
            return number;
        }
    }
}
