namespace Day12.Model.Extensions;

public static class SquareExtensions
{
    public static SquaresGrid ToSquaresGrid(this IEnumerable<string> lines) => 
        new SquaresGrid(lines.Select((line, index) => line.ToSquaresLine(index)));

    public static SquaresLine ToSquaresLine(this string line, int columnIndex) => 
        new SquaresLine(line.Select((ch, rowIndex) => ch.ToSquare(columnIndex, rowIndex)));

    public static Square ToSquare(this char elevation, int columnIndex, int rowIndex) => 
        new Square(columnIndex, rowIndex, elevation);
}