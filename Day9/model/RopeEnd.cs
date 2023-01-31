namespace Day9.Model;

public class RopeEnd
{
    public int X { get; set; }

    public int Y { get; set; }

    public List<(int x, int y)> _moveHistory;

    public int History => _moveHistory.Distinct().Count();

    public RopeEnd(int x, int y)
    {
        X = x;
        Y = y;
        _moveHistory = new List<(int x, int y)> { (X, Y) };
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                MoveUp();
                break;
            case Direction.Right:
                MoveRight();
                break;
            case Direction.Down:
                MoveDown();
                break;
            case Direction.Left:
                MoveLeft();
                break;
            default:
                break;
        }

        UpdateMoveHistory();
    }

    public void Follow(RopeEnd head)
    {
        if (X == head.X && Y == head.Y)
        {
            return;
        }

        // if (X - head.X <= 1 && Y - head.Y <= 1)
        // {
        //     return;
        // }

        if (HeadIsAboveTail(head) && HeadIsRightOfTail(head))
        {
            MoveUp();
            MoveRight();
        }
        if (HeadIsAboveTail(head) && HeadIsLeftOfTail(head))
        {
            MoveUp();
            MoveLeft();
        }
        if (HeadIsBelowTail(head) && HeadIsRightOfTail(head))
        {
            MoveDown();
            MoveRight();
        }
        if (HeadIsBelowTail(head) && HeadIsLeftOfTail(head))
        {
            MoveDown();
            MoveLeft();
        }

        if (HeadIsAboveTail(head))
        {
            MoveUp();
        }
        if (HeadIsRightOfTail(head))
        {
            MoveRight();
        }
        if (HeadIsBelowTail(head))
        {
            MoveDown();
        }
        if (HeadIsLeftOfTail(head))
        {
            MoveLeft();
        }

        UpdateMoveHistory();
    }

    private void UpdateMoveHistory()
    {
        _moveHistory.Add((X, Y));
    }

    private void MoveUp()
    {
        Y += 1;
    }

    private void MoveRight()
    {
        X += 1;
    }

    private void MoveDown()
    {
        Y -= 1;
    }

    private void MoveLeft()
    {
        X -= 1;
    }

    private bool HeadIsAboveTail(RopeEnd head) => head.X - X > 1;
    private bool HeadIsRightOfTail(RopeEnd head) => head.Y - Y > 1;
    private bool HeadIsBelowTail(RopeEnd head) => head.X - X > -1;
    private bool HeadIsLeftOfTail(RopeEnd head) => head.Y - Y > -1;
}