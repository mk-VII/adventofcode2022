package test.model;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;

import java.util.Arrays;

import org.junit.Test;

import src.model.*;

public class TreeGridTests {
    @Test
    public void shouldCreate() {
        var treeRows = Arrays.asList(
                TreeLine.create(Arrays.asList(
                        Tree.create(1),
                        Tree.create(1),
                        Tree.create(1),
                        Tree.create(1),
                        Tree.create(1))),
                TreeLine.create(Arrays.asList(
                        Tree.create(2),
                        Tree.create(2),
                        Tree.create(2),
                        Tree.create(2),
                        Tree.create(2))),
                TreeLine.create(Arrays.asList(
                        Tree.create(3),
                        Tree.create(3),
                        Tree.create(3),
                        Tree.create(3),
                        Tree.create(3))),
                TreeLine.create(Arrays.asList(
                        Tree.create(4),
                        Tree.create(4),
                        Tree.create(4),
                        Tree.create(4),
                        Tree.create(4))),
                TreeLine.create(Arrays.asList(
                        Tree.create(5),
                        Tree.create(5),
                        Tree.create(5),
                        Tree.create(5),
                        Tree.create(5))));

        var createdTreeGrid = TreeGrid.create(treeRows);

        assertNotNull(createdTreeGrid);
        assertEquals(5, createdTreeGrid.getRows().size());

        assertEquals(1, createdTreeGrid.getRows().get(0).getTrees().get(0).getHeight());
        assertEquals(1, createdTreeGrid.getRows().get(0).getTrees().get(1).getHeight());
        assertEquals(1, createdTreeGrid.getRows().get(0).getTrees().get(2).getHeight());
        assertEquals(1, createdTreeGrid.getRows().get(0).getTrees().get(3).getHeight());
        assertEquals(1, createdTreeGrid.getRows().get(0).getTrees().get(4).getHeight());

        assertEquals(2, createdTreeGrid.getRows().get(1).getTrees().get(0).getHeight());
        assertEquals(2, createdTreeGrid.getRows().get(1).getTrees().get(1).getHeight());
        assertEquals(2, createdTreeGrid.getRows().get(1).getTrees().get(2).getHeight());
        assertEquals(2, createdTreeGrid.getRows().get(1).getTrees().get(3).getHeight());
        assertEquals(2, createdTreeGrid.getRows().get(1).getTrees().get(4).getHeight());

        assertEquals(3, createdTreeGrid.getRows().get(2).getTrees().get(0).getHeight());
        assertEquals(3, createdTreeGrid.getRows().get(2).getTrees().get(1).getHeight());
        assertEquals(3, createdTreeGrid.getRows().get(2).getTrees().get(2).getHeight());
        assertEquals(3, createdTreeGrid.getRows().get(2).getTrees().get(3).getHeight());
        assertEquals(3, createdTreeGrid.getRows().get(2).getTrees().get(4).getHeight());

        assertEquals(4, createdTreeGrid.getRows().get(3).getTrees().get(0).getHeight());
        assertEquals(4, createdTreeGrid.getRows().get(3).getTrees().get(1).getHeight());
        assertEquals(4, createdTreeGrid.getRows().get(3).getTrees().get(2).getHeight());
        assertEquals(4, createdTreeGrid.getRows().get(3).getTrees().get(3).getHeight());
        assertEquals(4, createdTreeGrid.getRows().get(3).getTrees().get(4).getHeight());

        assertEquals(5, createdTreeGrid.getRows().get(4).getTrees().get(0).getHeight());
        assertEquals(5, createdTreeGrid.getRows().get(4).getTrees().get(1).getHeight());
        assertEquals(5, createdTreeGrid.getRows().get(4).getTrees().get(2).getHeight());
        assertEquals(5, createdTreeGrid.getRows().get(4).getTrees().get(3).getHeight());
        assertEquals(5, createdTreeGrid.getRows().get(4).getTrees().get(4).getHeight());
    }

