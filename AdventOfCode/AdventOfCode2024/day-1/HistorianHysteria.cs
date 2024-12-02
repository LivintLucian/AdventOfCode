namespace AdventOfCodeSolutions.day_1
{
    public class HistorianHysteria
    {
        public (List<int> HistorianLineOne, List<int> HistorianLineTwo) ReadPuzzleInput()
        {
            var historianLineOne = new List<int>();
            var historianLineTwo = new List<int>();

            var puzzleInputPath = @"C:\Users\llivint\source\repos\AdventOfCode\AdventOfCode\AdventOfCode2024\day-1\puzzle-input.txt";
            var puzzleInputStream = new StreamReader(puzzleInputPath);
            try
            {
                var line = puzzleInputStream.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    var listElements = line?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    historianLineOne.Add(Convert.ToInt32(listElements?[0]));
                    historianLineTwo.Add(Convert.ToInt32(listElements?[1]));

                    line = puzzleInputStream.ReadLine();
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            finally { puzzleInputStream.Close(); }

            return (historianLineOne, historianLineTwo);
        }

        public int HistorianHysteriaPartOne()
        {
            var (historianLineOne, historianLineTwo) = ReadPuzzleInput();

            historianLineOne.Sort();
            historianLineTwo.Sort();

            return historianLineOne
                .Select((t, i) => t > historianLineTwo[i]
                    ? t - historianLineTwo[i]
                    : historianLineTwo[i] - t)
                .Sum();
        }

        public int HistorianHysteriaPartTwo()
        {
            var (historianLineOne, historianLineTwo) = ReadPuzzleInput();

            var historianLineTwoFrequency = new Dictionary<int, int>();
            foreach (var number in historianLineTwo)
            {
                if (historianLineTwoFrequency.ContainsKey(number))
                {
                    historianLineTwoFrequency[number]++;
                    continue;
                }

                historianLineTwoFrequency.Add(number, 1);
            }

            return historianLineOne.Sum(number => historianLineTwoFrequency.TryGetValue(number, out var value)
                ? number * value
                : 0);
        }
    }
}
