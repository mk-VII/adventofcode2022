package src.model.parsers;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

import src.model.SectionRange;
import src.model.SectionRangePair;

public class SectionRangeParser {
    public static List<SectionRangePair> parseSectionRangePairs(List<String> lines) {
        return lines.stream()
                .map(SectionRangeParser::parseSectionRangePair)
                .collect(Collectors.toList());
    }

    public static SectionRangePair parseSectionRangePair(String input) {
        var sections = Arrays.asList(input.split(",", 2))
                .stream()
                .map(SectionRangeParser::parseSectionRange)
                .collect(Collectors.toList());

        return new SectionRangePair(sections.get(0), sections.get(1));
    }

    public static SectionRange parseSectionRange(String input) {
        var rangeEnds = Arrays.asList(input.split("-", 2))
                .stream()
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        return new SectionRange(rangeEnds.get(0), rangeEnds.get(1));
    }
}
