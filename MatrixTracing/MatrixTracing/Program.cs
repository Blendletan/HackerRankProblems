using System.IO;
using System.Numerics;

namespace MatrixTracing
{
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

        public static int solve(int n,int m)
        {
            BigInteger modulus = 1000000007;
            if (n < m)
            {
                int temp = m;
                m = n;
                n = temp;
            }
            //compute (n+m-2) choose (n-1)
            BigInteger numerator = 1;
            for (BigInteger i = n + m - 2; i > n - 1; i--)
            {
                numerator *= i;
                numerator = numerator % modulus;
            }
            BigInteger denominator = 1;
            for (int i = 1; i <= m - 1; i++)
            {
                denominator *= i;
                denominator = denominator % modulus;
            }

            BigInteger output = numerator * BigInteger.ModPow(denominator, modulus - 2, modulus); //thankfully ten billion and seven is a prime number
            output = output % modulus;
            return (int)output;
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

                int m = Convert.ToInt32(firstMultipleInput[1]);
                Console.WriteLine(Result.solve(n, m));

            }
        }
    }
}
