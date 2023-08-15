namespace MazeGenerator;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public Point(int x = 0, int y = 0, int z = 0)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Point operator *(Point p, int n)
    {
        return new Point(p.X * n, p.Y * n, p.Z * n);
    }
    
    public override string ToString()
    {
        return $"{{{X}; {Y}; {Z}}}";
    }
}