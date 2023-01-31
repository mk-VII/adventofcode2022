package test.model.parsers;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

import org.junit.Test;

import src.model.Tree;
import src.model.TreeLine;
import src.model.parsers.TreeParser;

public class TreeParserTests {
    @Test
    public void shouldParseTreeGrid() {

    }

    @Test
    public void shouldParseTreeLine() {
        var parsedTreeLine = TreeParser.parseTreeLine("12345");

        assertTrue("not a tree line", parsedTreeLine instanceof TreeLine);
    }

    @Test
    public void shouldParseTree() {
        var parsedTree = TreeParser.parseTree("7");

        assertTrue("not a tree", parsedTree instanceof Tree);
        assertEquals(7, parsedTree.getHeight());
    }
}
