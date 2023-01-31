package src.model;

import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class TreeGrid {
    private List<TreeLine> rows;

    private TreeGrid(List<TreeLine> rows) {
        this.rows = rows;
    }

    public static TreeGrid create(List<TreeLine> rows) {
        return new TreeGrid(rows);
    }

    public List<TreeLine> getRows() {
        return rows;
    }

    public List<TreeLine> getColumns() {
        return IntStream.range(0, rows.size())
                .mapToObj((columnIndex) -> TreeLine.create(
                        rows.stream().map((row) -> row.getTrees().get(columnIndex))
                                .collect(Collectors.toList())))
                .collect(Collectors.toList());
    }
}
