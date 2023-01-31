using Day14.Model;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            var paths = File.ReadLines("data/input.txt").ToPaths();

            var walls = paths.SelectMany(GetPointsInPath);

            var start = new Point(500, 0);
            var bottom = walls.Select(p => p.Y).Max();

            var sand1 = PourSand(start, bottom, walls);
            Console.WriteLine($"Part 1 Result = {sand1.Count}");

            var floor = bottom + 2;
            var sand2 = PourSand(start, int.MaxValue, walls, floor);
            Console.WriteLine($"Part 2 Result = {sand2.Count}");
        }

        static HashSet<Point> PourSand(Point start, int bottom, IEnumerable<Point> occupiedPoints, int? floor = null)
        {
            HashSet<Point> sandPoints = new();

            var willFallForever = true;
            while (willFallForever)
            {
                var sandPos = PlaceSandUnit(start, bottom, occupiedPoints.Concat(sandPoints), floor);
                if (sandPos.HasValue)
                {
                    sandPoints.Add(sandPos.Value);
                }
                else
                {
                    willFallForever = false;
                }
            }

            return sandPoints;
        }

        static Point? PlaceSandUnit(Point start, int bottom, IEnumerable<Point> occupiedPoints, int? floor = null)
        {
            if (occupiedPoints.Contains(start)) return null;

            var currentPoint = start;
            while (currentPoint.Y <= bottom)
            {
                var next = GetPossibleNextPoints(currentPoint)
                    .Where(point => !occupiedPoints.Contains(point) || floor.HasValue && point.Y == floor)
                    .Select(point => (Point?)point)
                    .FirstOrDefault();

                if (!next.HasValue)
                {
                    return currentPoint;
                }

                currentPoint = next.Value;
            }

            return null;
        }

        static IEnumerable<Point> GetPossibleNextPoints(Point point)
        {
            var belowY = point.Y + 1;

            return new[]
            {
                new Point(point.X, belowY),
                new Point(point.X - 1, belowY),
                new Point(point.X + 1, belowY)
            };
        }

        static IEnumerable<Point> GetPointsInPath(IEnumerable<Point> path) => path
            .Zip(path.Skip(1))
            .SelectMany(pair => GetPointsBetweenPoints(pair.First, pair.Second));

        static IEnumerable<Point> GetPointsBetweenPoints(Point start, Point end)
        {
            if (start.X == end.X)
            {
                return Enumerable
                    .Range(
                        Math.Min(start.Y, end.Y),
                        Math.Abs(end.Y - start.Y) + 1)
                    .Select(y => new Point(start.X, y));
            }

            if (start.Y == end.Y)
            {
                return Enumerable
                    .Range(
                        Math.Min(start.X, end.X),
                        Math.Abs(end.X - start.X) + 1)
                    .Select(x => new Point(x, start.Y));
            }

            return Enumerable.Empty<Point>();
        }
    }
}