using System;
using System.Collections.Generic;

namespace CSharpIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // make bool, string, and int variables (with values)

            // variable: a container for a value of some type

            // change their values to something else
            bool atWork = true;
            atWork = false;
            string name = "Fred";
            name = "Nick";
            int associates = 26;
            associates = 25;

            // types for whole numbers
            // byte, short, int, long
            // 1-byte, 2-byte, 4-byte, 8-byte

            // types for fractional numbers
            // float, double, decimal
            // 4-byte, 8-byte, 16-byte
            // 12341273.23
            // 0.00000123124

            // print their values with Console
            // "Intellisense"
            Console.WriteLine(atWork);
            Console.WriteLine(name);
            Console.WriteLine(associates);

            // do something in a for loop
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            // do something in a while loop
            atWork = true;
            while (atWork)
            {
                Console.WriteLine("work"); // ran once
                atWork = false;
            }
            // do-while loops too
            // do something with a switch statement
            switch (name)
            {
                case "Fred":
                    Console.WriteLine("hi fred");
                    break;
                case "Nick":
                    Console.WriteLine("hi me");
                    break;
                default:
                    Console.WriteLine("i don't know you");
                    break;
            }

            // switch expression
            int number = associates switch
            {
                0 => 23,
                _ => 46 // _ means default pretty much
            };

            // do something with if, else if, else
            if (1 == 2)
            {
                Console.WriteLine("chaos"); // if first condition matched
            }
            else if (1 == 3)
            {
                int num = 4; // if 2nd matched but first didn't
            }
            else
            {
                Console.WriteLine("sanity"); // if neither matched
            }

            // figure out how to make multi-line comments in C#

            /*
             multiline

                comments
             */

            // figure out how to format your document in VS Code
            // format document with alt+shift+f

            // extra: make a new static method to do something and call it
            Console.WriteLine(Quote("ASDF"));

            // extra: learn what "var" means in C# and try it out.
            var a = 15;
            var b = "asdf";

            // a = "string";
            // var variable; // doesn't make sense, it can't tell what the "var" should mean
            var list = new List<int>();
        }

        static string Quote(string s)
        {
            // return a version of that string with quotes around it and lowercase
            // return "\"" + s.ToLower() + "\"";
            //
            // string interpolation syntax
            return $"\"{s.ToLower()}\"";
        }
    }
}
