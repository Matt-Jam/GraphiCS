namespace GraphiCS;

public class Line : Shape
{
    public Vector2 StartPoint;
    public Vector2 EndPoint;
    public Line(Vector2 startPoint, Vector2 endPoint, Colour colour) : base(colour)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }
    public Line((float x, float y) startPoint, (float x, float y) endPoint, Colour colour) : base(colour)
    {
        StartPoint = new Vector2(startPoint.x, startPoint.y);
        EndPoint = new Vector2(endPoint.x, endPoint.y);
    }

    public override void Add(Window window)
    {
        float xDif = EndPoint.X - StartPoint.X;
        float gradient = (EndPoint.Y - StartPoint.Y)/xDif;
        
        for (float x = 0; x < xDif; x++)
        {
            window.SetPixel((int)(StartPoint.X + x), (int)(StartPoint.Y + gradient * x), Colour);
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