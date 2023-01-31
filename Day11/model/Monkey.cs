namespace Day11.Model;

public class Monkey
{
    public List<Item> Items { get; set; }
    public Operation Operation { get; set; }
    public ThrowTest ThrowTest { get; set; }
    public int InspectionCount { get; set; }

    public Monkey(List<Item> items, Operation operation, ThrowTest throwTest)
    {
        Items = items;
        Operation = operation;
        ThrowTest = throwTest;

        InspectionCount = 0;
    }

    public void TakeTurn(IEnumerable<Monkey> monkeys, bool manageStressLevels)
    {
        if (Items.Any())
        {
            Items
                .Select(item => (item: Inspect(item, manageStressLevels), target: monkeys.ElementAt(ThrowTest.GetTargetMonkey(item))))
                .ToList()
                .ForEach(@throw =>
                {
                    ThrowTo(@throw.item, @throw.target);
                });

            Items.Clear();
        }
    }

    private Item Inspect(Item item, bool manageStressLevels)
    {
        var updatedWorryLevel = Operation.Perform(item);
        item.WorryLevel = manageStressLevels 
            ? (int)Math.Floor((double)updatedWorryLevel / 3)
            : updatedWorryLevel;

        InspectionCount += 1;

        return item;
    }

    private void ThrowTo(Item item, Monkey targetMonkey)
    {
        targetMonkey.Items.Add(item);
        // Items.Remove(item);
    }
}