namespace GraphiCS;

public class Line : Shape
{
    // Start point of line
    public Vector2 StartPoint;
    // End point of line
    public Vector2 EndPoint;

    // Contructor using Vector2s
    public Line(Vector2 startPoint, Vector2 endPoint, Colour colour) : base(colour)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }
    // Contructor using tuples
    public Line((float x, float y) startPoint, (float x, float y) endPoint, Colour colour) : base(colour)
    {
        StartPoint = new Vector2(startPoint.x, startPoint.y);
        EndPoint = new Vector2(endPoint.x, endPoint.y);
    }

    public override void Add(Window window)
    {
        // Generating the points actually on the line, alligned to the integer pixel grid
        // results in a clearly dotted line for lines with gradients of large magnitude
        // so instead this draws all a continous line via drawing verical lines for each 
        // jump of 1 in the x direction
        float xDif = EndPoint.X - StartPoint.X;
        float yDif = EndPoint.Y - StartPoint.Y;
        float gradient = yDif/xDif;
        
        for (float x = 0; x < xDif; x++)
        {
            for (int y = 0; y <= (int)gradient; y++)
            {
                window.SetPixel((int)(StartPoint.X + x), (int)(StartPoint.Y + gradient * x + y),Colour);
            }
        }
        
    }

    public override (Vector2 Min, Vector2 Max) GetBoundingBox()
    {
        if (StartPoint.Magnitude < EndPoint.Magnitude)
        {
            return (Min:StartPoint,Max:EndPoint);
        }
        return (Min:EndPoint,Max:StartPoint);
    }
}