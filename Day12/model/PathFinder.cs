namespace Day12.Model;

public static class RouteFinder
{
    public static IEnumerable<Route> FindRoutesFromStartToEnd(SquaresGrid grid) =>
        FindRoutes(grid)
        .Where(route => route.ArrivesAtEnd());

    private static IEnumerable<Route> FindRoutes(SquaresGrid grid, Route? routeSoFar = null)
    {
        if (routeSoFar?.CurrentSquare == grid.EndSquare) return new[] { routeSoFar };

        var neighbourSquares = grid.GetNeighbourSquares(routeSoFar?.CurrentSquare ?? grid.StartSquare)
            .Where(toSquare => CanProgress(routeSoFar ?? new Route(new[] { grid.StartSquare }), toSquare));

        if (!neighbourSquares.Any()) return new[] { routeSoFar ?? new Route() };

        var possibleRoutes = neighbourSquares.Select(sq =>
        {
            var possibleRoute = new Route(routeSoFar?.Squares ?? new List<Square>() { });
            possibleRoute.AddSquare(sq);

            return possibleRoute;
        });

        return possibleRoutes.SelectMany(route => FindRoutes(grid, route));
    }

    private static bool CanProgress(Route routeSoFar, Square toSquare) =>
        !routeSoFar.AlreadyVisited(toSquare) &&
        Square.ElevationLookup[toSquare.Elevation] - Square.ElevationLookup[routeSoFar.CurrentSquare.Elevation] <= 1;
}