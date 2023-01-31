using Day4.Model;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var sectionRangePairs = File.ReadAllLines("data/input.txt").ToSectionRangePairs();

            Console.WriteLine($"Number of completely overlapping section ranges: {GetAnswer(sectionRangePairs, Overlap.Complete)}");
            Console.WriteLine($"Number of partially overlapping section ranges: {GetAnswer(sectionRangePairs, Overlap.Partial)}");
        }

        public static int GetAnswer(IEnumerable<SectionRangePair> sectionRangePairs, Overlap overlapType) =>
            sectionRangePairs.Count(pair => pair.SectionsOverlap(overlapType));
   }
}