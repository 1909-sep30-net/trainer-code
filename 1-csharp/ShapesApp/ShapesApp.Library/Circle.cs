using System;

namespace ShapesApp.Library
{
    public class Circle : IShape
    {
        // constructor
        public Circle(double radius)
        {
            Radius = radius;
            // now there can't be a circle without setting the radius
        }

        public int Dimensions => 2;
        public int Sides => 0;

        public double Area => Math.PI * Radius * Radius;

        public double Radius { get; set; }

        // "expression-body syntax" for methods
        // just a shorter way to write a one-line method with a return.
        public virtual double GetPerimeter() => 2 * Math.PI * Radius;

        // non0virtual methods cannot be overridden
    }
}
