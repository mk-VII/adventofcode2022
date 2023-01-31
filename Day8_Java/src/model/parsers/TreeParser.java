package src.model.parsers;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.IntStream;
import java.util.stream.Stream;

import src.model.*;

public class TreeParser {
    // public static TreeGrid parseTreeGrid(List<String> lines) {
    //     return TreeGrid.create(lines.stream()
    //             .map(TreeParser::parseTreeLine)
    //             .collect(Collectors.toList()));
    // }

    public static TreeLine parseTreeLine(String line) {
        var chars = Arrays.asList(line.chars());

        return TreeLine.create(null);
    }

    public static Tree parseTree(String input) {
        return Tree.create(Integer.parseInt(input));
    }
}
