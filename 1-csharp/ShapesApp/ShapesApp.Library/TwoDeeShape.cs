namespace ShapesApp.Library
{
    public abstract class TwoDeeShape : IShape
    {
        // int IShape2.Dimensions => 3; // "explicit interface implementation"
        public int Dimensions => 2;

        // in an abstract class, you don't have to provide
        // implmentations for *everything*
        // abstract members (properties, methods, etc)
            // have no implementations, but the child class
            // does have to implement them.

        public abstract int Sides { get; }
        public abstract double Area { get; }

        public abstract double GetPerimeter();
    }
}