    public void shouldGetColumnsFromRows() {
        var treeRows = Arrays.asList(
                TreeLine.create(Arrays.asList(
                        Tree.create(1),
                        Tree.create(1),
                        Tree.create(1),
                        Tree.create(1),
                        Tree.create(1))),
                TreeLine.create(Arrays.asList(
                        Tree.create(2),
                        Tree.create(2),
                        Tree.create(2),
                        Tree.create(2),
                        Tree.create(2))),
                TreeLine.create(Arrays.asList(
                        Tree.create(3),
                        Tree.create(3),
                        Tree.create(3),
                        Tree.create(3),
                        Tree.create(3))),
                TreeLine.create(Arrays.asList(
                        Tree.create(4),
                        Tree.create(4),
                        Tree.create(4),
                        Tree.create(4),
                        Tree.create(4))),
                TreeLine.create(Arrays.asList(
                        Tree.create(5),
                        Tree.create(5),
                        Tree.create(5),
                        Tree.create(5),
                        Tree.create(5))));

        var createdTreeGrid = TreeGrid.create(treeRows);

        assertNotNull(createdTreeGrid);
        assertEquals(5, createdTreeGrid.getColumns().size());

        assertEquals(1, createdTreeGrid.getColumns().get(0).getTrees().get(0).getHeight());
        assertEquals(2, createdTreeGrid.getColumns().get(0).getTrees().get(1).getHeight());
        assertEquals(3, createdTreeGrid.getColumns().get(0).getTrees().get(2).getHeight());
        assertEquals(4, createdTreeGrid.getColumns().get(0).getTrees().get(3).getHeight());
        assertEquals(5, createdTreeGrid.getColumns().get(0).getTrees().get(4).getHeight());

        assertEquals(1, createdTreeGrid.getColumns().get(1).getTrees().get(0).getHeight());
        assertEquals(2, createdTreeGrid.getColumns().get(1).getTrees().get(1).getHeight());
        assertEquals(3, createdTreeGrid.getColumns().get(1).getTrees().get(2).getHeight());
        assertEquals(4, createdTreeGrid.getColumns().get(1).getTrees().get(3).getHeight());
        assertEquals(5, createdTreeGrid.getColumns().get(1).getTrees().get(4).getHeight());

        assertEquals(1, createdTreeGrid.getColumns().get(2).getTrees().get(0).getHeight());
        assertEquals(2, createdTreeGrid.getColumns().get(2).getTrees().get(1).getHeight());
        assertEquals(3, createdTreeGrid.getColumns().get(2).getTrees().get(2).getHeight());
        assertEquals(4, createdTreeGrid.getColumns().get(2).getTrees().get(3).getHeight());
        assertEquals(5, createdTreeGrid.getColumns().get(2).getTrees().get(4).getHeight());

        assertEquals(1, createdTreeGrid.getColumns().get(3).getTrees().get(0).getHeight());
        assertEquals(2, createdTreeGrid.getColumns().get(3).getTrees().get(1).getHeight());
        assertEquals(3, createdTreeGrid.getColumns().get(3).getTrees().get(2).getHeight());
        assertEquals(4, createdTreeGrid.getColumns().get(3).getTrees().get(3).getHeight());
        assertEquals(5, createdTreeGrid.getColumns().get(3).getTrees().get(4).getHeight());

        assertEquals(1, createdTreeGrid.getColumns().get(4).getTrees().get(0).getHeight());
        assertEquals(2, createdTreeGrid.getColumns().get(4).getTrees().get(1).getHeight());
        assertEquals(3, createdTreeGrid.getColumns().get(4).getTrees().get(2).getHeight());
        assertEquals(4, createdTreeGrid.getColumns().get(4).getTrees().get(3).getHeight());
        assertEquals(5, createdTreeGrid.getColumns().get(4).getTrees().get(4).getHeight());
    }
}
