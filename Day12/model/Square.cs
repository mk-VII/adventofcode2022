namespace Day12.Model;

public class Square
{
    public int X { get; }
    public int Y { get; }
    public char Elevation { get; }

    public Square(int x, int y, char elevation)
    {
        X = x;
        Y = y;
        Elevation = elevation;
    }

    public static Dictionary<char, int> ElevationLookup =>
        "SabcdefghijklmnopqrstuvwxyzE"
            .ToCharArray()
            .Select((ch, i) => (ch, i))
            .ToDictionary(x => x.ch, x => x.i);
}