using System;
using GraphiCS;
class Program
{
    static void Main(string[] args)
    {
        // Makes window with width and height and background colour
        Window testWindow = new Window(500,500,Colour.White);
        // Array of points for shape
        (float, float)[] points = {(20,10), (100,10)};
        // Makes shapes
        NGon testShape = new NGon(points, Colour.Blue);
        // Add shape to screen
        testShape.Show(testWindow);
        // Show screen
        testWindow.Show();
    }
}