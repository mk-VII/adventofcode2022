package src;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.*;
import java.util.List;

import src.model.SectionRangePair;
import src.model.parsers.SectionRangeParser;
import src.model.types.Overlap;

public class Program {
    public static void main(String[] args) throws IOException {
        var sectionRangePairs = SectionRangeParser.parseSectionRangePairs(
                Files.readAllLines(Paths.get("data/input.txt"), StandardCharsets.UTF_8));

        System.out.println("The number of completely overlapping section ranges is: "
                + GetAnswer(sectionRangePairs, Overlap.Complete));
        System.out.println("The number of partially overlapping section ranges is: "
                + GetAnswer(sectionRangePairs, Overlap.Partial));
    }

    public static long GetAnswer(List<SectionRangePair> pairs, Overlap overlapType) {
        return pairs.stream()
                .filter((pair) -> pair.SectionsOverlap(overlapType))
                .count();
    }
}