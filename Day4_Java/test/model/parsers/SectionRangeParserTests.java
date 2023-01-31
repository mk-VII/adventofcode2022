package test.model.parsers;

import src.model.parsers.SectionRangeParser;

import static org.junit.Assert.assertArrayEquals;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;

import org.junit.Test;

public class SectionRangeParserTests {
    @Test
    public void shouldParseSectionRangePair_ContainTwoPairsOfExpectedSections() {
        var pair = SectionRangeParser.parseSectionRangePair("1-12,11-16");

        assertNotNull(pair);
    }

    @Test
    public void shouldParseSectionRange_ContainExpectedSections() {
        var sectionRange = SectionRangeParser.parseSectionRange("1-10");

        var result = sectionRange.getSections().toArray();
        assertEquals(10, result.length);
        assertArrayEquals(new Integer[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, result);
    }
}
