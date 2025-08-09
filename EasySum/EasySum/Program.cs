namespace EasySum
{
    using System.Numerics;
    using System.Diagnostics;
    class Result
    {
        /*
         * Complete the 'solve' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER m
         */
        public static long solve(int n, int m)
        {
            long output = 0;
            int numberOfFullRepititions = n / m;
            int remainderLength = n % m;
            long sumOfOneRepitition = ((long)m*((long)m-1))/2;
            long sumOfRemainder = ((long)remainderLength * ((long)remainderLength + 1)) / 2;
            output += sumOfRemainder;
            output += sumOfOneRepitition * numberOfFullRepititions;
            return output;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            bool debug = true;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string debugFilePath = "debug.txt";
            StreamWriter debugWriter = new StreamWriter(debugFilePath);
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int n = Convert.ToInt32(firstMultipleInput[0]);
                int m = Convert.ToInt32(firstMultipleInput[1]);
                var result = Result.solve(n, m);
                if (debug)
                {
                    debugWriter.WriteLine(result);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine(result);
                }
            }
            sw.Stop();
            debugWriter.Close();
            if (debug)
            {
                Console.WriteLine(sw.Elapsed);
            }
        }
    }
}
