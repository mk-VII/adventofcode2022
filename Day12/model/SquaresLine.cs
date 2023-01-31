namespace Day12.Model;

public class SquaresLine
{
    public Square[] Squares { get; }

    public SquaresLine(IEnumerable<Square> squares)
    {
        Squares = squares.ToArray();
    }
}