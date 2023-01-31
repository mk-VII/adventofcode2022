namespace Day13.Model;

public record ListItem(Item[] Items) : Item, IComparable<ListItem>
{
  public int CompareTo(ListItem? other)
  {
    other ??= new(Array.Empty<Item>());

    var i = 0;
    while (i < Items.Length && i < other.Items.Length)
    {
      var cmp = Items[i].CompareTo(other.Items[i]);
      if (cmp != 0)
        return cmp;

      ++i;
    }

    return Items.Length.CompareTo(other.Items.Length);
  }
}