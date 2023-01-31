namespace Day9.Model;

public class Rope
{
    public RopeEnd Head { get; set; }
    public RopeEnd Tail { get; set; }

    public Rope(int x, int y)
    {
        Head = new RopeEnd(x, y);
        Tail = new RopeEnd(x, y);
    }

    public void ExecuteMove(Move move)
    {
        Enumerable.Range(0, move.Steps).ToList().ForEach(step =>
        {
            Head.Move(move.Direction);
            Tail.Follow(Head);
        });
    }
}