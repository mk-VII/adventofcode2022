namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var rucksacks = File.ReadAllLines("data/input.txt");
            var priorities = GeneratePriorityOrderedLetters();
            
            Console.WriteLine(GetPartOneAnswer(rucksacks, priorities));
            Console.WriteLine(GetPartTwoAnswer(rucksacks, priorities));
        }

        private static int GetPartOneAnswer(IEnumerable<string> rucksacks, List<char> priorities)
        {
            var splitContentsPerRucksack = rucksacks.Select(contents =>
            {
                var splitIndex = contents.Length / 2;

                return (
                    compartment1: contents.Substring(0, splitIndex),
                    compartment2: contents.Substring(splitIndex)
                );
            });

            var crossCompartmentItemsPerRucksack = splitContentsPerRucksack
                .Select(items => items.compartment1
                    .Intersect(items.compartment2)
                    .FirstOrDefault()
                );

            return crossCompartmentItemsPerRucksack
                .Sum(item => priorities.IndexOf(item));

        }

        private static int GetPartTwoAnswer(IEnumerable<string> rucksacks, List<char> priorities)
        {
            var groupSize = 3;
            var groupedRucksacks = rucksacks.Chunk(groupSize);

            var badgeItems = groupedRucksacks
                .Select(grp => priorities
                    .FirstOrDefault(letter => grp
                        .All(items => items.Contains(letter))));

            return badgeItems.Sum(item => priorities.IndexOf(item));
        }

        private static List<char> GeneratePriorityOrderedLetters()
        {
            var lowerCase = Enumerable.Range('a', 26).Select(x => (char)x);
            var upperCase = Enumerable.Range('A', 26).Select(x => (char)x);

            // empty char added to take index of 0
            // making subsequent indices match their priority value
            return new[] { ' ' }.Concat(lowerCase).Concat(upperCase).ToList();
        }
    }
}