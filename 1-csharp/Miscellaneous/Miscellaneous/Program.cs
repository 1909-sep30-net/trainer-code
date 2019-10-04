using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Miscellaneous
{
    class Program
    {
        static void Main(string[] args)
        {
            // some shortcuts for VS...
            //  - Ctrl + K, Ctrl + C comments lines
            //  - Ctrl + K, Ctrl + U uncomments lines
            //  - Ctrl + K, Ctrl + D format document 
            //  - Ctrl + Shift + B builds the solution
            //  - F5 runs with debugging (play button)
            //  - Ctrl + F5 runs without debugging
            //  - <snippet name><TAB><TAB> for snippets like "prop" for property
            //      - <TAB> to navigate betwen the fields of that snippet
            //  - Ctrl+. for accessing that light bulb

            // but in VS code...
            //  - Ctrl+/ for comment and uncomment
            //  - Alt+Shift+F for format document

            // --------------------

            // casting / type conversion

            // among numeric types, conversions that could lose any data
            //   must be explicit with casting operator ()
            // otherwise they can be implicit.
            // with these numeric conversions, the actual bytes are being changed

            int five = 5;
            double otherFive = five;
            int nextFive = (int)otherFive;

            // conversions when type heirarchies are concerned
            var list = new List<int>();
            object o = list; // implicit upcasting
            List<int> listAgain = (List<int>)o; // explicit downcasting
                                                // "could fail" - InvalidCastException if that object is not already really a List<int>
            IList<int> iList = list;
            PrintList(list); // implicit upcasting
            PrintList((IList<int>)o); // downcasting

            //AddSomeItemToList(new List<X>()); // violates new() constraint
        }

        // generic type params can have constraints
        // for example, required to be reference type and have a zero-param constructor
        static void AddSomeItemToList<T>(IList<T> list) where T : class, new()
        {
            list.Add(new T());
            // other constraints include - struct, [any actual type]
        }

        // this is an example of a custom generic method
        //           declaring type param
        //                    |      using the declared parameter
        //                    v       v
        static void PrintList<T>(IList<T> list)
        {
            // we can use operators like is and as
            if (list is List<T> concrete) // "safe" downcasting - does a null check also
            {
                // unless well thought out, code that does downcasting might be breaking
                // Liskov substitution principle
                Console.WriteLine("it's a concrete List<T>");
            }

            var x = list as IImmutableList<T>;
            // this is also a safe cast - it will be null if the cast doesn't work.

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            var num1 = 4;
            var num2 = 8;
            Swap(ref num1, ref num2);
            // now num1 contains 8, and num2 4.
        }

        // ref params are like out params, but more flexible and less performant
        // ref params are the closest thing short of pointer to pointers

        // a method to swap the values of two variables

            // with out, you can't send data into the method, only receive a value out of it
            // with ref, you can send data in and get it sent back out
        static void Swap<T>(ref T one, ref T two)
        {
            T swap = one;
            one = two;
            two = swap;
        }
        // when declaring type parameters, if there's only one
        // we almost always call it T.
        // if there are multiple, we have two different conventions
        // - T, U, V, etc.
        // - TKey, TSource, TTarget
    }

    class X
    {
        public int Id { get; set; }

        public X(int id)
        {
            Id = id;
        }
    }
}
