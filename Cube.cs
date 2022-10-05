using System;

public class Cube
{
    private float length;
    private float width;
    private float height;
    
    public Cube()
    {
        length = 0;
        width = 0;
        height = 0;
    }

    public void SetLength(float newLength)
    {
        length = newLength;
    }

    public void SetWidth(float newWidth)
    {
        width = newWidth;
    }

    public void SetHeight(float newHeight)
    {
        height = newHeight;
    }

    public float GetLength()
    {
        return length;
    }

    public float GetWidth()
    {
        return width;
    }

    public float GetHeight()
    {
        return height;
    }

    public float GetVolume()
    {
        return (length * width * height);
    }

    public float GetEdgeLength()
    {
        return ((length * 4) + (width * 4) + (height * 4));
    }
}
