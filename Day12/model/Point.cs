namespace Day12.Model;

public class Point
{
    public int Height { get; }
    public List<Point> Visitable { get; } = new List<Point>();
    public int Visits { get; set; } = 0;

    public Point(char elevation)
    {
        Height = _elevationLookup[elevation];
    }

    private static Dictionary<char, int> _elevationLookup =>
    "SabcdefghijklmnopqrstuvwxyzE"
        .ToCharArray()
        .Select((ch, i) => (ch, i))
        .ToDictionary(x => x.ch, x => x.i);

    public static int LowestElevation => _elevationLookup.First().Value;
    public static int HighestElevation => _elevationLookup.Last().Value;
    public static int ElevationOf(char elevation) => _elevationLookup[elevation];
}