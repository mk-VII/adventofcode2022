package src.model;

import src.model.types.Overlap;

public class SectionRangePair {
    private SectionRange first;
    private SectionRange second;

    public SectionRangePair(SectionRange first, SectionRange second) {
        this.first = first;
        this.second = second;
    }

    public boolean SectionsOverlap(Overlap overlapType) {
        return first.OverlapsWith(second, overlapType) || second.OverlapsWith(first, overlapType);
    }
}
