namespace Day2
{
    enum Move
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3,
    }

    enum Result
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }

    class Program
    {
        private readonly static Dictionary<string, Move> _movesMap = new Dictionary<string, Move>()
        {
            {"A", Move.Rock},
            {"B", Move.Paper},
            {"C", Move.Scissors},
            {"X", Move.Rock},
            {"Y", Move.Paper},
            {"Z", Move.Scissors},
        };

        private readonly static Dictionary<string, Result> _resultsMap = new Dictionary<string, Result>()
        {
            {"X", Result.Lose},
            {"Y", Result.Draw},
            {"Z", Result.Win},
        };

        private readonly static Dictionary<Move, Move> _winningMoves = new Dictionary<Move, Move>()
        {
            {Move.Rock, Move.Paper},
            {Move.Paper, Move.Scissors},
            {Move.Scissors, Move.Rock}
        };

        private readonly static Dictionary<Move, Move> _losingMoves = new Dictionary<Move, Move>()
        {
            {Move.Paper, Move.Rock},
            {Move.Scissors, Move.Paper},
            {Move.Rock, Move.Scissors}
        };

        static void Main(string[] args)
        {
            var rounds = File.ReadAllLines("data/input.txt").Select(line =>
            {
                var moves = line.Split(" ");

                return (oppMove: moves[0], myMove: moves[1]);
            }).ToArray();

            var roundPlayScores = rounds.Select(round => GetScoreForPlay(round.oppMove, round.myMove));
            var roundResultScores = rounds.Select(round => GetScoreForResult(round.oppMove, round.myMove));

            Console.WriteLine($"Your total score across all rounds is: {roundPlayScores.Sum()}");
            Console.WriteLine($"Your total score across all rounds is: {roundResultScores.Sum()}");
        }

        static int GetScoreForPlay(string oppMove, string myMove)
        {
            return (int)_movesMap[myMove] + (int)GetRoundResult(_movesMap[oppMove], _movesMap[myMove]);
        }

        static int GetScoreForResult(string oppMove, string myMove)
        {
            var desiredResult = _resultsMap[myMove];
            Move chosenMove = _movesMap[oppMove];

            if (desiredResult == Result.Lose)
            {
                chosenMove = _losingMoves[_movesMap[oppMove]];
            }
            else if (desiredResult == Result.Win)
            {
                chosenMove = _winningMoves[_movesMap[oppMove]];
            }

            return (int)chosenMove + (int)desiredResult;
        }

        private static Result GetRoundResult(Move oppMove, Move myMove)
        {
            if (oppMove == myMove) return Result.Draw;

            return GetWinningMove(oppMove, myMove) == myMove
            ? Result.Win
            : Result.Lose;
        }

        private static Move GetWinningMove(Move oppMove, Move myMove)
        {
            return oppMove == Move.Rock && myMove == Move.Paper ||
            oppMove == Move.Scissors && myMove == Move.Rock ||
            oppMove == Move.Paper && myMove == Move.Scissors
            ? myMove
            : oppMove;
        }
    }
}