package test.model;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;

import org.junit.Test;

import src.model.Tree;

public class TreeTests {
    @Test
    public void shouldCreate() {
        var createdTree = Tree.create(5);

        assertNotNull(createdTree);
        assertEquals(5, createdTree.getHeight());
    }
}
