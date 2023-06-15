using System;
using GraphiCS;
class Program
{
    static void Main(string[] args)
    {
        // Makes window with width and height and background colour
        Window testWindow = new Window(500,500,Colour.White);
        // Array of points for shape
        (float, float)[] points1 = {(20,10), (100,10),(50,50)};
        (float, float)[] points2 = {((float)20.1,30), (100,10),(50,50)};
        // Makes shapes
        NGon testShape = new NGon(points1, Colour.Blue);
        testShape.Colour = Color.Green;
        NGon testShape2 = new NGon(points2,Colour.Red);
        Circle testCircle = new Circle((100,100),99,Color.Aqua);
        Line testLine = new Line((100,100),(300,400),Color.Pink);
        // Add shape to screen
        testShape.Add(testWindow);
        testShape2.Add(testWindow);
        testCircle.Add(testWindow);
        testLine.Add(testWindow);
        // Show screen
        testWindow.Show();
    }
}