package test.model;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

import org.junit.Test;

import src.model.SectionRange;
import src.model.SectionRangePair;
import src.model.types.Overlap;

public class SectionRangePairTests {
    @Test
    public void should_SectionsOverlap_Complete() {
        var pair = new SectionRangePair(new SectionRange(1, 5), new SectionRange(2, 4));

        assertTrue("sections do not overlap completely", pair.SectionsOverlap(Overlap.Complete));
    }

    @Test
    public void shouldNot_SectionsOverlap_Complete() {
        var pair = new SectionRangePair(new SectionRange(1, 5), new SectionRange(5, 10));

        assertFalse("sections overlap completely", pair.SectionsOverlap(Overlap.Complete));
    }

    @Test
    public void should_SectionsOverlap_Partial() {
        var pair = new SectionRangePair(new SectionRange(1, 5), new SectionRange(5, 10));

        assertTrue("sections do not overlap partially", pair.SectionsOverlap(Overlap.Partial));
    }

    @Test
    public void shouldNot_SectionsOverlap_Partial() {
        var pair = new SectionRangePair(new SectionRange(1, 5), new SectionRange(6, 10));

        assertFalse("sections overlap partially", pair.SectionsOverlap(Overlap.Partial));
    }

}
