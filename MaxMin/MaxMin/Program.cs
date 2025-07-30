namespace MaxMin
{
    class Result
    {
        /*
         * Complete the 'maxMin' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY arr
         */
        public static int maxMin(int k, List<int> arr)
        {
            int lastStartIndex = arr.Count - k;
            arr.Sort();
            int minDiscrepency = GapSize(arr, 0, k);
            for (int i = 1; i <= lastStartIndex; i++)
            {
                int newDiscrepency = GapSize(arr, i, k);
                if (newDiscrepency < minDiscrepency)
                {
                    minDiscrepency = newDiscrepency;
                }
            }
            return minDiscrepency;
        }
        private static int GapSize(List<int> sortedArray, int startIndex, int gapSize)
        {
            int endIndex = startIndex + gapSize - 1;
            int discrepency = sortedArray[endIndex] - sortedArray[startIndex];
            return discrepency;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            int k = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> arr = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
                arr.Add(arrItem);
            }
            int result = Result.maxMin(k, arr);
            Console.WriteLine(result);
        }
    }
}
