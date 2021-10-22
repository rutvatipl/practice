using System;
struct Coordinate
{
    public int x;
    public int y;

    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
public class Program
{
    public static void Main()
    {
        Coordinate point = new Coordinate(10, 20);

        Console.WriteLine(point.x);
        Console.WriteLine(point.y);
    }
}