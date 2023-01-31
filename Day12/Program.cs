using Day12.Model;
using Day12.Model.Extensions;

namespace Day12
{
    class Program
    {
        public static void Main(string[] args)
        {
            var grid = File.ReadLines("data/input.txt").ToSquaresGrid();

            var routes = RouteFinder.FindRoutesFromStartToEnd(grid);

            Console.WriteLine(routes.Select(route => route.SquareCount).Min());

            // var points = File.ReadLines("data/input.txt").ToPoints();

            // for (int x = 0; x < points.Length; x++)
            // {
            //     for (int y = 0; y < points[x].Length; y++)
            //     {
            //         var currentPoint = points[x][y];
            //         var currentHeight = currentPoint.Height;

            //         if (x - 1 >= 0)
            //         {
            //             var pointAbove = points[x - 1][y];
            //             if (pointAbove.Height <= currentHeight + 1)
            //             {
            //                 currentPoint.Visitable.Add(pointAbove);
            //             }
            //         }

            //         if (x + 1 < points.Length)
            //         {
            //             var pointBelow = points[x + 1][y];
            //             if (pointBelow.Height <= currentHeight + 1)
            //             {
            //                 currentPoint.Visitable.Add(pointBelow);
            //             }
            //         }

            //         if (y - 1 >= 0)
            //         {
            //             var pointLeft = points[x][y - 1];
            //             if (pointLeft.Height <= currentHeight + 1)
            //             {
            //                 currentPoint.Visitable.Add(pointLeft);
            //             }
            //         }

            //         if (y + 1 < points[x].Length)
            //         {
            //             var pointRight = points[x][y + 1];
            //             if (pointRight.Height <= currentHeight + 1)
            //             {
            //                 currentPoint.Visitable.Add(pointRight);
            //             }
            //         }
            //     }
            // }

            // var routes = new List<Point>();

            // foreach (var row in points)
            // {
            //     foreach (var point in row)
            //     {
            //         if (point.Height <= 1)
            //         {
            //             routes.Add(point);
            //         }
            //     }
            // }

            // var visited = new HashSet<Point>(routes);
            // var numberOfSteps = new List<int>();

            // while (routes.Any())
            // {
            //     var route = routes.First();
            //     routes.RemoveAt(0);

            //     foreach (var nextStep in route.Visitable)
            //     {
            //         if (!visited.Contains(nextStep))
            //         {
            //             if (nextStep.Height != Point.ElevationOf('E'))
            //             {
            //                 routes.Add(nextStep);
            //             }
            //             numberOfSteps.Add(route.Visits + 1);
            //             visited.Add(nextStep);
            //         }
            //     }
            // }

            // foreach (var x in numberOfSteps)
            // {
            //     Console.WriteLine(x);
            // }
        }
    }
}