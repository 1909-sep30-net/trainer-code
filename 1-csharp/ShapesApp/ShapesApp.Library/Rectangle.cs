namespace ShapesApp.Library
{
    public class Rectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }

        // not all properties have to be based on 1 field
        // could be 0, 2, or more
        public double Area
        {
            get
            {
                return Length * Width;
            }
        }

        public int Dimensions
        {
            get { return 2; }
        }

        public bool Validate()
        {
            if (Length <= 0)
            {
                return false;
            }
            if (Width <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
