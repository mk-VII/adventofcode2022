using Day9.Model;
using Day9.Model.Extensions;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var moves = File.ReadLines("data/input.txt").ToMoves().ToList();

            var rope = new Rope(0, 0);

            moves.ForEach(move => {
                rope.ExecuteMove(move);
            });

            Console.WriteLine(rope.Tail.History);
        }
    }
}