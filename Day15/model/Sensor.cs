namespace Day15.Model;

public class Sensor
{
    public Point Position { get; }
    public Point ClosestBeaconPosition { get; }
    public int ManhattanDistanceToBeacon { get; }

    public Sensor(Point pos, Point beaconPos)
    {
        Position = pos;
        ClosestBeaconPosition = beaconPos;
        ManhattanDistanceToBeacon = pos.ManhattanDistance(beaconPos);
    }

    public IEnumerable<Point> PointsCoveredInRow(int y)
    {
        var yDiff = Math.Abs(y - Position.Y);
        if (yDiff > ManhattanDistanceToBeacon) return Array.Empty<Point>();

        return GetRangeFromManhattenDistance(yDiff)
            .Select(x => new Point(x, y));
    }

    private IEnumerable<int> GetRangeFromManhattenDistance(int y)
    {
        var xDiff = ManhattanDistanceToBeacon - y;
        var min = Position.X - xDiff;
        var max = Position.X + xDiff;
        return Enumerable.Range(min, max - min + 1);
    }
}