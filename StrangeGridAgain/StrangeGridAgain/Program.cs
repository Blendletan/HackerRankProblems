namespace StrangeGridAgain
{
    class Result
    {
        /*
         * Complete the 'strangeGrid' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER r
         *  2. INTEGER c
         */
        public static long strangeGrid(int r, int c)
        {
            long startOfRow = StartOfRow(r);
            return startOfRow + 2 * (c - 1);
        }
        private static long StartOfRow(int r)
        {
            long row = (long)r;
            if (int.IsEvenInteger(r))
            {
                return 1 + 10 * ((row - 1) / 2);
            }
            else
            {
                return 10 * (row / 2);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int r = Convert.ToInt32(firstMultipleInput[0]);
            int c = Convert.ToInt32(firstMultipleInput[1]);
            long result = Result.strangeGrid(r, c);
            Console.WriteLine(result);
            Console.WriteLine("Hello, World!");
        }
    }
}
