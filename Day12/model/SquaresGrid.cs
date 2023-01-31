namespace Day12.Model;

public class SquaresGrid
{
    public SquaresLine[] Rows { get; set; }

    public SquaresGrid(IEnumerable<SquaresLine> rows)
    {
        Rows = rows.ToArray();
    }

    public IEnumerable<Square> Squares => Rows.SelectMany(row => row.Squares);

    public Square StartSquare => Squares
        .OrderBy(sq => Square.ElevationLookup[sq.Elevation])
        .First();
        
    public Square EndSquare => Squares
        .OrderByDescending(sq => Square.ElevationLookup[sq.Elevation])
        .First();

    public int MaxColumnIndex => Rows.Count() - 1;
    public int MaxRowIndex => Rows.Select(row => row.Squares.Count() - 1).Max();

    public IEnumerable<Square> GetNeighbourSquares(Square square)
    {
        var neighbourSquares = new List<Square>();

        if (square.X > 0)
        {
            neighbourSquares.Add(Squares.First(sq => square.X - 1 == sq.X && square.Y == sq.Y));
        }

        if (square.Y > 0)
        {
            neighbourSquares.Add(Squares.First(sq => square.X == sq.X && square.Y - 1 == sq.Y));
        }

        if (square.X < MaxColumnIndex)
        {
            neighbourSquares.Add(Squares.First(sq => square.X + 1 == sq.X && square.Y == sq.Y));
        }

        if (square.Y < MaxRowIndex)
        {
            neighbourSquares.Add(Squares.First(sq => square.X == sq.X && square.Y + 1 == sq.Y));
        }

        return neighbourSquares;
    }
}