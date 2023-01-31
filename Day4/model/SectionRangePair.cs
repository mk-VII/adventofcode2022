namespace Day4.Model;

public class SectionRangePair
{
    private SectionRange _first { get; }
    private SectionRange _second { get; }

    private SectionRangePair(SectionRange first, SectionRange second)
    {
        _first = first;
        _second = second;
    }

    public static SectionRangePair Create(SectionRange first, SectionRange second) => 
        new SectionRangePair(first, second);

    public bool SectionsOverlap(Overlap overlapType) =>
        _first.OverlapsWith(_second, overlapType) || _second.OverlapsWith(_first, overlapType);
}