namespace Day11.Model.Extensions;

public static class MonkeyExtensions
{
    public static IEnumerable<Monkey> ToMonkeys(this IEnumerable<string> lines) => lines
        .Where(line => !string.IsNullOrEmpty(line) && !line.StartsWith("Monkey"))
        .Chunk(5)
        .Select(chunk => chunk.ToMonkey());

    private static Monkey ToMonkey(this string[] lines)
    {
        var items = lines[0]
            .Substring(lines[0].IndexOf(": ") + 2)
            .Split(", ")
            .Select(worryLevel => new Item(int.Parse(worryLevel)))
            .ToList();

        var lineParts = lines[1].Split(" ").ToArray();
        var operationParts = lineParts[(lineParts.Length - 2)..].ToArray();
        var operation = new Operation(operationParts[0], operationParts[1]);

        var throwTestValues = lines[(2)..].Select(line => int.Parse(line.Split(" ").Last())).ToArray();
        var throwTest = new ThrowTest(throwTestValues[0], throwTestValues[1], throwTestValues[2]);

        return new Monkey(items, operation, throwTest);
    }
}