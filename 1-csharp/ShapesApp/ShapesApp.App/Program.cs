using System;
using ShapesApp.Library;

namespace ShapesApp.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            double length;
            string input;
            do
            {
                Console.WriteLine("Enter a length:");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out length));
            double width;
            do
            {
                Console.WriteLine("Enter a width:");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out width));

            // C# has something called "out" parameters
            // an out parameter cannot have a value before you pass it
            // the method gets that exact variable and fills in its value

            // similar to collection initializer, we have property initializer

            var rectangle = new Rectangle
            {
                Length = length,
                Width = width
            };

            // PrintRectangle(rectangle);
            rectangle.PrintRectangle();

            double radius;
            do
            {
                Console.WriteLine("Enter a radius:");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out radius));

            ColorCircle colorCircle = new ColorCircle(radius: radius, color: "black");

            Console.WriteLine(colorCircle.GetPerimeter());

            Console.WriteLine(ShapeDetails(colorCircle));
        }

        // extension method
        // this are used very frequently with a library called LINQ
        public static void PrintRectangle(this Rectangle r)
        {
            Console.WriteLine($"{r.Length}x{r.Width} rectangle ({ShapeDetails(r)})");
            10.ToString();
            int thirtythree = 10.Triple(3);
        }

        public static string ShapeDetails(IShape shape)
        {
            return $"area {shape.Area}, perimeter {shape.GetPerimeter()}, {shape.Sides}";
        }

        public static int Triple(this int number, int plus = 0)
        {
            return 3 * number + plus;
        }

        // we're not using this method, but if we didn't have double.TryParse,
        // this is how we would write it.
        static bool TryParse(string input, out double result)
        {
            try
            {
                result = double.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                result = 0;
                return false;
            }
        }
    }
}
