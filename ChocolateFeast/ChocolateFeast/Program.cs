namespace ChocolateFeast
{
    class Result
    {

        /*
         * Complete the 'chocolateFeast' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER c
         *  3. INTEGER m
         */

        public static int chocolateFeast(int n, int c, int m)
        {
            Bobby b = new Bobby(n, c, m);
            while (true)
            {
                if (b.GetMoreBars() == false)
                {
                    return b.TotalBarsConsumed;
                }
            }
        }

    }
    class Bobby
    {
        int remainingMoney;
        int numberOfWrappers;
        public int TotalBarsConsumed { get; private set; }
        int numberOfWrappersToGetFreeBar;
        int costOfChocolateBar;
        public Bobby(int n, int c, int m)
        {
            remainingMoney = n;
            costOfChocolateBar = c;
            numberOfWrappersToGetFreeBar = m;
            numberOfWrappers = 0;
            TotalBarsConsumed = 0;
        }
        public bool GetMoreBars()
        {
            bool output = false;
            int numberOfBarsToBuy = remainingMoney / costOfChocolateBar;
            if (numberOfBarsToBuy > 0)
            {
                output = true;
            }
            int costOfBars = numberOfBarsToBuy * costOfChocolateBar;
            remainingMoney -= costOfBars;
            TotalBarsConsumed += numberOfBarsToBuy;
            numberOfWrappers += numberOfBarsToBuy;
            int numberOfBarsToGetFromWrappers = numberOfWrappers / numberOfWrappersToGetFreeBar;
            if (numberOfBarsToGetFromWrappers > 0)
            {
                output = true;
            }
            int numberOfWrappersUsed = numberOfBarsToGetFromWrappers * numberOfWrappersToGetFreeBar;
            numberOfWrappers -= numberOfWrappersUsed;
            TotalBarsConsumed += numberOfBarsToGetFromWrappers;
            numberOfWrappers += numberOfBarsToGetFromWrappers;
            return output;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int n = Convert.ToInt32(firstMultipleInput[0]);
                int c = Convert.ToInt32(firstMultipleInput[1]);
                int m = Convert.ToInt32(firstMultipleInput[2]);
                int result = Result.chocolateFeast(n, c, m);
                Console.WriteLine(result);
            }
        }
    }
}
