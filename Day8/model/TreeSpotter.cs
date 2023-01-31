namespace Model;

public static class TreeSpotter
{
    public static IEnumerable<Tree> GetVisibleTreesInGrid(TreeGrid grid) =>
        Enum.GetValues<FromPerspective>()
            .SelectMany(perspective => GetVisibleTreesFromPerspective(perspective, grid))
            .Distinct();

    private static IEnumerable<Tree> GetVisibleTreesFromPerspective(FromPerspective perspective, TreeGrid grid) => 
        grid.GetGridLinesFromPerspective(perspective)
            .SelectMany(GetVisibleTreesInLine);

    private static IEnumerable<Tree> GetVisibleTreesInLine(TreeLine line) => 
        line.Trees.Where((tree, index) => !line.IsBlockedByTallerTree(index, tree.Height));

    public static IEnumerable<TreePosition> GetTreePositions(TreeGrid grid)
    {
        var positions = new List<TreePosition>();

        foreach (var row in grid.Rows)
        {
            foreach (var tree in row.Trees)
            {
                positions.Add(new TreePosition(tree, row, grid.Columns.FirstOrDefault(column => column.Trees.Contains(tree))!));
            }
        }

        return positions;
    }
}