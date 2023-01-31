using Day16.Model;

namespace Day16
{
    class Program
    {
        static void Main(string[] args)
        {
            var valves = File.ReadLines("data/input.txt").ToPressureSystem();
            var dict = valves.ToDictionary(valve => valve.Room, valve => valve);

            var myPosition = valves.First();

            var ordered = valves.OrderBy(valve => valve.FlowRate);
        }

        static IEnumerable<string> GetPath(Valve from, Valve to, Valve[] valves)
        {
            var possiblePaths = new List<List<string>> { new List<string> { from.Room } };

            while (!possiblePaths.Any(path => path.Contains(from.Room) && path.Contains(to.Room)))
            {
                foreach
            }
        }
    }
}