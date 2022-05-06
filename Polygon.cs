namespace GraphiCS;
using static MathUtilities;
public abstract class Polygon : Shape
{
    //Constructor for polygon calls shape constructor to set color
    public Polygon(Colour colour) : base(colour)
    {
    }
    //Every polygon must have a method that returns a list of vertices in clockwise order
    public abstract List<Vector2> GetClockwisePoints();
    //Gets bounding box of a Polygon based on a list of vertices
    public override (Vector2 Min, Vector2 Max) GetBoundingBox()
    {
        List<Vector2> clockwisePoints = GetClockwisePoints();
        //Bounding box defined by
        //(Min(x),Min(y))
        //       +----------------------+
        //       |                      |
        //       |                      |
        //       |                      |
        //       |                      |
        //       +----------------------+
        //                       (Max(x),Max(y))
        float minX, maxX, minY, maxY;
        minX = maxX = clockwisePoints[0].X;
        minY = maxY = clockwisePoints[0].Y;
        for (int i = 1; i < clockwisePoints.Count; i++)
        {
            minX = Math.Min(minX, clockwisePoints[i].X);
            minY = Math.Min(minY, clockwisePoints[i].Y);
            maxX = Math.Max(maxX, clockwisePoints[i].X);
            maxY = Math.Max(maxY, clockwisePoints[i].Y);
        }
        Vector2 minVec = new Vector2(minX, minY);
        Vector2 maxVec = new Vector2(maxX, maxY);
        return (Min: minVec, Max: maxVec);
    }
    // Given the shape, rays are sent vertically downwards through each pixel on the 
    // top row of the bounding box. The intersections between these rays and the edges are calculated
    // points between pairs of intersections are inside the shape, and need to filled
    // an array of the intersections is returned
    public virtual List<List<int>> GetFillLines()
    {
        //List of intersections
        List<List<int>> Intersections = new List<List<int>>();
        // Coordinates of bounding box
        (Vector2 Min, Vector2 Max) BoundingBox = GetBoundingBox();
        // Length of bounding box
        float range = BoundingBox.Max.X - BoundingBox.Min.X;
        // Floored value for minimum x coord of bounding box - floored because it needs to be 
        // the index of a pixel
        int minX = (int)MathF.Floor(BoundingBox.Min.X);
        List<Vector2> edgeVertices = GetClockwisePoints();
        // Number of vertices
        int edges = edgeVertices.Count;
        // Creates a loop, such that each edge can be calculated by using a value and the next one in the list
        edgeVertices.Add(edgeVertices[0]);
        // For each x value in the bounding box
        for (int p = 0; p < range; p++)
        {
            List<int> IntersectionsForCurrentX = new List<int>();
            int currentX = minX + p;
            for (int e = 0; e < edges; e++)
            {
                // Gets x values for verticles for edge for which intersection is being calculated
                int bound1 = (int)MathF.Floor(edgeVertices[e].X);
                int bound2 = (int)MathF.Floor(edgeVertices[e + 1].X);
                int minBound = Math.Min(bound1, bound2);
                int maxBound = Math.Max(bound1, bound2);
                if (minBound <= currentX && currentX <= maxBound)
                {
                    // Gets Y-value of intersection
                    int currentY = (int)lterp(edgeVertices[e], edgeVertices[e + 1], currentX);
                    IntersectionsForCurrentX.Add(currentY);
                }
            }
            // Add intersections for current X value to list
            Intersections.Add(IntersectionsForCurrentX);
        }
        return Intersections;
    }
    public sealed override void Show(Window window)
    {
        List<List<int>> Intersections = GetFillLines();
        (Vector2 Min, Vector2 Max) BoundingBox = GetBoundingBox();
        int minX = (int)MathF.Floor(BoundingBox.Min.X);
        //For each x value in the intersections list
        for (int i = 0; i < Intersections.Count; i++)
        {
            List<int> currentXList = Intersections[i];
            // For each Y value intersection for current x value, get pairs of intersections
            // Inbetween each pair, the pixels should be filled
            for (int k = 0; k < currentXList.Count; k = k + 2)
            {
                // Cathces index erros
                if (k + 1 < currentXList.Count)
                {
                    int yRange = Math.Abs(currentXList[k] - currentXList[k+1]);
                    // For each y value in range
                    for (int y = 0; y < yRange; y++)
                    {
                        // Fill in pixel with specified colours
                        window.SetPixel(minX + i, currentXList[k] + y, Colour);
                    }
                }

            }
        }
    }
}