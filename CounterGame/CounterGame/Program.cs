namespace CounterGame
{
    class Result
    {
        /*
         * Complete the 'counterGame' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts LONG_INTEGER n as parameter.
         */
        public static string counterGame(long n)
        {
            long? currentResult = n;
            bool richardWins=true;
            while (true)
            {
                if (currentResult == null)
                {
                    richardWins = !richardWins;
                    break;
                }
                currentResult = PerformTurn(currentResult.Value);
                richardWins = !richardWins;
            }
            if (richardWins)
            {
                return "Richard";
            }
            return "Louise";
        }
        public static long? PerformTurn(long n)
        {
            if (n == 1)
            {
                return null;
            }
            long log = (long)Math.Log2(n);
            long powerOfTwo = (long)Math.Pow(2, log);
            if (powerOfTwo == n)
            {
                return n / 2;
            }
            return n - powerOfTwo;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                long n = Convert.ToInt64(Console.ReadLine().Trim());
                string result = Result.counterGame(n);
                Console.WriteLine(result);
            }
        }
    }
}
