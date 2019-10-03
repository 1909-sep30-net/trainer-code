using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var movie = "Frozen";

            var moviePlayer = new MoviePlayer { CurrentMovie = movie };

            // this implicit conversion works because the method has the right shape.
            MoviePlayer.MovieFinishedHandler handler = PrintMovieOver; // referencing the method, not calling

            //moviePlayer.MovieFinished += handler; // subscribe with +=
            //moviePlayer.MovieFinished -= handler; // unsubscribe with -=

            moviePlayer.MovieFinished += PrintWhichMovieOver;

            moviePlayer.PlayMovie();
        }

        static void FuncAndAction()
        {
            Action<string> function = PrintWhichMovieOver;
            function("");

            // a function that takes an int and a string as params and returns void
            Action<int, string> x;

            // a function that takes a int and returns a string
            Func<int, string> y;
        }

        static void LambdaExpression()
        {
            Action x = () => Console.WriteLine("Movie finished");

            // the function to add two numbers
            Func<int, int, int> add = (a, b) => a + b;

            var five = add(2, 3); // it's 5

            // language feature / library called LINQ
            // "Language-Integrated Query"
            // two syntaxes - "method syntax" and "query syntax"
            // (both need a using directive for System.Linq namespace)

            var data = new List<string> { "a", "aaa", "nick", "asdf" };

            //var firstCharactersLongerThanThree = from str in data
            //                                     where str.Length > 3
            //                                     select str[0]; // returns a sequence ['n', 'a']
            var firsts = data.Where(s => s.Length > 3).Select(s => s[0]); // does the same thing in method syntax

            // LINQ is a bunch of extension methods on IEnumerable aka almost any sequence/collection type in C#.

            // the total number of characters in all the strings
            data.Sum(s => s.Length);

            // Where will filter the sequence and leave out the ones that don't match some condition
            // Select will transform each element into something else

            // nothing in LINQ modifies the original collection or any elements in it
            // it always produces a new collection

            // three kinds of LINQ methods:
            // 1. those that return single values. those "execute" right away.
            //     e.g. First, Sum, Average, Single...
            // 2. those that return IEnumerable (some sequence).
            //        those use "deferred execution" - doesn't execute the operations until you extract an
            //        actual value
            //    e.g. Select, Where, Take, Skip, GroupBy, OrderBy
            // 3. stuff like ToList, ToArray. those "force" the execution right there, rather than deferred.

            //foreach (char c in firsts) // the filtering, etc doesn't run up there, it runs right here
            //{
            //    if
            //           return false;
            //}

            // LINQ is not JUST that... LINQ can also be converted to SQL, other kinds of data sources
            //data.
        }

        static void PrintMovieOver()
        {
            Console.WriteLine("Movie finished");
        }

        static void PrintWhichMovieOver(string name)
        {
            Console.WriteLine($"Movie {name} finished");
        }
    }
}
