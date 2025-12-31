using System.IO;
namespace DifferenceAndProduct
{
    class Result
    {
        /*
         * Complete the 'solve' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER d
         *  2. INTEGER p
         */
        public static int solve(int d, int p)
        {
            if (d < 0)
            {
                return 0;
            }
            if (d == 0 && p == 0)
            {
                return 1;
            }
            int discriminant = d * d + 4 * p;
            if (discriminant == 0)
            {
                return 2;
            }
            if (discriminant < 0)
            {
                return 0;
            }
            int sqrt = (int)Math.Sqrt(discriminant);
            if (sqrt * sqrt == discriminant)
            {
                return 4;
            }
            return 0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            var sw = new StreamWriter("test.txt");
            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int d = Convert.ToInt32(firstMultipleInput[0]);
                int p = Convert.ToInt32(firstMultipleInput[1]);
                int result = Result.solve(d, p);
                Console.WriteLine(result);
            }
            sw.Close();
        }
    }
}
