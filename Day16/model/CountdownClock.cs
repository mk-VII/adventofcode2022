namespace Day16.Model;

public class CountdownClock
{
    public int MinutesRemaining { get; private set; }

    public CountdownClock(int minutes)
    {
        MinutesRemaining = minutes;
    }

    public int TakeMinute() => MinutesRemaining--;
}