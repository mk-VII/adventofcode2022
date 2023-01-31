using Day11.Model;
using Day11.Model.Extensions;

namespace Day11
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Part 1 Monkey Business: {GetAnswer(20)}");
            Console.WriteLine($"Part 2 Monkey Business: {GetAnswer(10000, false)}");
        }

        public static int GetAnswer(int numRounds, bool manageStressLevels = true)
        {
            var monkeys = File.ReadLines("data/input.txt").ToMonkeys().ToList();

            Enumerable.Range(0, numRounds).ToList().ForEach(_ =>
            {
                monkeys.ForEach(monkey =>
                {
                    monkey.TakeTurn(monkeys, manageStressLevels);
                });
            });

            return CalculateMonkeyBusiness(monkeys);
        }

        public static int CalculateMonkeyBusiness(IEnumerable<Monkey> monkeys) => monkeys
            .Select(monkey => monkey.InspectionCount)
            .OrderDescending()
            .ToArray()[..2]
            .Aggregate((total, next) => total * next);
    }
}