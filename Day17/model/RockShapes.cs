public static class RockShapes
{
    private const char ROCK = '#';
    private const char SPACE = '.';

    public static char[][] One = new[] { new[] { ROCK, ROCK, ROCK, ROCK } };

    public static char[][] Two = new[] {
        new[] { SPACE, ROCK, SPACE },
        new[] { ROCK, ROCK, ROCK },
        new[] { SPACE, ROCK, SPACE },
    };

    public static char[][] Three = new[] {
        new[] { SPACE, SPACE, ROCK },
        new[] { SPACE, SPACE, ROCK },
        new[] { ROCK, ROCK, ROCK },
    };

    public static char[][] Four = new[] {
        new[] { ROCK },
        new[] { ROCK },
        new[] { ROCK },
        new[] { ROCK },
    };

    public static char[][] Five = new[] {
        new[] { ROCK, ROCK },
        new[] { ROCK, ROCK },
    };
}