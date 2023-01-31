using Day13.Model;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("data/input.txt").ToDataPacketPairs();

            Console.WriteLine($"Part 1 Result = {GetPartOneResult(input)}");
            Console.WriteLine($"Part 2 Result = {GetPartTwoResult(
                input.SelectMany(pair => pair), 
                new [] {"[[2]]", "[[6]]"})
            }");
        }

        public static int GetPartOneResult(ListItem[][] dataPacketPairs) =>
            Enumerable
                .Range(0, dataPacketPairs.Length)
                .Select(index => (items: dataPacketPairs[index], index))
                .Where(pair => pair.items[0].CompareTo(pair.items[1]) <= 0)
                .Select(pair => pair.index + 1)
                .Sum();

        public static int GetPartTwoResult(IEnumerable<ListItem> dataPackets, IEnumerable<string> dividers)
        {
            var dividerPackets = dividers
                .Select(packet => packet.ToListItem(out _))
                .ToArray();

            return dataPackets
                .Concat(dividerPackets)
                .Order()
                .Select((item, index) => (item, index))
                .Where(indexedItem => dividerPackets.Contains(indexedItem.item))
                .Select(indexedItem => indexedItem.index + 1)
                .Aggregate((total, next) => total * next);
        }
    }
}