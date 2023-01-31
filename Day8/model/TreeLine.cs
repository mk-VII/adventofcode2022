namespace Model;

public class TreeLine
{
    public Tree[] Trees { get; }

    public TreeLine(IEnumerable<Tree> trees)
    {
        Trees = trees.ToArray();
    }

    public TreeLine Reversed() => new TreeLine(Trees.Reverse());

    public bool IsBlockedByTallerTree(int index, int height) =>
        Trees[..index].Any(tree => tree.Height >= height);

    public TreeLine TreesVisibleFromTree(FromPerspective perspective, Tree tree)
    {
        var visibleTrees = GetVisibleTreesFromPerspectiveAndPosition(perspective, tree);

        return visibleTrees;
    }

    public TreeLine GetVisibleTreesFromPerspectiveAndPosition(FromPerspective perspective, Tree myTree)
    {
        IEnumerable<Tree> treesFromPerspective = new List<Tree>();

        if (perspective == FromPerspective.North || perspective == FromPerspective.West)
        {
            var indexOfMyTree = Trees.ToList().IndexOf(myTree) + 1;
            treesFromPerspective = Trees[indexOfMyTree..];
        }

        if (perspective == FromPerspective.South || perspective == FromPerspective.East)
        {
            var reversedTrees = Trees.Reverse();
            var indexOfMyTree = reversedTrees.ToList().IndexOf(myTree) + 1;
            treesFromPerspective = reversedTrees.ToArray()[indexOfMyTree..];
        }

        if (treesFromPerspective.Any(tree => tree.Height >= myTree.Height))
        {
            var index = treesFromPerspective
                .ToList()
                .IndexOf(treesFromPerspective.First(tree => tree.Height >= myTree.Height)) + 1;

            treesFromPerspective = treesFromPerspective.ToArray()[..index];
        }

        return new TreeLine(treesFromPerspective);
    }
}