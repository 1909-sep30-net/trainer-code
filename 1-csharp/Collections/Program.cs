using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays();
        }

        static void Arrays()
        {
            // arrays are the most basic way
            // to group many values of the same type together
            int[] intArray = new int[4]; // all entries initialized to default 0
            // arrays are fixed-size from once they are created
            intArray[0] = 3;
            intArray[1] = 5;
            // now array looks like: 3, 5, 0, 0.

            // software called "debugger"
            // "breakpoint"

            // this type of syntax is called "collection initializer"
            int[] intArray2 = new int[] { 1, 2, 3, 4, 12 }; // inferred to be size 5
        }
    }
}
