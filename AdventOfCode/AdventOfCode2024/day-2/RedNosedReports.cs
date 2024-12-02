namespace AdventOfCodeSolutions.day_2
{
    public class RedNosedReports
    {
        public List<List<int>> ReadPuzzleInput()
        {
            var reports = new List<List<int>>();

            const string puzzleInputPath = @"C:\Users\llivint\source\repos\AdventOfCode\AdventOfCode\AdventOfCode2024\day-2\puzzle-input.txt";
            var puzzleInputStream = new StreamReader(puzzleInputPath);
            try
            {
                var line = puzzleInputStream.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    var report = line?.Split(" ")?.Select(int.Parse)?.ToList();
                    if (report != null) reports.Add(report);

                    line = puzzleInputStream.ReadLine();
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            finally { puzzleInputStream.Close(); }

            return reports;
        }

        public int NumberOfGoodReports()
        {
            var reports = ReadPuzzleInput();

            return reports.Sum(report => ProcessReport(report) ? 1 : 0);
        }

        #region PartOne
        private bool CheckIfReportIsSafePartOne(List<int> report)
        {
            var initialReportCopy = new List<int>(report);
            if (report.SequenceEqual(report.OrderBy(number => number)?.ToList()))
            {
                for (var i = 0; i < report.Count - 1; i++)
                {
                    var adjacentDifference = report[i + 1] - report[i];
                    if (adjacentDifference is > 3 or < 1) return false;
                }

                return true;
            }

            if (report.SequenceEqual(report.OrderByDescending(number => number)?.ToList()))
            {
                for (var i = 0; i < report.Count - 1; i++)
                {
                    var adjacentDifference = report[i] - report[i + 1];
                    if (adjacentDifference is > 3 or < 1) return false;
                }

                return true;
            }

            return false;
        }
        #endregion

        #region PartTwo
        private bool ProcessReport(List<int> report)
        {
            if (CheckIfReportIsSafePartTwo(report))
                return true;

            // Try removing each number from the report and check again
            for (int i = 0; i < report.Count; i++)
            {
                var modifiedReport = new List<int>(report);
                modifiedReport.RemoveAt(i); // Remove the number at index i
                if (CheckIfReportIsSafePartTwo(modifiedReport))
                    return true;
            }

            // If no safe modification is found, return false
            return false;
        }

        private bool CheckIfReportIsSafePartTwo(List<int> report)
        {
            if (report.SequenceEqual(report.OrderBy(number => number)?.ToList()))
            {
                for (var i = 0; i < report.Count - 1; i++)
                {
                    var adjacentDifference = report[i + 1] - report[i];
                    if (adjacentDifference is > 3 or < 1) return false;
                }

                return true;
            }

            if (report.SequenceEqual(report.OrderByDescending(number => number)?.ToList()))
            {
                for (var i = 0; i < report.Count - 1; i++)
                {
                    var adjacentDifference = report[i] - report[i + 1];
                    if (adjacentDifference is > 3 or < 1) return false;
                }

                return true;
            }

            return false;
        }
        #endregion
    }
}
