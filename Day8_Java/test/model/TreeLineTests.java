package test.model;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;

import java.util.Arrays;
import org.junit.Test;

import src.model.*;

public class TreeLineTests {
    @Test
    public void shouldCreate() {
        var trees = Arrays.asList(
                Tree.create(1),
                Tree.create(4),
                Tree.create(2),
                Tree.create(5),
                Tree.create(3));

        var createdTreeLine = TreeLine.create(trees);

        assertNotNull(createdTreeLine);
        assertEquals(5, createdTreeLine.getTrees().size());
        assertEquals(1, createdTreeLine.getTrees().get(0).getHeight());
        assertEquals(4, createdTreeLine.getTrees().get(1).getHeight());
        assertEquals(2, createdTreeLine.getTrees().get(2).getHeight());
        assertEquals(5, createdTreeLine.getTrees().get(3).getHeight());
        assertEquals(3, createdTreeLine.getTrees().get(4).getHeight());
    }
}
