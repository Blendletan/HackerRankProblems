namespace FairRations
{
    class Result
    {
        /*
         * Complete the 'fairRations' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts INTEGER_ARRAY B as parameter.
         */
        public static string fairRations(List<int> B)
        {
            int loavesDistributed = 0;
            int nextOdd;
            while (true)
            {
                nextOdd = FindFirstOddIndex(B);
                if (loavesDistributed > B.Count)
                {
                    loavesDistributed = -1;
                    break;
                }
                if (nextOdd == -1)
                {
                    break;
                }
                if (nextOdd == B.Count - 1)
                {
                    B[nextOdd]++;
                    B[nextOdd - 1]++;
                }
                else
                {
                    B[nextOdd]++;
                    B[nextOdd + 1]++;
                }
                loavesDistributed += 2;
            }
            if (loavesDistributed == -1)
            {
                return "NO";
            }
            return loavesDistributed.ToString();
        }
        private static int FindFirstOddIndex(List<int> input)
        {
            int length = input.Count;
            for (int i = 0; i < length; i++)
            {
                if (int.IsOddInteger(input[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();
            string result = Result.fairRations(B);
            Console.WriteLine(result);
        }
    }
}
