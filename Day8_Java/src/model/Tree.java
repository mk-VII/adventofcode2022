package src.model;

public class Tree {
    private int height;

    private Tree(int height) {
        this.height = height;
    }

    public static Tree create(int height) {
        return new Tree(height);
    }

    public int getHeight() {
        return height;
    }
}
