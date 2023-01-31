using Day10.Constants;

namespace Day10;

class Program
{
    private static int _completedCycleCount = InitialValues.COMPLETED_CYCLES;
    private static int _xRegisterValue = InitialValues.X_REGISTER;
    private static List<int> _signalStrengths = new List<int>();

    private static int _currentCycleNumber => _completedCycleCount + 1;

    static void Main(string[] args)
    {
        var instructions = File.ReadLines("data/input.txt").ToList();

        instructions.ForEach(instruction =>
        {
            if (CheckSignalStrength)
            {
                RecordSignalStrength();
            }

            var toAdd = 0;

            if (instruction.StartsWith(Instructions.ADD_X_PREFIX))
            {
                CompleteCycle();

                if (CheckSignalStrength)
                {
                    RecordSignalStrength();
                }

                toAdd = GetValueToAdd(instruction);
            }

            CompleteCycle();
            UpdateRegisterValue(toAdd);
        });

        Console.WriteLine($"Sum: {_signalStrengths.Sum()}");
    }

    public static void CompleteCycle()
    {
        _completedCycleCount += 1;
    }

    public static void UpdateRegisterValue(int toAdd)
    {
        _xRegisterValue += toAdd;
    }

    public static void RecordSignalStrength() => 
        _signalStrengths.Add(_currentCycleNumber * _xRegisterValue);

    public static bool CheckSignalStrength => 
        _currentCycleNumber == Cycles.INITIAL ||
        (_currentCycleNumber - Cycles.INITIAL) % Cycles.SUBSEQUENT == 0;

    public static int GetValueToAdd(string instruction) => int.Parse(instruction.Split(" ").Last());
}
