// namespace GraphiCS;

// public class Rectangle : Polygon
// {
//     public readonly List<Vector2> Points;
//     // Private constructor that handles basic initialisation
//     public Rectangle((float X, float Y) topLeftCorner, float width, float height, Colour colour) : base(colour)
//     {
//         Points = new List<Vector2>();
//         float topLeftX = topLeftCorner.X;
//         float topleftY = topLeftCorner.Y;
//         // Top left corner
//         Points.Add(new Vector2(topLeftX, topleftY));
//         // Top right corner
//         Points.Add(new Vector2(topLeftX + width, topleftY));
//         // Bottom right corner
//         Points.Add(new Vector2(topLeftX + width, topleftY + height));
//         // Bottom left corner
//         Points.Add(new Vector2(topLeftX, topleftY + height));
//     }
//     public Rectangle(Vector2 topLeftCorner, float width, float height, Colour colour)
//     {
//         (float X, float Y) topLeftTuple = (topLeftCorner.X, topLeftCorner.Y);
//         return new Rectangle(topLeftCorner, width, height, colour);
//     }

// }