namespace Model;

public class TreeGrid
{
    public TreeLine[] Rows { get; }

    public TreeGrid(IEnumerable<TreeLine> rows)
    {
        Rows = rows.ToArray();
    }

    public TreeLine[] Columns =>
        Enumerable.Range(0, Rows.Length)
            .Select(columnIndex => new TreeLine(Rows.Select(row => row.Trees[columnIndex])))
            .ToArray();

    public TreeLine[] GetGridLinesFromPerspective(FromPerspective perspective) => perspective switch
    {
        FromPerspective.North => Columns,
        FromPerspective.East => Rows.Select(row => row.Reversed()).ToArray(),
        FromPerspective.South => Columns.Select(column => column.Reversed()).ToArray(),
        FromPerspective.West => Rows,
        _ => throw new IndexOutOfRangeException($"{nameof(perspective)} is not a valid value")
    };
}