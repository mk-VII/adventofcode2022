namespace Day15.Model;

public record struct Point(int X, int Y)
{
    public int ManhattanDistance(Point other) =>
        Math.Abs(X - other.X) + Math.Abs(Y - other.Y);

    public int TuningFrequency => X * 4000000 + Y;
}