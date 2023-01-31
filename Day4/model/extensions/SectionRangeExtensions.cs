namespace Day4.Model;

public static class SectionRangeExtensions
{
    public static IEnumerable<SectionRangePair> ToSectionRangePairs(this IEnumerable<string> input) => 
        input.Select(line => line.ToSectionRangePair());

    public static SectionRangePair ToSectionRangePair(this string input)
    {
        var ranges = input.Split(",", 2);
    
        return SectionRangePair.Create(ranges[0].ToSectionRange(), ranges[1].ToSectionRange());
    }

    public static SectionRange ToSectionRange(this string input)
    {
        var ends = input.Split("-", 2)
            .Select(end => int.Parse(end))
            .ToArray();

        return SectionRange.Create(ends[0], ends[1]);
    }
}