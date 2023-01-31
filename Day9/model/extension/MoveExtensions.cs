
namespace Day9.Model.Extensions;

public static class MoveExtensions
{
    public static IEnumerable<Move> ToMoves(this IEnumerable<string> lines) => lines.Select(ToMove);

    public static Move ToMove(this string line)
    {
        var lineParts = line.Split(" ");

        return new Move(lineParts.First().ToDirection(), int.Parse(lineParts.Last()));
    }

    private static Direction ToDirection(this string direction) => direction switch {
        "U" => Direction.Up,
        "R" => Direction.Right,
        "D" => Direction.Down,
        "L" => Direction.Left,
        _ => throw new ArgumentOutOfRangeException("not a valid direction")
    };
}