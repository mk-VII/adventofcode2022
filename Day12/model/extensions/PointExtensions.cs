namespace Day12.Model.Extensions;

public static class PointExtensions
{
    public static Point[][] ToPoints(this IEnumerable<string> lines) => lines.Select(ToPoints).ToArray();

    public static Point[] ToPoints(this string line) => line.Select(ToPoint).ToArray();

    public static Point ToPoint(this char elevation) => new Point(elevation);
}