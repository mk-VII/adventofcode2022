namespace Day4.Model;

public class SectionRange
{
    private int _start { get; }
    private int _end { get; }

    private int _count => _end - _start + 1;
    public IEnumerable<int> Sections => Enumerable.Range(_start, _count);

    private SectionRange(int start, int end)
    {
        _start = start;
        _end = end;
    }

    public static SectionRange Create(int start, int end) =>
        new SectionRange(start, end);

    public bool OverlapsWith(SectionRange range, Overlap overlapType) =>
        overlapType switch
        {
            Overlap.Complete => HasCompleteOverlap(range.Sections),
            Overlap.Partial => HasPartialOverlap(range.Sections),
            _ => throw new ArgumentOutOfRangeException("Not a valid overlap type")
        };

    private bool HasCompleteOverlap(IEnumerable<int> sections) =>
        sections.All(section => Sections.Contains(section));

    private bool HasPartialOverlap(IEnumerable<int> sections) =>
        Sections.Intersect(sections).Any();

    // public override string ToString() => $"{Start}-{End}";
}