namespace PickingCards
{
    using System.Diagnostics;
    class Result
    {
        /*
         * Complete the 'solve' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY c as parameter.
         */
        const long modulus = 1000000007;
        public static long solve(List<int> c)
        {
            if (c.Contains(0) == false)
            {
                return 0;
            }
            int N = c.Count;
            long[] cdf = new long[N + 1];
            foreach (int i in c)
            {
                cdf[i]++;
            }
            for (int i = 1; i <= N; i++)
            {
                cdf[i] += cdf[i - 1];
                if (cdf[i] == 0)
                {
                    return 0;
                }
            }
            long output = 1;
            for (int i = 0; i < N; i++)
            {
                if (cdf[i] <= i)
                {
                    return 0;
                }
                output *= (cdf[i]-i);
                output = output % modulus;
            }
            return output;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            var sw = new Stopwatch();
            //sw.Start();
            for (int tItr = 0; tItr < t; tItr++)
            {
                int cCount = Convert.ToInt32(Console.ReadLine().Trim());
                List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();
                long result = Result.solve(c);
                Console.WriteLine(result);
            }
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
