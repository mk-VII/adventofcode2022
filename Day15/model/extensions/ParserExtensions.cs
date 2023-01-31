namespace Day15.Model;

public static class ParserExtensions
{
    public static Sensor[] ToSensors(this IEnumerable<string> lines) => lines
        .Select(line => line.ToSensor())
        .ToArray();

    public static Sensor ToSensor(this string line)
    {
        var halves = line.Split(":");

        var positions = halves
            .Select(x => x
                .Split(" ")
                .TakeLast(2)
            );

        return new Sensor(
            positions.First().ToPoint(),
            positions.Last().ToPoint()
        );
    }

    public static Point ToPoint(this IEnumerable<string> coordinates)
    {
        var sanitisedValues = coordinates
            .Select(coord => coord[2..].Replace(",", ""))
            .ToArray();

        return new Point(
            int.Parse(sanitisedValues.First()),
            int.Parse(sanitisedValues.Last())
        );
    }
}