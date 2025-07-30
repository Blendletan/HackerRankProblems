namespace LisasWorkbook
{
    class Result
    {
        /*
         * Complete the 'workbook' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER k
         *  3. INTEGER_ARRAY arr
         */
        public static int workbook(int n, int k, List<int> arr)
        {
            LisaWorkbook solution = new LisaWorkbook(k, arr);
            int output = 0;
            foreach (LisaProblem p in solution.problems)
            {
                if (p.pageNumber == p.problemNumber)
                {
                    output++;
                }
            }
            return output;
        }
    }
    class LisaProblem
    {
        public readonly int pageNumber;
        public readonly int problemNumber;
        public LisaProblem(int page, int problem)
        {
            pageNumber = page;
            problemNumber = problem;
        }
    }
    class LisaWorkbook
    {
        public readonly List<LisaProblem> problems;
        public LisaWorkbook(int maxProblemsPerPage, List<int> chapters)
        {
            problems = new List<LisaProblem>();
            int currentPageNumber = 0;
            int numberOfChapters = chapters.Count;
            for (int chapterIndex = 0; chapterIndex < numberOfChapters; chapterIndex++)
            {
                currentPageNumber++;
                int numberOfProblemsOnCurrentPage = 0;
                int numberOfProblemsInChapter = chapters[chapterIndex];
                for (int currentProblemNumber = 1; currentProblemNumber <= numberOfProblemsInChapter; currentProblemNumber++)
                {
                    if (numberOfProblemsOnCurrentPage == maxProblemsPerPage)
                    {
                        numberOfProblemsOnCurrentPage = 0;
                        currentPageNumber++;
                    }
                    LisaProblem currentProblem = new LisaProblem(currentPageNumber, currentProblemNumber);
                    problems.Add(currentProblem);
                    numberOfProblemsOnCurrentPage++;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int k = Convert.ToInt32(firstMultipleInput[1]);
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            int result = Result.workbook(n, k, arr);
            Console.WriteLine(result);
        }
    }
}
