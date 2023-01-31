namespace Day14.Model;

public static class ParserExtensions
{
    public static Point[][] ToPaths(this IEnumerable<string> lines) => lines
        .Select(line => line.ToPath())
        .ToArray();

    public static Point[] ToPath(this string line) => line
        .Split(" -> ")
        .Select(coordinate => coordinate
            .Split(",")
            .ToPoint())
        .ToArray();

    public static Point ToPoint(this string[] coordinateParts) => new Point(
        int.Parse(coordinateParts[0]),
        int.Parse(coordinateParts[1])
    );
}