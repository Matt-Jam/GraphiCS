namespace GraphiCS;

public class Window
{
    //Dimensions of window
    public readonly uint WindowWidth;
    public readonly uint WindowHeight;
    //Colour of window
    public readonly Colour BackgroundColour;
    // Image
    private readonly Bitmap BitmapImage;
    // Constructor that takes width, height and background colour
    public Window(uint windowWidth, uint windowHeight, Colour backgroundColour)
    {
        WindowWidth = windowWidth;
        WindowHeight = windowHeight;
        BackgroundColour = backgroundColour;
        BitmapImage = new Bitmap((Int32)WindowWidth, (Int32)WindowHeight);
        Clear();

    }
    //Clears the window and fills it with the background colour
    public void Clear()
    {
        for (int x = 0; x<WindowWidth;x++) 
        {
            for (int y = 0; y<WindowHeight;y++) 
            {
                BitmapImage.SetPixel(x,y,BackgroundColour);
            }
        }
    }
    // Assuming points are in range, set colours of pixel in screen
    public void SetPixel(int x,int y,Colour colour)
    {   
        if (0 <= x && x < WindowWidth)
        {
            if (0 <= y && y < WindowHeight)
            {
                BitmapImage.SetPixel(x, y, colour);
            }
        }
    }
    // Creates bitmap images
    public void Show()
    {
        BitmapImage.Save("test.bmp");
    }

}