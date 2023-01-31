namespace Day1
{
    public class Elf
    {
        private IEnumerable<int> _itemCalories { get; }

        public Elf(IEnumerable<int> itemCalories)
        {
            _itemCalories = itemCalories;
        }

        public int GetTotalCalories() => _itemCalories.Sum();
    }
}