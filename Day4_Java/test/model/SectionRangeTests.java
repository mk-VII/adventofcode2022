package test.model;

import static org.junit.Assert.assertArrayEquals;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

import org.junit.Test;

import src.model.SectionRange;
import src.model.types.Overlap;

public class SectionRangeTests {
    @Test
    public void shouldConstruct_ContainExpectedSections() {
        var sectionRange = new SectionRange(1, 3);

        var result = sectionRange.getSections().toArray();
        assertEquals(3, result.length);
        assertArrayEquals(new Integer[] { 1, 2, 3 }, result);
    }

    @Test
    public void shouldOverlap_Complete() {
        var sectionRange = new SectionRange(1, 3);
        var otherSectionRange = new SectionRange(2, 3);

        assertTrue("the two ranges do not completely overlap",
                sectionRange.OverlapsWith(otherSectionRange, Overlap.Complete));
    }

    @Test
    public void shouldNotOverlap_Complete() {
        var sectionRange = new SectionRange(1, 3);
        var otherSectionRange = new SectionRange(2, 4);

        assertFalse("the two ranges completely overlap",
                sectionRange.OverlapsWith(otherSectionRange, Overlap.Complete));
    }

    @Test
    public void shouldOverlap_Partial() {
        var sectionRange = new SectionRange(1, 3);
        var otherSectionRange = new SectionRange(2, 5);

        assertTrue("the two ranges do not partially overlap",
                sectionRange.OverlapsWith(otherSectionRange, Overlap.Partial));
    }

    @Test
    public void shouldNotOverlap_Partial() {
        var sectionRange = new SectionRange(1, 3);
        var otherSectionRange = new SectionRange(4, 5);

        assertFalse("the two ranges not partially overlap",
                sectionRange.OverlapsWith(otherSectionRange, Overlap.Partial));
    }
}
