namespace GraphiCS;

public class NGon : Polygon
{
    // List of points in clockwise order
    public readonly List<Vector2> Points;
    // Constructor that takes a list of type Vector2
    public NGon(List<Vector2> points, Colour colour) : base(colour)
    {
        Points = points;
    }
    // Constructor that takes an array type Vector2
    public NGon(Vector2[] points, Colour colour) : base(colour)
    {
        Points = new List<Vector2>();
        for (int p = 0; p<points.Length; p++)
        {
            Points.Add(new Vector2(points[p].X,points[p].Y));
        }

    }
    // Constructor that takes a list of floats for X and Y positions
    public NGon(List<(float X, float Y)> points, Colour colour) : base(colour)
    {
        // Converts list of floats to list of Vector2
        Points = new List<Vector2>();
        for (int p = 0; p < points.Count; p++)
        {
            Points.Add(new Vector2(points[p].X, points[p].Y));
        }
    }
    // Constructor that takes array of tuples for X and Y positions
    public NGon((float X, float Y)[] points, Colour colour) : base(colour)
    {
        // Converts array of tuples to list of Vector2
        Points = new List<Vector2>();
        for (int p = 0; p < points.Length ;p++)
        {
            Points.Add(new Vector2(points[p].X,points[p].Y));
        }
    }
    // Returns list of points in clockwise order
    public override List<Vector2> GetClockwisePoints()
    {
        return Points;
    }
}