namespace GraphiCS;

public readonly struct Vector2 : IEquatable<Vector2>
{
    //X Component
    public readonly float X;
    //Y Component
    public readonly float Y;
    //Magnitude of Direction Vector
    public float Magnitude => MathF.Sqrt(X*X + Y*Y);

    public Vector2(float x, float y){
        X = x;
        Y = y;
    }
    //Implements IEquatable Equals method

    public bool Equals(Vector2 other)
    {
        return ( X == other.X && Y == other.Y );
    }
    //Gets the distance between two position vectors
    public static float Distance(Vector2 vector1, Vector2 vector2)
    {
        float XDif = vector1.X - vector2.X;
        float YDif = vector1.Y - vector2.Y;
        return MathF.Sqrt(XDif*XDif + YDif*YDif);
    }
    //Component wise vector operations
    public static Vector2 operator +(Vector2 first, Vector2 other)
    {
        return new Vector2(first.X + other.X, first.Y + other.Y);
    }
    public static Vector2 operator -(Vector2 first, Vector2 other)
    {
        return new Vector2(first.X - other.X, first.Y - other.Y);
    }
    public static Vector2 operator *(Vector2 first, Vector2 other)
    {
        return new Vector2(first.X * other.X, first.Y * other.Y);
    }
    public static Vector2 operator /(Vector2 first, Vector2 other)
    {
        return new Vector2(first.X / other.X, first.Y / other.Y);
    }
}