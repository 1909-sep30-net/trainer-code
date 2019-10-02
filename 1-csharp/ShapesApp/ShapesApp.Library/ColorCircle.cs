using System;

namespace ShapesApp.Library
{
    public class ColorCircle : Circle
    {
        // ctors are not inherited
        // every subclass constructor calls
        // some parent class constructor first.
        // by default, the zero-parameter one.

        public ColorCircle(double radius, string color) : base(radius)
        {
            Color = color;
        }

        public ColorCircle(double radius) : this(radius, "clear")
        {
        }

        public string Color { get; set; }


        // to override a method, you must use modifier "override".
        // this is not allowed if the existing implementation
        // is non-virtual.

        // method hiding is possible on non-virtual methods,
        // but you get a wanring unless you indicate that with the "new"
        // modifier
        public override double GetPerimeter()
        {
            Console.WriteLine("calculating perimeter");
            // return 2 * Math.PI * Radius;
            return base.GetPerimeter(); // uses base class implementation
        }
    }
}
