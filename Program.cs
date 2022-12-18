﻿using System;
using GraphiCS;
class Program
{
    static void Main(string[] args)
    {
        // Makes window with width and height and background colour
        Window testWindow = new Window(500,500,Colour.White);
        // Array of points for shape
        (float, float)[] points1 = {(20,10), (100,10),(50,50)};
        (float, float)[] points2 = {(20,30), (100,10),(50,50)};
        // Makes shapes
        NGon testShape = new NGon(points1, Colour.Blue);
        NGon testShape2 = new NGon(points2,Colour.Red);
        // Add shape to screen
        testShape.Add(testWindow);
        testShape2.Add(testWindow);
        // Show screen
        testWindow.Show();
    }
}