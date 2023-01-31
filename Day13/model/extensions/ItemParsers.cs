namespace Day13.Model;

public static class ItemParsers
{
    public static ListItem[][] ToDataPacketPairs(this IEnumerable<string> lines) => lines
        .Where(line => !string.IsNullOrEmpty(line))
        .Select(line => ToListItem(line, out _))
        .Chunk(2)
        .ToArray();

    public static Item ToItem(this string input, out string tail) => input[0] switch
    {
        '[' => ToListItem(input, out tail),
        _ => ToNumberItem(input, out tail)
    };

    public static ListItem ToListItem(this string input, out string tail)
    {
        input = input[1..];
        var result = new List<Item>();
        while (input.Length > 0)
        {
            var ch = input[0];
            if (ch == ']')
                break;
            else if (ch == ',')
                input = input[1..];
            else
                result.Add(ToItem(input, out input));
        }
        tail = input[1..];

        return new ListItem(result.ToArray());
    }

    private static NumberItem ToNumberItem(this string input, out string tail)
    {
        var index = input.IndexOfAny(new[] { ',', ']' });
        tail = input[index..];
        return new NumberItem(int.Parse(input[..index]));
    }
}