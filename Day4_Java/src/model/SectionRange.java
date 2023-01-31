package src.model;

import java.util.List;
import java.util.function.Predicate;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

import src.model.types.Overlap;

public class SectionRange {
    private int start;
    private int end;

    public SectionRange(int start, int end) {
        this.start = start;
        this.end = end;
    }

    public List<Integer> getSections() {
        return IntStream.range(start, end + 1)
                .boxed()
                .collect(Collectors.toList());
    }

    public boolean OverlapsWith(SectionRange otherRange, Overlap overlapType) {
        var sectionsStream = otherRange.getSections().stream();
        Predicate<? super Integer> containsPredicate = getSections()::contains;

        return overlapType == Overlap.Complete
                ? sectionsStream.allMatch(containsPredicate)
                : sectionsStream.anyMatch(containsPredicate);
    }
}
