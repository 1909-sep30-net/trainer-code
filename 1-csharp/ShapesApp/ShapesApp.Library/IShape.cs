namespace ShapesApp.Library
{
    // an interface is a contract that classes can declare themselves
    // as following.
    public interface IShape
    {
        int Dimensions { get; }
        int Sides { get; }
        double Area { get; }

        double GetPerimeter();
    }
}
