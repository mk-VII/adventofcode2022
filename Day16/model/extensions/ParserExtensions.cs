namespace Day16.Model;

public static class ParserExtensions
{
    public static Valve[] ToPressureSystem(this IEnumerable<string> lines) => 
        lines.Select(line => line.ToValve()).ToArray();

    private static Valve ToValve(this string line) => 
        new Valve(GetRoom(line), GetFlowRate(line), GetConnectedRooms(line));

    private static string GetRoom(string line) => 
        line.Split(';').First().Split(' ')[1..].First();

    private static int GetFlowRate(string line) => 
        int.Parse(line.Split(';').First().Split(' ').Last()[5..]);

    private static IEnumerable<string> GetConnectedRooms(string line) => 
        line.Split(' ')[9..].Select(room => room.Replace(",", ""));
}