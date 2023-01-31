namespace Day6
{
    class Program
    {
        const int PacketMarkerLength = 4;
        const int MessageMarkerLength = 14;

        static void Main(string[] args)
        {
            var input = File.ReadAllText("data/input.txt");

            Console.WriteLine($"The first packet marker is found at index: {GetAnswer(input, PacketMarkerLength)}");
            Console.WriteLine($"The first message marker is found at index: {GetAnswer(input, MessageMarkerLength)}");
        }

        private static int GetAnswer(string input, int charsLength)
        {
            for (int markerStartIndex = 0; markerStartIndex < input.Length; markerStartIndex++)
            {
                var markerChars = new List<char> { input[markerStartIndex] };

                for (int nextCharIndex = markerStartIndex + 1; nextCharIndex < markerStartIndex + charsLength; nextCharIndex++)
                {
                    var nextChar = input[nextCharIndex];

                    markerChars = (markerChars.Contains(nextChar)
                        ? new List<char>()
                        : markerChars.Concat(new [] {nextChar})
                    ).ToList();
                }

                if (markerChars.Count() == charsLength)
                {
                    return markerStartIndex + charsLength;
                }
            }

            return -1;
        }
    }
}