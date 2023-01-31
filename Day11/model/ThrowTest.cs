namespace Day11.Model;

public class ThrowTest
{
    public int NumberToDivideBy { get; }
    public int TrueMonkeyNumber { get; }
    public int FalseMonkeyNumber { get; }

    public ThrowTest(int divideBy, int trueMonkeyNumber, int falseMonkeyNumber)
    {
        NumberToDivideBy = divideBy;
        TrueMonkeyNumber = trueMonkeyNumber;
        FalseMonkeyNumber = falseMonkeyNumber;
    }

    public int GetTargetMonkey(Item item) =>
        item.WorryLevel % NumberToDivideBy == 0
            ? TrueMonkeyNumber
            : FalseMonkeyNumber;
}