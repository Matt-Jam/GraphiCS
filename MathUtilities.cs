namespace GraphiCS;
public static class MathUtilities
{
    // Linear interpolation between two points for a given x in that bound
    public static float lterp(Vector2 p0, Vector2 p1, float x)
    {
        return p0.Y + (x - p0.X) * (p1.Y - p0.Y) / (p1.X - p0.X);
        
    }
}