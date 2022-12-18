namespace GraphiCS;

public abstract class Shape
{
    //Each shape must have a colour
    public Colour Colour;
    //Each shape must be showable
    public abstract void Add(Window window);
    //Each shape must have a bounding box
    public abstract (Vector2 Min, Vector2 Max) GetBoundingBox();
    //Bounding Box for a shape
    protected (Vector2 Min, Vector2 Max) BoundingBox;
    //Constructor to set colour
    public Shape(Colour colour){
        Colour = colour;   
    }
}

