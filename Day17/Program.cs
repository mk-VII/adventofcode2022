namespace Day17
{
    class Program
    {
        static void Main(string[] args)
        {
            var jetPushes = File.ReadAllText("data/input.txt").Select(arrow => PushDictionary[arrow]);
        }

        private static Dictionary<char, int> PushDictionary =>
            new Dictionary<char, int> {
                {'<', -1},
                {'>', 1}
            };
    }
}