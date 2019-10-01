using System;

namespace DogApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog;
            try
            {
                // in the try block, you put the code that you think may throw an exception that you can handle here
                dog = new Dog(null, -5);

                // in C#, we have "block scope"
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("error, recovering out of range error");
                dog = new Dog("Spot", 5);
            }
            catch (ArgumentException ex)
            {
                // catch more-specific exception types before less-specific
                Console.WriteLine("error, recovering some argument error");
                dog = new Dog("Spot", 5);
            }
            string name = null;
            if (name != null)
            {
                dog.SetName(null);
                dog.Age = -4;
            }
        }
    }
}
