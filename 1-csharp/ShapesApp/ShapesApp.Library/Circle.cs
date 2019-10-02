using System;

namespace ShapesApp.Library
{
    public class Circle : IShape
    {
        public int Dimensions => 2;
        public int Sides => 0;

        public double Area => Math.PI * Radius * Radius;

        public double Radius { get; set; }

        // "expression-body syntax" for methods
        // just a shorter way to write a one-line method with a return.
        public double GetPerimeter() => 2 * Math.PI * Radius;
    }
}
