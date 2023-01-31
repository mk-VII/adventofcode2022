namespace Day16.Model;

public class Valve
{
    public string Room { get; }
    public int FlowRate { get; }
    public int? MinuteOpened { get; private set; } = null;
    public string[] ConnectedRooms { get; } = Array.Empty<string>();

    public Valve(string room, int flowRate, IEnumerable<string> connectedRooms)
    {
        Room = room;
        FlowRate = flowRate;
        ConnectedRooms = connectedRooms.ToArray();
    }

    public bool IsBroken => FlowRate == 0;

    public void Open(int minute) => MinuteOpened = minute;
}