namespace Day13.Model;

public record NumberItem(int Value) : Item
{
    public ListItem ToListItem() => new(new[] { this as Item });
}
