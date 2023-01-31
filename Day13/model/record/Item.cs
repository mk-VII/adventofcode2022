namespace Day13.Model;

public abstract record Item : IComparable<Item>
{
  public int CompareTo(Item? other)
    => (this, other) switch
    {
      (NumberItem num, NumberItem otherNum) => num.Value.CompareTo(otherNum.Value),
      (ListItem list, ListItem otherList) => list.CompareTo(otherList),
      (NumberItem num, ListItem list) => num.ToListItem().CompareTo(list),
      (ListItem list, NumberItem num) => list.CompareTo(num.ToListItem()),
      _ => throw new InvalidOperationException()
    };
}