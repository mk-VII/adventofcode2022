namespace Day12.Model;

public class Route
{
    public List<Square> Squares { get; }

    public Route()
    {
        Squares = new List<Square>();
    }

    public Route(IEnumerable<Square> routeSoFar)
    {
        Squares = routeSoFar.ToList();
    }

    public Square CurrentSquare => Squares.Last();

    public int SquareCount => Squares.Count();

    public void AddSquare(Square square) => Squares.Add(square);

    public bool AlreadyVisited(Square square) => Squares.Contains(square);

    public bool ArrivesAtEnd() => 
        Square.ElevationLookup[Squares.Last().Elevation] == Square.ElevationLookup.Last().Value;
}