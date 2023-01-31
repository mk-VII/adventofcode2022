namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data/input.txt");

            Console.WriteLine(GetAnswerToPartOne(lines));
        }

        private static int GetAnswerToPartOne(string[] commands)
        {
            var distDirs = commands.Where(x => x.StartsWith("dir")).Distinct();

            var directoriesDict = CreateDirectoriesDictionaryFromCommands(commands);

            var directoryBytes = directoriesDict
                .Select(dir => GetBytesCountForDirectory(dir.Value, directoriesDict))
                .Where(x => x <= 100000);

            foreach (var value in directoryBytes.Where(x => x <= 100000))
            {
                Console.WriteLine(value);
            }

            return directoryBytes.Sum();
        }

        private static int GetBytesCountForDirectory(
            string[] contents,
            Dictionary<string, string[]> dictionary)
        {
            var subDirectories = contents.Where(x => x.StartsWith("dir"));
            var files = contents.Except(subDirectories);

            var subDirectoryBytes = subDirectories.Select(x =>
                GetBytesCountForDirectory(dictionary[x.Split(" ").Last()], dictionary));
            var fileBytes = files.Select(name => int.Parse(name.Split(" ").First()));

            return subDirectoryBytes.Sum() + fileBytes.Sum();
        }

        private static Dictionary<string, string[]> CreateDirectoriesDictionaryFromCommands(string[] commands)
        {
            var directoryNames = new List<string>();
            var directoryContents = new List<List<string>>();

            foreach (var command in commands)
            {
                if (!command.Equals("$ cd .."))
                {
                    if (command.StartsWith("$ cd"))
                    {
                        var directoryName = command.Split(" ").Last();
                        if (!directoryNames.Contains(directoryName))
                        {
                            directoryNames.Add(directoryName);
                            directoryContents.Add(new List<string>());
                        }
                    }
                    else if (!command.StartsWith("$ ls"))
                    {
                        if (!directoryContents.SelectMany(x => x).Contains(command))
                        {
                            directoryContents.Last().Add(command);
                        }
                    }
                }
            }

            return directoryNames
                .Select((name, index) => (name, contents: directoryContents[index].ToArray()))
                .ToDictionary(x => x.name, x => x.contents);
        }
    }
}