namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines("data/input.txt");

            var calorieData = new List<List<int>>();
            var itemCalories = new List<int>();

            foreach (string line in allLines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    calorieData.Add(itemCalories);
                    itemCalories = new List<int>();
                }
                else
                {
                    itemCalories.Add(int.Parse(line));
                }
            }

            var elves = calorieData.Select(itemCals => new Elf(itemCals));

            var elvesOrderedByCalories = elves
                .Select(elf => elf.GetTotalCalories())
                .OrderDescending()
                .ToArray();

            Console.WriteLine($"The elf with most calories is carrying: {elvesOrderedByCalories.First()}cals");

            Console.WriteLine($"The three elves with most calories are carrying a combined: {elvesOrderedByCalories[..3].Sum()}cals");
        }
    }
}