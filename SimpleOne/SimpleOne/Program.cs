using System.IO;
using System.Numerics;
namespace SimpleOne
{
    class Result
    {
        const long modulus = 1000000007;
        public static (BigInteger, BigInteger) TanAdd(BigInteger p1, BigInteger q1, BigInteger p2, BigInteger q2)
        {
            BigInteger pOutput = p2 * q1 + q2 * p1;
            BigInteger qOutput = q2 * q1 - p2 * p1;
            BigInteger gcd = BigInteger.GreatestCommonDivisor(pOutput, qOutput);
            pOutput /= gcd;
            qOutput /= gcd;
            pOutput = ReduceModulus(pOutput);
            qOutput = ReduceModulus(qOutput);
            return (pOutput, qOutput);
        }
        public static (BigInteger, BigInteger) TanMultiply(BigInteger p, BigInteger q, int n)
        {
            if (n == 1)
            {
                return (ReduceModulus(p), ReduceModulus(q));
            }
            if (int.IsOddInteger(n))
            {
                var oneLess = TanMultiply(p, q, n - 1);
                return TanAdd(p, q, oneLess.Item1, oneLess.Item2);
            }
            var twoAlpha = TanAdd(p, q, p, q);
            return TanMultiply(twoAlpha.Item1, twoAlpha.Item2, n / 2);
        }
        public static BigInteger ReduceModulus(BigInteger n)
        {
            if (n >= 0)
            {
                return n % modulus;
            }
            if (n < 0)
            {
                n = modulus - (-n % modulus);
            }
            return n;
        }
        public static BigInteger solve(int p, int q, int n)
        {
            var result = TanMultiply(p, q, n);
            var qInverse = BigInteger.ModPow(result.Item2, modulus - 2, modulus);
            var output = result.Item1 * qInverse;
            output = ReduceModulus(output);
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
                int p = Convert.ToInt32(firstMultipleInput[0]);
                int q = Convert.ToInt32(firstMultipleInput[1]);
                int n = Convert.ToInt32(firstMultipleInput[2]);
                var result = Result.solve(p, q, n);
                Console.WriteLine(result);
            }
        }
    }
}
