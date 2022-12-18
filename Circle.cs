namespace GraphiCS;

public class Circle : Shape
{
    // Center of circle
    public readonly Vector2 Center;
    // Radius of circle
    public readonly float Radius;
    // Constructor that takes a vector two and a float
    public Circle(Vector2 center, float radius, Colour colour) : base(colour)
    {
        Center = center;
        Radius = radius;
    }

    // Contructor that takes a tuple of floats for the point, and a float
    public Circle((float x, float y) center, float radius, Colour colour) : base(colour)
    {
        Center = new Vector2(center.x,center.y);
        Radius = radius;
    }
    //Returns axis alligned bounding box for circle
    public override (Vector2 Min, Vector2 Max) GetBoundingBox()
    {
        Vector2 minVec = new Vector2(Center.X - Radius, Center.Y - Radius);
        Vector2 maxVec = new Vector2(Center.X + Radius, Center.Y + Radius);
        return (Min: minVec, Max: maxVec);
    }

    public override void Add(Window window)
    {
        int flooredRad = (int)MathF.Floor(Radius);
        for (int x = -flooredRad; x < flooredRad + 1;x++)
        {
            int max_y = (int)MathF.Floor(MathF.Sqrt((flooredRad * flooredRad) - (x * x)));
            for (int y = -max_y; y < max_y + 1; y++)
            {
                window.SetPixel((int)Center.X + x, (int)Center.Y + y, Colour);
            }
        }
    }

}