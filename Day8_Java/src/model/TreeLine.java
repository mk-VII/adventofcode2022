package src.model;

import java.util.List;

public class TreeLine {
    private List<Tree> trees;

    private TreeLine(List<Tree> trees)
    {
        this.trees = trees;
    }

    public static TreeLine create(List<Tree> trees) {
        return new TreeLine(trees);
    }

    public List<Tree> getTrees() {
        return trees;
    }
}
