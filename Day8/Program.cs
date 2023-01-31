using TreeExtensions;
using Model;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = File.ReadLines("data/input.txt").ToTreeGrid();

            // Console.WriteLine("ROWS");
            // Console.WriteLine(string.Join("", grid.Rows[0].Trees.Select(tree => tree.Height)));
            // Console.WriteLine(string.Join("", grid.Rows[1].Trees.Select(tree => tree.Height)));
            // Console.WriteLine(string.Join("", grid.Rows[2].Trees.Select(tree => tree.Height)));
            // Console.WriteLine(string.Join("", grid.Rows[3].Trees.Select(tree => tree.Height)));
            // Console.WriteLine(string.Join("", grid.Rows[4].Trees.Select(tree => tree.Height)));
            // Console.WriteLine("\n");
            // Console.WriteLine("COLUMNS");
            // Console.WriteLine(string.Join("", grid.Columns[0].Trees.Select(tree => tree.Height)));
            // Console.WriteLine(string.Join("", grid.Columns[1].Trees.Select(tree => tree.Height)));
            // Console.WriteLine(string.Join("", grid.Columns[2].Trees.Select(tree => tree.Height)));
            // Console.WriteLine(string.Join("", grid.Columns[3].Trees.Select(tree => tree.Height)));
            // Console.WriteLine(string.Join("", grid.Columns[4].Trees.Select(tree => tree.Height)));

            var visibleTrees = TreeSpotter.GetVisibleTreesInGrid(grid);
            Console.WriteLine($"Visible: {visibleTrees.Count()}");

            var treePositions = TreeSpotter.GetTreePositions(grid).Select(x => x.ScenicScore);
            Console.WriteLine(treePositions.Max());
        }
    }
}