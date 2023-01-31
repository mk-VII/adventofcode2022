namespace Model;

public class TreePosition
{
    private Tree _tree;
    private TreeLine _row;
    private TreeLine _column;

    public TreePosition(Tree tree, TreeLine row, TreeLine column)
    {
        _tree = tree;
        _row = row;
        _column = column;
    }

    private TreeLine GetLineAndPositionRelativeToPerspective(FromPerspective perspective) =>
        perspective == FromPerspective.North || perspective == FromPerspective.South
            ? _column
            : _row;

    public int ScenicScore
    {
        get
        {
            var perspectives = Enum.GetValues<FromPerspective>();

            var visibleTrees = perspectives.Select(perspective =>
            {
                var line = GetLineAndPositionRelativeToPerspective(perspective);

                return line.TreesVisibleFromTree(perspective, _tree).Trees.Length;
            });

            return visibleTrees.Aggregate((total, next) => total * next);
        }
    }
}