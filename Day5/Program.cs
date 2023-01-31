namespace Day5
{
    class Program
    {
        private static List<List<char>> GetInitialCrateStacks() => new List<List<char>>
        {
            new List<char>(),
            new List<char> {'Q', 'W', 'P', 'S', 'Z', 'R', 'H', 'D'},
            new List<char> {'V', 'B', 'R', 'W', 'Q', 'H', 'F'},
            new List<char> {'C', 'V', 'S', 'H'},
            new List<char> {'H', 'F', 'G'},
            new List<char> {'P', 'G', 'J', 'B', 'Z'},
            new List<char> {'Q', 'T', 'J', 'H', 'W', 'F', 'L'},
            new List<char> {'Z', 'T', 'W', 'D', 'L', 'V', 'J', 'N'},
            new List<char> {'D', 'T', 'Z', 'C', 'J', 'G', 'H', 'F'},
            new List<char> {'W', 'P', 'V', 'M', 'B', 'H'},
        };

        static void Main(string[] args)
        {
            var instructions = File.ReadLines("data/input.txt").ToArray();

            Console.WriteLine($"The answer to part 1 is: {GetAnswer(instructions, GetInitialCrateStacks())}");
            Console.WriteLine($"The answer to part 2 is: {GetAnswer(instructions, GetInitialCrateStacks(), true)}");
        }

        private static string GetAnswer(string[] instructions, List<List<char>> stacks, bool canLiftMultiple = false)
        {
            var parsedInstructions = ParseInstructionNumbers(instructions);

            parsedInstructions.ForEach(move => MoveCratesPerInstruction(move, stacks, canLiftMultiple));

            return new string(stacks
                .Where(stack => stack.Any())
                .Select(stack => stack.Last())
                .ToArray()
            );
        }

        private static void MoveCratesPerInstruction((int moveCount, int fromIndex, int toIndex) move, List<List<char>> stacks, bool canLiftMultiple)
        {
            var (moveCount, fromIndex, toIndex) = move;

            var fromStack = stacks[fromIndex];
            var toStack = stacks[toIndex];

            if (canLiftMultiple)
            {
                var cratesToMove = fromStack.ToArray().TakeLast(moveCount);

                fromStack.RemoveRange(fromStack.Count() - moveCount, moveCount);
                toStack.AddRange(cratesToMove);
            }
            else
            {
                Enumerable.Range(1, moveCount).ToList().ForEach(move => {
                    var topCrateIndex = fromStack.Count - 1;
                    var crateToMove = fromStack[topCrateIndex];
                    
                    fromStack.RemoveAt(topCrateIndex);
                    toStack.Add(crateToMove);
                });
            }
        }

        private static List<(int moveCount, int fromIndex, int toIndex)> ParseInstructionNumbers(string[] instructions)
        {
            return instructions
                .Select(instruction =>
                {
                    var instructionParts = instruction.Split(" ");

                    var numericValues = instructionParts
                        .Where(part => int.TryParse(part, out _))
                        .Select(value => int.Parse(value))
                        .ToArray();

                    return (
                        moveCount: numericValues[0],
                        fromIndex: numericValues[1],
                        toIndex: numericValues[2]
                    );
                })
                .ToList();
        }
    }
}