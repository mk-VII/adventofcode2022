using Model;

namespace TreeExtensions;

public static class TreeExtensions
{
    public static TreeGrid ToTreeGrid(this IEnumerable<string> lines) => new TreeGrid(lines.Select(ToTreeRow));

    private static TreeLine ToTreeRow(this string line) => new TreeLine(line.Select(ToTree));

    private static Tree ToTree(this char height) => new Tree(int.Parse(height.ToString()));
}
